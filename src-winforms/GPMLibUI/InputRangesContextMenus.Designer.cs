
namespace GPMLib.UI.Winforms {
    partial class InputRangesContextMenus {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.CurrentRangeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VoltageRangeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            // 
            // CurrentRangeContextMenuStrip
            // 
            this.CurrentRangeContextMenuStrip.Name = "contextMenuStrip1";
            this.CurrentRangeContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // VoltageRangeContextMenuStrip
            // 
            this.VoltageRangeContextMenuStrip.Name = "contextMenuStrip1";

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip CurrentRangeContextMenuStrip;
        public System.Windows.Forms.ContextMenuStrip VoltageRangeContextMenuStrip;
    }
}
