
namespace GPMLink {
    partial class DeviceSetupForm {
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPAddressTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.VoltageRangeComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentRangeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CF6ARadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentAutoRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.VoltageAutoRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.CF6RadioButton = new System.Windows.Forms.RadioButton();
            this.CF3RadioButton = new System.Windows.Forms.RadioButton();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeviceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GPMLink.Properties.Resources.gpm_8310_128;
            this.pictureBox1.Location = new System.Drawing.Point(26, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 106);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label1.Location = new System.Drawing.Point(215, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP ADDRESS:";
            // 
            // IPAddressTextBox
            // 
            this.IPAddressTextBox.BackColor = System.Drawing.Color.White;
            this.IPAddressTextBox.Font = new System.Drawing.Font("Bahnschrift", 21F);
            this.IPAddressTextBox.ForeColor = System.Drawing.Color.Black;
            this.IPAddressTextBox.Location = new System.Drawing.Point(316, 25);
            this.IPAddressTextBox.MaxLength = 15;
            this.IPAddressTextBox.Name = "IPAddressTextBox";
            this.IPAddressTextBox.Size = new System.Drawing.Size(218, 41);
            this.IPAddressTextBox.TabIndex = 2;
            this.IPAddressTextBox.Text = "10.0.11.83";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.White;
            this.SaveButton.Font = new System.Drawing.Font("Bahnschrift", 8F);
            this.SaveButton.ForeColor = System.Drawing.Color.Black;
            this.SaveButton.Location = new System.Drawing.Point(394, 402);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 36);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save As Defaults";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // VoltageRangeComboBox
            // 
            this.VoltageRangeComboBox.FormattingEnabled = true;
            this.VoltageRangeComboBox.Location = new System.Drawing.Point(190, 96);
            this.VoltageRangeComboBox.Name = "VoltageRangeComboBox";
            this.VoltageRangeComboBox.Size = new System.Drawing.Size(150, 33);
            this.VoltageRangeComboBox.TabIndex = 4;
            this.VoltageRangeComboBox.Text = "Auto";
            this.VoltageRangeComboBox.SelectionChangeCommitted += new System.EventHandler(this.VoltageRangeComboBox_SelectionChangeCommitted);
            // 
            // CurrentRangeComboBox
            // 
            this.CurrentRangeComboBox.FormattingEnabled = true;
            this.CurrentRangeComboBox.Location = new System.Drawing.Point(190, 137);
            this.CurrentRangeComboBox.Name = "CurrentRangeComboBox";
            this.CurrentRangeComboBox.Size = new System.Drawing.Size(150, 33);
            this.CurrentRangeComboBox.TabIndex = 5;
            this.CurrentRangeComboBox.Text = "Auto";
            this.CurrentRangeComboBox.SelectionChangeCommitted += new System.EventHandler(this.CurrentRangeComboBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label2.Location = new System.Drawing.Point(33, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "VOLTAGE RANGE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label3.Location = new System.Drawing.Point(28, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "CURRENT RANGE:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.groupBox1.Controls.Add(this.CF6ARadioButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CurrentAutoRangeCheckBox);
            this.groupBox1.Controls.Add(this.VoltageAutoRangeCheckBox);
            this.groupBox1.Controls.Add(this.CF6RadioButton);
            this.groupBox1.Controls.Add(this.CF3RadioButton);
            this.groupBox1.Controls.Add(this.VoltageRangeComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CurrentRangeComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(26, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 194);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEFAULT RANGES";
            // 
            // CF6ARadioButton
            // 
            this.CF6ARadioButton.AutoSize = true;
            this.CF6ARadioButton.Location = new System.Drawing.Point(358, 42);
            this.CF6ARadioButton.Name = "CF6ARadioButton";
            this.CF6ARadioButton.Size = new System.Drawing.Size(55, 29);
            this.CF6ARadioButton.TabIndex = 13;
            this.CF6ARadioButton.TabStop = true;
            this.CF6ARadioButton.Text = "6A";
            this.CF6ARadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label5.Location = new System.Drawing.Point(49, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "CREST FACTOR:";
            // 
            // CurrentAutoRangeCheckBox
            // 
            this.CurrentAutoRangeCheckBox.AutoSize = true;
            this.CurrentAutoRangeCheckBox.Location = new System.Drawing.Point(358, 142);
            this.CurrentAutoRangeCheckBox.Name = "CurrentAutoRangeCheckBox";
            this.CurrentAutoRangeCheckBox.Size = new System.Drawing.Size(82, 29);
            this.CurrentAutoRangeCheckBox.TabIndex = 11;
            this.CurrentAutoRangeCheckBox.Text = "AUTO";
            this.CurrentAutoRangeCheckBox.UseVisualStyleBackColor = true;
            this.CurrentAutoRangeCheckBox.CheckedChanged += new System.EventHandler(this.CurrentAutoRangeCheckBox_CheckedChanged);
            // 
            // VoltageAutoRangeCheckBox
            // 
            this.VoltageAutoRangeCheckBox.AutoSize = true;
            this.VoltageAutoRangeCheckBox.Location = new System.Drawing.Point(358, 99);
            this.VoltageAutoRangeCheckBox.Name = "VoltageAutoRangeCheckBox";
            this.VoltageAutoRangeCheckBox.Size = new System.Drawing.Size(82, 29);
            this.VoltageAutoRangeCheckBox.TabIndex = 10;
            this.VoltageAutoRangeCheckBox.Text = "AUTO";
            this.VoltageAutoRangeCheckBox.UseVisualStyleBackColor = true;
            this.VoltageAutoRangeCheckBox.CheckedChanged += new System.EventHandler(this.VoltageAutoRangeCheckBox_CheckedChanged);
            // 
            // CF6RadioButton
            // 
            this.CF6RadioButton.AutoSize = true;
            this.CF6RadioButton.Location = new System.Drawing.Point(273, 42);
            this.CF6RadioButton.Name = "CF6RadioButton";
            this.CF6RadioButton.Size = new System.Drawing.Size(66, 29);
            this.CF6RadioButton.TabIndex = 9;
            this.CF6RadioButton.TabStop = true;
            this.CF6RadioButton.Text = "CF6";
            this.CF6RadioButton.UseVisualStyleBackColor = true;
            // 
            // CF3RadioButton
            // 
            this.CF3RadioButton.AutoSize = true;
            this.CF3RadioButton.Checked = true;
            this.CF3RadioButton.Location = new System.Drawing.Point(190, 42);
            this.CF3RadioButton.Name = "CF3RadioButton";
            this.CF3RadioButton.Size = new System.Drawing.Size(66, 29);
            this.CF3RadioButton.TabIndex = 8;
            this.CF3RadioButton.TabStop = true;
            this.CF3RadioButton.Text = "CF3";
            this.CF3RadioButton.UseVisualStyleBackColor = true;
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Location = new System.Drawing.Point(316, 145);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(150, 33);
            this.ModeComboBox.TabIndex = 10;
            this.ModeComboBox.Text = "AC/RMS";
            this.ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.ModeComboBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label4.Location = new System.Drawing.Point(192, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "DEFAULT MODE:";
            // 
            // NameTextbox
            // 
            this.NameTextbox.BackColor = System.Drawing.Color.White;
            this.NameTextbox.Font = new System.Drawing.Font("Bahnschrift", 21F);
            this.NameTextbox.ForeColor = System.Drawing.Color.Black;
            this.NameTextbox.Location = new System.Drawing.Point(316, 80);
            this.NameTextbox.MaxLength = 255;
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(218, 41);
            this.NameTextbox.TabIndex = 14;
            this.NameTextbox.Text = "GPM8310";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(203, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "DEVICE NAME:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.DeviceStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // DeviceStatusLabel
            // 
            this.DeviceStatusLabel.BackColor = System.Drawing.Color.White;
            this.DeviceStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.DeviceStatusLabel.Name = "DeviceStatusLabel";
            this.DeviceStatusLabel.Size = new System.Drawing.Size(82, 17);
            this.DeviceStatusLabel.Text = "Disconnected.";
            // 
            // DeviceSetupForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(548, 472);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ModeComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.IPAddressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GwINSTEK GPM-8310 SETUP";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.DeviceSetup_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPAddressTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox VoltageRangeComboBox;
        private System.Windows.Forms.ComboBox CurrentRangeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CF6RadioButton;
        private System.Windows.Forms.RadioButton CF3RadioButton;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CurrentAutoRangeCheckBox;
        private System.Windows.Forms.CheckBox VoltageAutoRangeCheckBox;
        private System.Windows.Forms.RadioButton CF6ARadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DeviceStatusLabel;
    }
}