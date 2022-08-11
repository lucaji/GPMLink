using GPMLib.Netcore;

using System.Windows;

#nullable enable

namespace GPMLib.UI.Wpf {
    /// <summary>
    /// Interaction logic for DevicePropertiesWindow.xaml
    /// </summary>
    public partial class GpmDevicePropertiesWindow : Window, IParentDevice {

        public GPMDevice ParentDevice { get; set; }

        public string DeviceIpAddress { get { return this.IPAddressTextBox.Text; } }
        public string DeviceName { get { return this.NameTextbox.Text; } }

        public GpmDevicePropertiesWindow(GPMDevice pd) {
            this.ParentDevice = pd;
            InitializeComponent();

            this.NameTextbox.PreviewTextInput += (s, e) => {
                _ = ValidateName(e.Text);
            };

            this.IPAddressTextBox.PreviewTextInput += (s, e) => {
                _ = ValidateAddress(e.Text);
            };

            this.Loaded += (s, e) => {
                this.IPAddressTextBox.Text = pd.DeviceIPAddress;
                this.NameTextbox.Text = pd.DeviceName;
            };

            this.Activated += (s, e) => {

            };

            this.Closing += (s, e) => {
                this.DialogResult = Validate();

            };

            this.OKButton.Click += (s, e) => {
                if (Validate()) {
                    this.Close();
                }
            };
        }

        bool Validate() {
            var success = ValidateName(NameTextbox.Text);
            if (!success) { goto bail; }
            success = ValidateAddress(DeviceIpAddress);
            bail: return success;
        }

        private bool ValidateName(string? s) {
            var success = (s?.Length ?? 0) > 2;
            if (!success) {
                this.ErrorMessageLabel.Content = "The name must be at least 2 characters long.";
                goto bail;
            }
            success = (s?.Length ?? 0) < 20;
            if (!success) {
                this.ErrorMessageLabel.Content = "The name must be shorten than 20 characters.";
            }
            bail: if (success) {
                this.ErrorMessageLabel.Content = string.Empty;
            }
            return success;
        }

        bool ValidateAddress(string? s) {
            if (ConnectionManager.IPAddressInvalid(s)) {
                this.ErrorMessageLabel.Content = "The given IP address is not valid.";
                return false;
            } else {
                this.ErrorMessageLabel.Content = string.Empty;
                return true;
            }
        }

       
    }
}
