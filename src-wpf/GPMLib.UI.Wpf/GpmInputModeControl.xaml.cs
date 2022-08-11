
using GPMLib.Netcore;

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

#nullable enable

namespace GPMLib.UI.Wpf {
    /// <summary>
    /// Interaction logic for InputModeControl.xaml
    /// </summary>
    public partial class GpmInputModeControl : UserControl, IParentDevice {

        GpmTranscriptWindow? transcriptWindow;

        public GpmInputModeControl() {
            InitializeComponent();
            this.Loaded += (s, e) => {
                this.InputModeACButton.Click += InputModeButtons_Click;
                this.InputModeDCButton.Click += InputModeButtons_Click;
                this.InputModeACDCButton.Click += InputModeButtons_Click;

                this.TranscriptButton.Click += (s, e) => {
                    if (transcriptWindow is null) {
                        transcriptWindow = new(_ParentDevice!);
                    }
                    transcriptWindow.Show();
                };
            };
        }

        private GPMDevice? _ParentDevice;
        public GPMDevice? ParentDevice {
            get => _ParentDevice;
            set {
                _ParentDevice = value;
                if (_ParentDevice is null) { return; };
                _ParentDevice.NetworkLink.ConnectionStateChangedEvent += (s, e) => {
                    this.DetailLabel.Text = e ? "Connected." : "Not Connected.";
                    this.ConnectButtonText.Text = e ? "DISCONNECT" : "CONNECTED";
                    this.ConnectButton.IsChecked = e;
                };

                _ParentDevice.DeviceInputs.InputMode.NotifyChangedEvent += (object? sender, BaseCommand e) => {
                    if (e is MODE modeCmd) {
                        Dispatcher.Invoke(new Action(() => {
                            InputModeACButton.IsChecked = modeCmd.InputMode == MODE.MODEInputEnum.InputModeAC;
                            ACButtonLabel.Foreground = new SolidColorBrush(modeCmd.InputMode == MODE.MODEInputEnum.InputModeAC ? Colors.Orange : Colors.Black);
                            
                            InputModeDCButton.IsChecked = modeCmd.InputMode == MODE.MODEInputEnum.InputModeDC;
                            DCButtonLabel.Foreground = new SolidColorBrush(modeCmd.InputMode == MODE.MODEInputEnum.InputModeDC ? Colors.YellowGreen : Colors.Black);

                            InputModeACDCButton.IsChecked = modeCmd.InputMode == MODE.MODEInputEnum.InputModeACDC;
                            ACDCButtonLabel.Foreground = new SolidColorBrush(modeCmd.InputMode == MODE.MODEInputEnum.InputModeACDC ? Colors.Blue : Colors.Black);
                        }));
                    }
                };

                this.ConnectButton.Click += (s, e) => {
                    if (_ParentDevice is null) { return; }
                    _ParentDevice.NetworkLink.ToggleConnection().ConfigureAwait(false);
                };

            }
        }

        
        private void InputModeButtons_Click(object sender, EventArgs e) {
            if (_ParentDevice is null) { return; }
            if (_ParentDevice.IsIntegrating) {
                MessageBox.Show("Reset the Integrator first.");
                return;
            }
            if (sender is not ToggleButton c) { return; }
            _ = _ParentDevice.DeviceInputs.DeviceInputMode.SetDeviceInputMode(c.Tag.ToString());
        }
    }
}
