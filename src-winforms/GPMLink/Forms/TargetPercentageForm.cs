using GPMLib;

using System;
using System.Windows.Forms;

namespace GPMLink {
    public partial class TargetPercentageForm : Form {

        public double Percentage { get => (double)this.numericUpDown1.Value / 100.0; }
        public TargetPercentageForm() {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            var success = SettingsManager.Singleton.UpdateTargetPercentagesListStoreWith(this.Percentage);
            if (success) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else { 
                errorProvider1.SetError(numericUpDown1, "Value already existing.");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            CheckValueExisting();
        }

     

        private void TargetPercentageForm_Activated(object sender, EventArgs e) {
            CheckValueExisting();
        }


        void CheckValueExisting() {
            var exists = SettingsManager.Singleton.PowerTargetValueByPercentage(this.Percentage) is not null;
            if (exists) {
                errorProvider1.SetError(numericUpDown1, "Value already existing.");
            } else {
                errorProvider1.Clear();
            }
        }
    }
}
