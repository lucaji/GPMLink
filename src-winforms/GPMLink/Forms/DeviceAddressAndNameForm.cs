
using GPMLib;

using System;
using System.Windows.Forms;

namespace GPMLink {
    public partial class DeviceAddressAndNameForm : Form, IParentDevice {

        public string DeviceIpAddress { get { return this.IPAddressTextBox.Text; } }
        public string DeviceName { get { return this.NameTextbox.Text; } }

        public GPMDevice ParentDevice { get; private set; }

        public DeviceAddressAndNameForm(GPMDevice dm) {
            this.ParentDevice = dm;
            InitializeComponent();

            this.IPAddressTextBox.Validating += (s, e) => {
                if (s is not TextBox tb) { return; }
                ValidateAddressField(tb.Text);
            };

            this.NameTextbox.Validating += (s, e) => {
                if (s is not TextBox tb) { return; }
                ValidateNameField(tb.Text);
            };

            this.Load += (s, e) => {
                this.IPAddressTextBox.Text = dm.DeviceIPAddress;
                this.NameTextbox.Text = dm.DeviceName;
            };

            this.Activated += (s, e) => {
                this.DialogResult = DialogResult.None;
            };

            this.FormClosing += (s, e) => {
                if (this.DialogResult == DialogResult.None) {
                    e.Cancel = true;
                }
            };
        }

        bool ValidateAddressField(string s = null) {
            if (s is null) { s = DeviceIpAddress; }
            if (ConnectionManager.IPAddressInvalid(s)) {
                errorProvider1.SetError(this.IPAddressTextBox, "IP Address not valid");
                return false;
            }
            return true;
        }

        bool ValidateNameField(string s = null) {
            if (s is null) { s = DeviceName; }
            var success = s.Length > 0 && s.Length < 33;
            if (!success) {
                errorProvider1.SetError(this.NameTextbox, s.Length < 1 ? "Enter at least one letter" : "No longer than 32 characters");
            }
            return success;
        }

        private void ButtonOK_Click(object sender, EventArgs e) {
            var bValidAddress = ValidateAddressField();
            var bValidName = ValidateNameField();
            if (bValidAddress && bValidName) {
                this.ParentDevice.DeviceName = this.DeviceName;
                this.ParentDevice.DeviceIPAddress = this.DeviceIpAddress;
                if (this.ParentDevice.IsLocal) {
                    errorProvider1.SetError(this.IPAddressTextBox, "Local IP address not valid.");
                } else {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
