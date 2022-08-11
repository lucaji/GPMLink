using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {
    public class ConnectionManager {

        public event EventHandler? ConfigurationChangeEvent;

        /// <summary>
        /// When using LAN, terminator character is fixed to CR+LF
        /// </summary>
        public string LineFeedTerminator { get; private set; } = "\r\n";

        public ConnectionManager(GPMDevice d) {
            if (d is null) { throw new Exception("null device for connection manager... shite"); }
            ParentDevice = d;
        }

        public GPMDevice ParentDevice { get; private set; }

        private string DeviceIPAddress { 
            get { return this.ParentDevice.DeviceIPAddress; } 
            set { this.ParentDevice.DeviceIPAddress = value; }
        }

        private JustTelnet? _justTelnetClient;


        CancellationToken cancelTaskToken;

        public bool IsConnected { get { return _justTelnetClient?.IsConnected ?? false; } }

        public bool IsDisconnected { get { return !IsConnected; } }


        public void Disconnect() {
            ReadingsTimerStop();
            
            _justTelnetClient?.Disconnect();
            _justTelnetClient?.Dispose();
            _justTelnetClient = null;

            this.ConfigurationChangeEvent?.Invoke(this.ParentDevice, null);
            GPMDevice.LogToConsole("Disconnected link from " + DeviceIPAddress);
        }



        public async Task<bool> Connect(bool connect = true) {
            var success = true;
            if (connect) {
                if (!IsConnected) {
                    cancelTaskToken = new System.Threading.CancellationToken();
                    
                    _justTelnetClient = new JustTelnet(DeviceIPAddress, 23, TimeSpan.FromMilliseconds(30), cancelTaskToken);
                    _justTelnetClient.Connect();

                    success = IsConnected;
                    if (success) {
                        success = await this.ParentDevice.InitializeDevice().ConfigureAwait(false);
                    }
                    if (success) {
                        ReadingsTimerStart();
                        ConfigurationChangeEvent?.Invoke(this.ParentDevice, null);
                        GPMDevice.LogToConsole("Link to " + DeviceIPAddress + " established.");
                    } else {
                        GPMDevice.LogError("Failed to establish link " + DeviceIPAddress);
                        Disconnect();
                    }
                }
            } else {
                if (IsConnected) {
                    Disconnect();
                    success = true;
                }
            }
            return success;
        }

        public async Task<bool> ToggleConnection() {
            return await Connect(!IsConnected);
        }

        public TimeSpan CommunicationTimeout { get; private set; } = TimeSpan.FromMilliseconds(5000.0);

        /// <summary>
        /// Changes the IP Address, manually disconnect first if already connected.
        /// 
        /// </summary>
        /// <param name="newIp"></param>
        /// <returns>false if an error occurred</returns>
        public bool ChangeIPAddress(string newIp) {
            if (IPAddressInvalid(newIp)) { return false; }
            if (DeviceIPAddress == newIp) { return true; }
            if (IsConnected) { return false; }
            DeviceIPAddress = newIp;
            return true;
        }


        public async Task<string> QueryDeviceWith(string cmd, bool honourTerminator = true) {
            if (!IsConnected) { return string.Empty; }
            AddToTrascript(cmd, outbound: true);
            var s = string.Empty;
            if (honourTerminator) {
                if (!EndsWithTerminatorString(cmd)) {
                    cmd += LineFeedTerminator;
                }
            }
            
            s = await _justTelnetClient!.Query(cmd).ConfigureAwait(false);
            if (honourTerminator) {
                s = s.TrimEnd(LineFeedTerminator.ToArray());
            }
            AddToTrascript(s, outbound: false);
            return s;
        }

        public async Task<bool> SendToDevice(string cmd, bool honourTerminator = true) {
            if (!IsConnected) { return false; }
            AddToTrascript(cmd, outbound: true);

            if (honourTerminator) {
                if (!EndsWithTerminatorString(cmd)) {
                    cmd += LineFeedTerminator;
                }
            }
            
            await _justTelnetClient!.Send(cmd).ConfigureAwait(false);
            return true;
        }


        /// <summary>
        /// Determines whether the specified terminator has been located.
        /// not a static method as different devices might be configured differently
        /// (see LineFeedTerminator field)
        /// </summary>
        /// <param name="terminator">The terminator to search for.</param>
        /// <param name="s">The content to search for the <paramref name="terminator"/>.</param>
        /// <returns>True if the terminator is located, otherwise false.</returns>
        public bool EndsWithTerminatorString(string s) {
            if (string.IsNullOrEmpty(s)) { return false; }
            return s.EndsWith(LineFeedTerminator);
        }


        /// <summary>
        /// IP address string validation
        /// </summary>
        /// <param name="a">test string</param>
        /// <param name="failOnLocal">test against 127.0.0.1 string</param>
        /// <returns>true if invalid ip address was given</returns>
        public static bool IPAddressInvalid(string a, bool failOnLocal = true) {
            if (string.IsNullOrWhiteSpace(a)) { return true; }
            if (failOnLocal && a.Equals("127.0.0.1")) { return true; }
            try {
                var ip = System.Net.IPAddress.Parse(a);
                return false;
            } catch { }
            return true;
        }


        #region Readings

        private int _ReadingsDelay = 2000;

        public int ReadingsDelay { get { return _ReadingsDelay; } }
        public void ChangeReadingsFrequency(string fs) {
            _ReadingsDelay = ReadingsFrequency.ReadingsSpeedStringToDelay(fs);
            if (IsTimerRunning) {
                ReadingsTimer?.Change(0, _ReadingsDelay);
            }
        }

        public string CurrentReadingFrequencyString {
            get {
                return ReadingsFrequency.DelayToString(_ReadingsDelay);
            }
        }

        public event EventHandler<DataSample>? GetLiveReadingsEvent;


        private System.Threading.Timer? ReadingsTimer;

        public bool IsTimerRunning {
            get; set;
        }

        public void ReadingsTimerStart() {
            if (IsTimerRunning) {
                Console.WriteLine("ReadingsTimerStart timer still running...");
                return; 
            }
            try {
                TimerDisposed = new(false);
                ReadingsTimer = new Timer(OnTimerEvent, this, 0, _ReadingsDelay);
                IsTimerRunning = true;
            } catch (Exception ex) {
                GPMDevice.LogError(ex.ToString());
                IsTimerRunning = false;
                TimerDisposed = null;
                ReadingsTimer = null;
            }
        }

        private ManualResetEvent? TimerDisposed = null;

        public void ReadingsTimerStop() {
            IsTimerRunning = false;
            ReadingsTimer?.Change(Timeout.Infinite, Timeout.Infinite);
            ReadingsTimer?.Dispose(TimerDisposed);
            TimerDisposed?.WaitOne(200);
            TimerDisposed?.Dispose();
            ReadingsTimer = null;
            TimerDisposed = null;
        }

        async void OnTimerEvent(object? state) {
            var o = state as ConnectionManager;
            bool success;
            if (o?.IsTimerRunning ?? false) {
                try {
                    success = await this.ParentDevice.GetDeviceState().ConfigureAwait(false);
                    if (!success) { return; }
                    this.ConfigurationChangeEvent?.Invoke(this.ParentDevice, null);
                    var r = await this.ParentDevice.TheStats.ReadingCommand.GetReadings().ConfigureAwait(false);
                    if (r is not null) {
                        this.ParentDevice.TheStats.AddReading(r);
                        this.GetLiveReadingsEvent?.Invoke(this.ParentDevice, r);
                    }
                } catch (Exception ex) { 
                    Console.WriteLine("Readings timer exception " + ex.ToString());
                    o.ReadingsTimerStop();
                }
            }
        }


        #endregion


        #region Transcript Log

        private readonly object _TranscriptsLock = new();


        public event EventHandler<SerialTranscript>? TranscriptUpdateEvent;

        private readonly List<SerialTranscript> _TranscriptLog = new();

        public ReadOnlyCollection<SerialTranscript> TranscriptLog { 
            get {
                lock (_TranscriptsLock) {
                    return new ReadOnlyCollection<SerialTranscript>(_TranscriptLog);
                }
            } 
        }

        public void AddToTrascript(string log, bool outbound) {
            var logItem = new SerialTranscript(log, outbound);
            lock (_TranscriptsLock) {
                _TranscriptLog.Insert(0, logItem);
            }
            TranscriptUpdateEvent?.Invoke(this.ParentDevice, logItem);
        }


        public string LogWholeTranscriptAsString(bool useTimestamp = false) {
            SerialTranscript.UseTimestamp = useTimestamp;
            var s = string.Empty;
            foreach (var li in _TranscriptLog) {
                s += li.ToString() + Environment.NewLine;
            }
            return s;
        }

        public void ClearTranscript() {
            lock (_TranscriptsLock) {
                _TranscriptLog.Clear();
            }
        }

        #endregion
    }
}
