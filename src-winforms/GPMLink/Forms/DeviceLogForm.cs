using GPMLib;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPMLink {
    public partial class DeviceLogForm : Form, IParentDevice {

        public GPMDevice ParentDevice { get; private set; }

        public DeviceLogForm(GPMDevice d) {
            InitializeComponent();
            this.ParentDevice = d;
        }

        private void DeviceLogForm_Load(object sender, EventArgs e) {
            this.fastDataListView1.SetObjects(ParentDevice.NetworkLink.TranscriptLog);
            ParentDevice.NetworkLink.TranscriptUpdateEvent += TheDevice_TranscriptUpdateEvent;
        }

        private void TheDevice_TranscriptUpdateEvent(object sender, SerialTranscript e) {
            void ProcessTranscript() {
                var l = new List<SerialTranscript> {
                    e
                };
                this.fastDataListView1.InsertObjects(0, l);
            }
            try {
                if (InvokeRequired) {
                    this.Invoke(new Action(() => ProcessTranscript()));
                } else {
                    ProcessTranscript();
                }
            } catch { }
        }

        private void ClearLogButton_Click(object sender, EventArgs e) {
            this.fastDataListView1.ClearObjects();
            this.ParentDevice.NetworkLink.ClearTranscript();
        }

        private void DeviceLogForm_FormClosing(object sender, FormClosingEventArgs e) {
            ParentDevice.NetworkLink.TranscriptUpdateEvent -= TheDevice_TranscriptUpdateEvent;

        }

        private void SendButton_Click(object sender, EventArgs e) {
            var s = this.CmdTextbox.Text;
            if (string.IsNullOrWhiteSpace(s)) { return; }
            this.ParentDevice.NetworkLink.SendToDevice(s).ConfigureAwait(false);
        }
    }
}
