using GPMLib;

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable enable

namespace GPMLink {
    public partial class UserDevicesForm : Form {


        public UserDevicesForm() {
            InitializeComponent();
            this.AppVersionLabel.Text = Properties.Resources.FullVersionString;
        }

        private void KnownDevicesForm_Activated(object sender, EventArgs e) {
            ReloadList();

        }

        

        private void ReloadList() {
            var theList = SettingsManager.Singleton.FavouriteDevicesList;
            this.DevicesOlv.Objects = theList;

            if (theList.Count > 0) {
                this.DevicesOlv.SelectedIndex = 0;
            }
            
            UpdateConnectedButtonState();
        }



        GPMDevice? SelectedDevice {
            get {
                return this.DevicesOlv.SelectedObject as GPMDevice;
            }
        }

        void UpdateConnectedButtonState() {
            this.ConnectButton.Enabled = this.SelectedDevice is not null;
            this.ConnectButton.Text = this.SelectedDevice?.IsConnected ?? false ? "Disconnect" : "Connect";
        }

       

        private void UserDevicesForm_FormClosing(object sender, FormClosingEventArgs e) {
            //var theList = GPMSingleton.Instance.FavouriteDevicesList;
            //foreach (var d in theList) {
            //    if (d.IsConnected) {
            //        var result = MessageBox.Show(d.Name + " is currently connected. Do you want really to quit this application?", "Quit?", MessageBoxButtons.OKCancel);
            //        if (result != DialogResult.OK) { 
            //            e.Cancel = true;
            //            return;
            //        }
            //        return;
            //    }
            //}

        }

        private void DevicesOlv_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e) {
            var d = e.RowObject as GPMDevice;
            if (d is null) { return; }

        }

        void ShowDeviceForm() {
            //var f = this.SelectedDevice?.DeviceForm;
            //if (f is null) { return; }
            //f.Show();
        }

        private void DevicesOlv_MouseDoubleClick(object sender, MouseEventArgs e) {
            ShowDeviceForm();
        }

        private void ConnectButton_Click(object sender, EventArgs e) {
            ShowDeviceForm();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            ConnectButton_Click(sender, e);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e) {
            var d = GPMDevice.Factory("127.0.0.1", "Local");
            var f = new DeviceSetupForm(d);
            f.ShowDialog();
            ReloadList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.SelectedDevice is null) { return; }
            var f = new DeviceSetupForm(this.SelectedDevice);
            var result = f.ShowDialog();
            ReloadList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.SelectedDevice is null) { return; }
            var result = MessageBox.Show("Delete <" + this.SelectedDevice.ToString() + "> ?");
            if (result == DialogResult.Cancel) { return; }
            SettingsManager.Singleton.RemoveFavouriteDeviceFromStore(this.SelectedDevice.DeviceIPAddress);
            ReloadList();
        }

        private void AppVersionLabel_Click(object sender, EventArgs e) {
            
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            // addNewToolStripMenuItem.Enabled =
            editToolStripMenuItem.Enabled =
            deleteToolStripMenuItem.Enabled =
            setAsDefaultToolStripMenuItem.Enabled =
            connectToolStripMenuItem.Enabled = this.SelectedDevice is not null;

            setAsDefaultToolStripMenuItem.Checked = this.SelectedDevice?.IsDefault ?? false;
        }

        private void setAsDefaultToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.SelectedDevice is null) { return; }
            SettingsManager.Singleton.SetDeviceAsDefault(this.SelectedDevice);
        }
    }
}
