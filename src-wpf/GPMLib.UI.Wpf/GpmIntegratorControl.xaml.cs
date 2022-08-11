using GPMLib.Netcore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static GPMLib.Netcore.INTEGrator;

#nullable enable

namespace GPMLib.UI.Wpf {
    /// <summary>
    /// Interaction logic for GpmIntegratorControl.xaml
    /// </summary>
    public partial class GpmIntegratorControl : UserControl, IParentDevice {

        public static string IntegratorResetUICommandString(INTEGrator i) {
            string s = string.Empty;
            switch (i.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    s = "OFFLINE";
                    break;
                case GPMIntegratorStatusEnum.Error:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Start:
                    s = "STOP";
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    s = "RESET";
                    break;
            }
            return s;
        }

        public static string IntegratorStatusUIString(INTEGrator i) {
            string s = string.Empty;
            switch (i.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    s = "OFFLINE";
                    break;
                case GPMIntegratorStatusEnum.Error:
                    s = "ERROR";
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    s = "READY";
                    break;
                case GPMIntegratorStatusEnum.Start:
                    s = "RUNNING";
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    s = "PAUSED";
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    s = "STOPPED";
                    break;
            }
            return s;
        }

        GPMDevice? _ParentDevice;
        public GPMDevice? ParentDevice {
            get => _ParentDevice;
            set {
                _ParentDevice = value;
                if (_ParentDevice is null) { return; }
                _ParentDevice.TheStats.IntegratorCommand.HasChangedEvent += (object? sender, INTEGrator e) => {
                    Dispatcher.Invoke(new Action(() => {
                        if (sender is not GPMDevice pd) { return; }
                        IntegratorResetButton.IsEnabled = pd.IsConnected && e.IntegratorStatus != GPMIntegratorStatusEnum.Start;
                        IntegratorStartButton.Content = e.StartStopButtonText;
                        IntegratorResetButton.Content = IntegratorResetUICommandString(e);
                        if (pd.IsConnected) {
                            this.IntegratorTitleLabel.Content = "INTEGRATOR " + IntegratorStatusUIString(e);
                        } else {
                            this.IntegratorTitleLabel.Content = "OFFLINE";
                        }
                    }));

                };

            }
        }

        public GpmIntegratorControl() {
            InitializeComponent();
            // INTEGRATOR START
            this.IntegratorStartButton.Click += (s, e) => {
                IntegratorStartStopClick();
            };
            // INTEGRATOR STOP
            this.IntegratorResetButton.Click += (s, e) => {
                _ = IntegratorReset(askConfirmation: true);
            };
        }

        void IntegratorStartStopClick() {
            if (_ParentDevice is null) { return; }

            async Task Start(bool resetIntegrator) {
                if (resetIntegrator) {
                    await _ParentDevice.TheStats.IntegratorCommand.ResetIntegrator().ConfigureAwait(false);
                }
                await _ParentDevice.TheStats.IntegratorCommand.StartIntegrator().ConfigureAwait(false);
            }

            if (_ParentDevice.IsDisconnected) {
                _ParentDevice.NetworkLink.Connect().ConfigureAwait(false);
                return;
            }

            switch (_ParentDevice.TheStats.IntegratorCommand.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    _ = _ParentDevice.NetworkLink.Connect(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Error:
                    _ = Start(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    _ = Start(false).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Start:
                    _ = IntegratorStop(askConfirmation: false);
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    _ = Start(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    _ = Start(true).ConfigureAwait(false);
                    break;
            }

            if (_ParentDevice.TheStats.IntegratorCommand.IntegratorStatus == GPMIntegratorStatusEnum.Start) {
                _ = IntegratorStop(askConfirmation: false);
            } else {
                _ = Start(false);
            }
        }

        async Task<bool> IntegratorStop(bool askConfirmation = true) {
            if (_ParentDevice is null) { return false; }

            var result = MessageBoxResult.OK;
            if (askConfirmation) {
                result = MessageBox.Show("Stop logging?", "Logging", MessageBoxButton.OKCancel);
            }
            if (result == MessageBoxResult.OK) {
                await _ParentDevice.TheStats.IntegratorCommand.StopIntegrator();
                return true;
            }
            return false;
        }

        async Task IntegratorReset(bool askConfirmation = true) {
            if (_ParentDevice is null) { return; }

            var result = MessageBoxResult.OK;
            if (askConfirmation) {
                result = MessageBox.Show("Clear all collected data and reset integrator?", "Integrator", MessageBoxButton.OKCancel);
            }
            if (result == MessageBoxResult.OK) {
                //_ParentDevice.NetworkLink.ReadingsTimerStop();
                await _ParentDevice.TheStats.IntegratorCommand.ResetIntegrator();
                //_ParentDevice.NetworkLink.ReadingsTimerStart();

            }
        }
    }
}
