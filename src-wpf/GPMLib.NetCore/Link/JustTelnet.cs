using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GPMLib.Netcore {

    public class JustTelnet : IDisposable {

        private readonly int _port;
        private readonly string _host;
        private readonly TimeSpan _sendRate;
        private readonly SemaphoreSlim _sendRateLimit;
        private readonly CancellationTokenSource _internalCancellation;

        private TcpClient _tcpClient;
        private StreamReader _tcpReader;
        private StreamWriter _tcpWriter;

        public EventHandler<string> MessageReceived;
        public EventHandler ConnectionClosed;

        public bool IsConnected {
            get {
                try {
                    return _tcpClient?.Connected ?? false;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    Trace.TraceInformation($"{nameof(WaitForMessage)} aborted: {nameof(_tcpClient)} is not connected");
                    return false;
                }
            } 
        }

        /// <summary>
        /// Simple telnet client
        /// </summary>
        /// <param name="host">Destination Hostname or IP</param>
        /// <param name="port">Destination TCP port number</param>
        /// <param name="sendRate">Minimum time span between sends. This is a throttle to prevent flooding the server.</param>
        /// <param name="token"></param>
        public JustTelnet(string host, int port, TimeSpan sendRate, CancellationToken token) {
            _host = host;
            _port = port;
            _sendRate = sendRate;
            _sendRateLimit = new SemaphoreSlim(1);
            _internalCancellation = new CancellationTokenSource();

            token.Register(() => _internalCancellation.Cancel());
        }

        /// <summary>
        /// Connect and wait for incoming messages. 
        /// When this task completes you are connected. 
        /// You cannot call this method twice; if you need to reconnect, dispose of this instance and create a new one.
        /// </summary>
        /// <returns></returns>
        public void Connect(bool waitForMessages = false) {
            if (_tcpClient != null) {
                throw new NotSupportedException($"{nameof(Connect)} aborted: Reconnecting is not supported. You must dispose of this instance and instantiate a new TelnetClient");
            }

            try {
                _tcpClient = new TcpClient(); // _host, _port);
                var connectionTask = _tcpClient.ConnectAsync(_host, _port).ContinueWith(task => { return task.IsFaulted ? null : _tcpClient; }, TaskContinuationOptions.ExecuteSynchronously);
                var timeoutTask = Task.Delay(50).ContinueWith<TcpClient>(task => null, TaskContinuationOptions.ExecuteSynchronously);
                var resultTask = Task.WhenAny(connectionTask, timeoutTask).Unwrap();

                resultTask.Wait();
                var resultTcpClient = resultTask.Result;
                // Or shorter by using `await`:
                // var resultTcpClient = await resultTask;

                if (resultTcpClient != null) {
                    Console.WriteLine("Connected to " + _host + ":" + _port);
                } else {
                    Console.WriteLine("Cannot connect to " + _host + ":" + _port);
                }
                //await _tcpClient.ConnectAsync(_host, _port);

                _tcpReader = new StreamReader(_tcpClient.GetStream());
                _tcpWriter = new StreamWriter(_tcpClient.GetStream()) { AutoFlush = true };

                if (waitForMessages) {
                    // Fire-and-forget looping task that waits for messages to arrive
                    _ = WaitForMessage().ConfigureAwait(false);
                }
            } catch (Exception ex) {
                Console.WriteLine($"{nameof(Connect)} exception: " + ex.ToString());
                Disconnect();
            }
        }


        public async Task Send(string message) {
            if (!this.IsConnected) { return; }
            try {
                if (_internalCancellation.IsCancellationRequested) { return; }

                // Wait for any previous send commands to finish and release the semaphore
                // This throttles our commands
                await _sendRateLimit.WaitAsync(_internalCancellation.Token);

                // Send command + params
                await _tcpWriter.WriteLineAsync(message);

                // Block other commands until our timeout to prevent flooding
                await Task.Delay(_sendRate, _internalCancellation.Token);
            } catch (OperationCanceledException) {
                // We're waiting to release our semaphore, and someone cancelled the task on us (I'm looking at you, WaitForMessages...)
                // This happens if we've just sent something and then disconnect immediately
                Trace.TraceInformation($"{nameof(Send)} aborted: {nameof(_internalCancellation.IsCancellationRequested)} == true");
            } catch (ObjectDisposedException) {
                // This happens during ReadLineAsync() when we call Disconnect() and close the underlying stream
                // This is an expected exception during disconnection if we're in the middle of a send
                Trace.TraceInformation($"{nameof(Send)} failed: {nameof(_tcpWriter)} or {nameof(_tcpWriter.BaseStream)} disposed");
            } catch (IOException) {
                // This happens when we start WriteLineAsync() if the socket is disconnected unexpectedly
                Trace.TraceError($"{nameof(Send)} failed: Socket disconnected unexpectedly");
                throw;
            } catch (Exception error) {
                Trace.TraceError($"{nameof(Send)} failed: {error}");
                throw;
            } finally {
                // Exit our semaphore
                _sendRateLimit.Release();
            }
        }

        public async Task<string> Query(string cmd) {
            if (!this.IsConnected) { return string.Empty; }
            await Send(cmd).ConfigureAwait(false);
            string message;

            try {
                // Due to CR/LF platform differences, we sometimes get empty messages if the server sends us over-eager EOL markers
                // Because ReadLine*() strips out the EOL characters, the message can end up empty (but not null!)
                // I *think* this is a server implementation problem rather than our problem to solve
                // So just handle empty messages in your consumer library
                message = await _tcpReader.ReadLineAsync();
                //message = await _tcpReader.ReadToEndAsync();
                return message;

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return string.Empty;
        }

        private async Task WaitForMessage() {
            try {
                while (true) {
                    if (_internalCancellation.IsCancellationRequested) {
                        Trace.TraceInformation($"{nameof(WaitForMessage)} aborted: {nameof(_internalCancellation.IsCancellationRequested)} == true");
                        break;
                    }

                    string message;

                    try {
                        if (!this.IsConnected) {
                            Trace.TraceInformation($"{nameof(WaitForMessage)} aborted: {nameof(_tcpClient)} is not connected");
                            break;
                        }

                        // Due to CR/LF platform differences, we sometimes get empty messages if the server sends us over-eager EOL markers
                        // Because ReadLine*() strips out the EOL characters, the message can end up empty (but not null!)
                        // I *think* this is a server implementation problem rather than our problem to solve
                        // So just handle empty messages in your consumer library
                        message = await _tcpReader.ReadLineAsync();
                        //message = await _tcpReader.ReadToEndAsync();

                        if (message == null) {
                            Trace.TraceInformation($"{nameof(WaitForMessage)} aborted: {nameof(_tcpReader)} reached end of stream");
                            break;
                        }
                    } catch (ObjectDisposedException) {
                        // This happens during ReadLineAsync() when we call Disconnect() and close the underlying stream
                        // This is an expected exception during disconnection
                        Trace.TraceInformation($"{nameof(WaitForMessage)} aborted: {nameof(_tcpReader)} or {nameof(_tcpReader.BaseStream)} disposed. This is expected after calling Disconnect()");
                        break;
                    } catch (IOException) {
                        // This happens when we start ReadLineAsync() if the socket is disconnected unexpectedly
                        Trace.TraceError($"{nameof(WaitForMessage)} aborted: Socket disconnected unexpectedly");
                        break;
                    } catch (Exception error) {
                        Trace.TraceError($"{nameof(WaitForMessage)} aborted: {error}");
                        break;
                    }

                    Trace.TraceInformation($"{nameof(WaitForMessage)} received: {message} [{message.Length}]");

                    OnMessageReceived(message);
                }
            } finally {
                Trace.TraceInformation($"{nameof(WaitForMessage)} completed: Calling {nameof(Disconnect)}");
                Disconnect();
            }
        }

        /// <summary>
        /// Disconnecting will leave TelnetClient in an unusable state.
        /// </summary>
        public void Disconnect() {
            try {
                // Blow up any outstanding tasks
                _internalCancellation.Cancel();

                // Both reader and writer use the TcpClient.GetStream(), and closing them will close the underlying stream
                // So closing the stream for TcpClient is redundant
                // But it means we're triple sure!
                _tcpReader?.Close();
                _tcpWriter?.Close();
                _tcpClient?.Close();
            } catch (Exception error) {
                Trace.TraceError($"{nameof(Disconnect)} error: {error}");
            } finally {
                OnConnectionClosed();
            }
        }

        private void OnMessageReceived(string message) {
            MessageReceived?.Invoke(this, message);
        }

        private void OnConnectionClosed() {
            ConnectionClosed?.Invoke(this, new EventArgs());
        }

        private bool _disposed = false;


        public void Dispose() {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }

            if (disposing) {
                Disconnect();
            }

            _disposed = true;
        }
    }
}
