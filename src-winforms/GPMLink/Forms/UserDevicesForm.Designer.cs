
namespace GPMLink {
    partial class UserDevicesForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDevicesForm));
            this.DevicesOlv = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setAsDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.AppVersionLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesOlv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DevicesOlv
            // 
            this.DevicesOlv.AllColumns.Add(this.olvColumn1);
            this.DevicesOlv.AllColumns.Add(this.olvColumn2);
            this.DevicesOlv.AllColumns.Add(this.olvColumn3);
            this.DevicesOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DevicesOlv.CellEditUseWholeCell = false;
            this.DevicesOlv.CheckedAspectName = "";
            this.DevicesOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.DevicesOlv.ContextMenuStrip = this.contextMenuStrip1;
            this.DevicesOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.DevicesOlv.EmptyListMsg = "No favourite devices yet...";
            this.DevicesOlv.Font = new System.Drawing.Font("Bahnschrift", 16F);
            this.DevicesOlv.ForeColor = System.Drawing.Color.White;
            this.DevicesOlv.FullRowSelect = true;
            this.DevicesOlv.GridLines = true;
            this.DevicesOlv.HideSelection = false;
            this.DevicesOlv.Location = new System.Drawing.Point(204, 57);
            this.DevicesOlv.MultiSelect = false;
            this.DevicesOlv.Name = "DevicesOlv";
            this.DevicesOlv.OwnerDrawnHeader = true;
            this.DevicesOlv.PersistentCheckBoxes = false;
            this.DevicesOlv.RenderNonEditableCheckboxesAsDisabled = true;
            this.DevicesOlv.SelectAllOnControlA = false;
            this.DevicesOlv.ShowGroups = false;
            this.DevicesOlv.ShowImagesOnSubItems = true;
            this.DevicesOlv.Size = new System.Drawing.Size(448, 167);
            this.DevicesOlv.TabIndex = 0;
            this.DevicesOlv.TriggerCellOverEventsWhenOverHeader = false;
            this.DevicesOlv.UseCompatibleStateImageBehavior = false;
            this.DevicesOlv.UseHotControls = false;
            this.DevicesOlv.UseSubItemCheckBoxes = true;
            this.DevicesOlv.View = System.Windows.Forms.View.Details;
            this.DevicesOlv.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.DevicesOlv_CellEditFinished);
            this.DevicesOlv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DevicesOlv_MouseDoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Address";
            this.olvColumn1.Text = "ADDRESS";
            this.olvColumn1.Width = 145;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.Text = "NAME";
            this.olvColumn2.Width = 202;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "IsDefault";
            this.olvColumn3.CheckBoxes = true;
            this.olvColumn3.Text = "Default";
            this.olvColumn3.Width = 81;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator1,
            this.setAsDefaultToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 126);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // setAsDefaultToolStripMenuItem
            // 
            this.setAsDefaultToolStripMenuItem.Name = "setAsDefaultToolStripMenuItem";
            this.setAsDefaultToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.setAsDefaultToolStripMenuItem.Text = "Set as default";
            this.setAsDefaultToolStripMenuItem.Click += new System.EventHandler(this.setAsDefaultToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addNewToolStripMenuItem.Text = "Add New...";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "Delete...";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "GPM-8310 LAN DEVICES";
            // 
            // AppVersionLabel
            // 
            this.AppVersionLabel.AutoSize = true;
            this.AppVersionLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.AppVersionLabel.Location = new System.Drawing.Point(12, 278);
            this.AppVersionLabel.Name = "AppVersionLabel";
            this.AppVersionLabel.Size = new System.Drawing.Size(38, 18);
            this.AppVersionLabel.TabIndex = 5;
            this.AppVersionLabel.Text = "label2";
            this.AppVersionLabel.Click += new System.EventHandler(this.AppVersionLabel_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Bahnschrift", 16F);
            this.ConnectButton.ForeColor = System.Drawing.Color.Black;
            this.ConnectButton.Location = new System.Drawing.Point(506, 243);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(146, 39);
            this.ConnectButton.TabIndex = 7;
            this.ConnectButton.Text = "Open";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GPMLink.Properties.Resources.gpm_8310_128;
            this.pictureBox1.Location = new System.Drawing.Point(28, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 100);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // UserDevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(675, 303);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AppVersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DevicesOlv);
            this.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDevicesForm";
            this.Text = "GPM8310 NETWORK";
            this.Activated += new System.EventHandler(this.KnownDevicesForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserDevicesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DevicesOlv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView DevicesOlv;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AppVersionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.ToolStripMenuItem setAsDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}