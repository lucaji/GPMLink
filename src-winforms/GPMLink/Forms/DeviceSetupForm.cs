using GPMLib;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GPMLink {
    public partial class DeviceSetupForm : Form, IParentDevice {

        public GPMDevice ParentDevice { get; set; }


        public void ReceivedConfiguration(GPMDevice d) {

        }


        public DeviceSetupForm(GPMDevice d) {
            this.ParentDevice = d;
            InitializeComponent();

            foreach (var m in MODE.InputModeListList) {
                this.ModeComboBox.Items.Add(m.Item2);
            }

            foreach (var m in CURRent.CurrentRangesList) {
                this.CurrentRangeComboBox.Items.Add(m.Item2);
            }
            this.CurrentRangeComboBox.Items.Add("Auto");


            foreach (var m in VOLTage.VoltageRangesList) {
                this.VoltageRangeComboBox.Items.Add(m.Item2);
            }
            this.VoltageRangeComboBox.Items.Add("Auto");
        }

        async Task GetFromDevice() {
            if (ParentDevice.IsDisconnected) { return; }
            _ = await ParentDevice.DeviceInputs.DeviceInputMode.GetInputMode();
            var modeName = ParentDevice.DeviceInputs.DeviceInputMode.ToString();
            this.ModeComboBox.SetText(modeName);

            var crmode = await ParentDevice.DeviceInputs.DeviceCrestFactor.GetCrestFactorMode();
            //CF3RadioButton.SetChecked(crmode == CrestFactorEnum.CF3);
            //CF6RadioButton.SetChecked(crmode == CrestFactorEnum.CF6);
            //CF6ARadioButton.SetChecked(crmode == CrestFactorEnum.CF6A);

            var vr = await ParentDevice.DeviceInputs.DeviceVoltageRange.GetDeviceVoltageRange();
            var vrName = ParentDevice.DeviceInputs.DeviceVoltageRange.ToString();
            this.VoltageRangeComboBox.SetText(vrName);
            this.VoltageAutoRangeCheckBox.SetChecked(ParentDevice.DeviceInputs.DeviceVoltageRange.IsVoltageRangeAuto);

            var cr = await ParentDevice.DeviceInputs.DeviceCurrentRange.GetDeviceCurrentRange();
            var crName = ParentDevice.DeviceInputs.DeviceCurrentRange.ToString();
            this.CurrentRangeComboBox.SetText(crName);
            this.CurrentAutoRangeCheckBox.SetChecked(ParentDevice.DeviceInputs.DeviceCurrentRange.IsCurrentRangeAuto);
        }

        void UpdateIpAddressField() {
           // IPAddressTextBox.Text = Properties.Settings.Default.KnownDeviceList;
        }

        void UpdateUI() {
            this.NameTextbox.Text = ParentDevice.DeviceName;
            this.IPAddressTextBox.Text = ParentDevice.DeviceIPAddress;
            
            this.ModeComboBox.Text = ParentDevice.DeviceInputModeString;
            this.VoltageRangeComboBox.Text = ParentDevice.DeviceVoltageRangeString;
            this.CurrentRangeComboBox.Text = ParentDevice.DeviceCurrentRangeString;

            this.VoltageAutoRangeCheckBox.Checked = ParentDevice.DeviceInputs.DeviceVoltageRange.IsVoltageRangeAuto;
            this.CurrentAutoRangeCheckBox.Checked = ParentDevice.DeviceInputs.DeviceCurrentRange.IsCurrentRangeAuto;

            this.CF3RadioButton.Checked = ParentDevice.DeviceCrestFactorModeString.Equals(this.CF3RadioButton.Text);
            this.CF6RadioButton.Checked = ParentDevice.DeviceCrestFactorModeString.Equals(this.CF6RadioButton.Text);
            this.CF6ARadioButton.Checked = ParentDevice.DeviceCrestFactorModeString.Equals(this.CF6ARadioButton.Text);

            this.DeviceStatusLabel.Text = ParentDevice.DeviceStatusString;

            UpdateIpAddressField();
        }

        private void DeviceSetup_Activated(object sender, EventArgs e) {
            UpdateUI();
        }

        private void ModeComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            _ = ParentDevice.DeviceInputs.DeviceInputMode.SetDeviceInputMode(ModeComboBox.SelectedItem.ToString());
            _ = GetFromDevice();
        }

        private void VoltageAutoRangeCheckBox_CheckedChanged(object sender, EventArgs e) {
            _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRangeAuto(VoltageAutoRangeCheckBox.Checked);
            _ = GetFromDevice();
        }

        private void CurrentAutoRangeCheckBox_CheckedChanged(object sender, EventArgs e) {
            _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRangeAuto(CurrentAutoRangeCheckBox.Checked);
            _ = GetFromDevice();
        }

        private void VoltageRangeComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRange(VoltageRangeComboBox.SelectedItem.ToString());
            _ = GetFromDevice();
        }

        private void CurrentRangeComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRange(CurrentRangeComboBox.SelectedItem.ToString());
            _ = GetFromDevice();
        }

        private void ConnectButton_Click(object sender, EventArgs e) {
            _ = ParentDevice.NetworkLink.ToggleConnection();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (ConnectionManager.IPAddressInvalid(this.IPAddressTextBox.Text)) {
                this.IPAddressTextBox.Text = "127.0.0.1";
            } else {
                var n = CleanUpName(this.NameTextbox.Text);
                ParentDevice.DeviceName = n;
                ParentDevice.DeviceIPAddress = this.IPAddressTextBox.Text;
                //ParentDevice.DeviceForm?.SetWindowTitleForDevice();

                SettingsManager.Singleton.UpdateFavouriteDeviceListStoreWith(ParentDevice.DeviceIPAddress, ParentDevice.DeviceName);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        string CleanUpName(string n) {
            n = n.Replace(";", "");
            return n;
        }
    }
}
