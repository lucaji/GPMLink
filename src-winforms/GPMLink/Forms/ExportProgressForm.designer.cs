namespace GPMLink {
    partial class ExportProgressForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelMessage = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ButtonCancelExport = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExportAsExcelRadioButton = new System.Windows.Forms.RadioButton();
            this.ExportAsCsvRadioButton = new System.Windows.Forms.RadioButton();
            this.ExportBothRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportSelectedRangeRadioButton = new System.Windows.Forms.RadioButton();
            this.ExportFullDataSetRadioButton = new System.Windows.Forms.RadioButton();
            this.DestinationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelMessage
            // 
            this.LabelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelMessage.AutoSize = true;
            this.LabelMessage.Location = new System.Drawing.Point(12, 193);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(41, 14);
            this.LabelMessage.TabIndex = 0;
            this.LabelMessage.Text = "Ready.";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(12, 210);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(378, 25);
            this.ProgressBar1.TabIndex = 1;
            // 
            // ButtonCancelExport
            // 
            this.ButtonCancelExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancelExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancelExport.Location = new System.Drawing.Point(303, 257);
            this.ButtonCancelExport.Name = "ButtonCancelExport";
            this.ButtonCancelExport.Size = new System.Drawing.Size(87, 25);
            this.ButtonCancelExport.TabIndex = 2;
            this.ButtonCancelExport.Text = "Cancel";
            this.ButtonCancelExport.UseVisualStyleBackColor = true;
            this.ButtonCancelExport.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BrowseButton
            // 
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Location = new System.Drawing.Point(12, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(87, 25);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Save To...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExportAsExcelRadioButton
            // 
            this.ExportAsExcelRadioButton.AutoSize = true;
            this.ExportAsExcelRadioButton.Checked = true;
            this.ExportAsExcelRadioButton.Image = global::GPMLink.Properties.Resources.ExportToExcel_16x;
            this.ExportAsExcelRadioButton.Location = new System.Drawing.Point(24, 26);
            this.ExportAsExcelRadioButton.MinimumSize = new System.Drawing.Size(0, 23);
            this.ExportAsExcelRadioButton.Name = "ExportAsExcelRadioButton";
            this.ExportAsExcelRadioButton.Size = new System.Drawing.Size(123, 23);
            this.ExportAsExcelRadioButton.TabIndex = 5;
            this.ExportAsExcelRadioButton.TabStop = true;
            this.ExportAsExcelRadioButton.Text = "Export as Excel";
            this.ExportAsExcelRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportAsExcelRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportAsExcelRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportAsCsvRadioButton
            // 
            this.ExportAsCsvRadioButton.AutoSize = true;
            this.ExportAsCsvRadioButton.Image = global::GPMLink.Properties.Resources.ResultToCSV_16x;
            this.ExportAsCsvRadioButton.Location = new System.Drawing.Point(24, 55);
            this.ExportAsCsvRadioButton.MinimumSize = new System.Drawing.Size(0, 23);
            this.ExportAsCsvRadioButton.Name = "ExportAsCsvRadioButton";
            this.ExportAsCsvRadioButton.Size = new System.Drawing.Size(116, 23);
            this.ExportAsCsvRadioButton.TabIndex = 6;
            this.ExportAsCsvRadioButton.Text = "Export as CSV";
            this.ExportAsCsvRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportAsCsvRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportAsCsvRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportBothRadioButton
            // 
            this.ExportBothRadioButton.AutoSize = true;
            this.ExportBothRadioButton.Image = global::GPMLink.Properties.Resources.Export_16x;
            this.ExportBothRadioButton.Location = new System.Drawing.Point(24, 84);
            this.ExportBothRadioButton.MinimumSize = new System.Drawing.Size(0, 23);
            this.ExportBothRadioButton.Name = "ExportBothRadioButton";
            this.ExportBothRadioButton.Size = new System.Drawing.Size(105, 23);
            this.ExportBothRadioButton.TabIndex = 7;
            this.ExportBothRadioButton.Text = "Export both";
            this.ExportBothRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportBothRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportBothRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportBothRadioButton);
            this.groupBox1.Controls.Add(this.ExportAsExcelRadioButton);
            this.groupBox1.Controls.Add(this.ExportAsCsvRadioButton);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 122);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Format";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportSelectedRangeRadioButton);
            this.groupBox2.Controls.Add(this.ExportFullDataSetRadioButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(204, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 122);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dataset";
            // 
            // ExportSelectedRangeRadioButton
            // 
            this.ExportSelectedRangeRadioButton.AutoSize = true;
            this.ExportSelectedRangeRadioButton.Checked = true;
            this.ExportSelectedRangeRadioButton.Image = global::GPMLink.Properties.Resources.RectangularSelection_16x;
            this.ExportSelectedRangeRadioButton.Location = new System.Drawing.Point(24, 26);
            this.ExportSelectedRangeRadioButton.MinimumSize = new System.Drawing.Size(0, 23);
            this.ExportSelectedRangeRadioButton.Name = "ExportSelectedRangeRadioButton";
            this.ExportSelectedRangeRadioButton.Size = new System.Drawing.Size(121, 23);
            this.ExportSelectedRangeRadioButton.TabIndex = 5;
            this.ExportSelectedRangeRadioButton.TabStop = true;
            this.ExportSelectedRangeRadioButton.Text = "Selected Range";
            this.ExportSelectedRangeRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportSelectedRangeRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportSelectedRangeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExportFullDataSetRadioButton
            // 
            this.ExportFullDataSetRadioButton.AutoSize = true;
            this.ExportFullDataSetRadioButton.Image = global::GPMLink.Properties.Resources.All_16x;
            this.ExportFullDataSetRadioButton.Location = new System.Drawing.Point(24, 55);
            this.ExportFullDataSetRadioButton.MinimumSize = new System.Drawing.Size(0, 23);
            this.ExportFullDataSetRadioButton.Name = "ExportFullDataSetRadioButton";
            this.ExportFullDataSetRadioButton.Size = new System.Drawing.Size(104, 23);
            this.ExportFullDataSetRadioButton.TabIndex = 6;
            this.ExportFullDataSetRadioButton.Text = "Full Dataset";
            this.ExportFullDataSetRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportFullDataSetRadioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportFullDataSetRadioButton.UseVisualStyleBackColor = true;
            // 
            // DestinationLinkLabel
            // 
            this.DestinationLinkLabel.AutoEllipsis = true;
            this.DestinationLinkLabel.AutoSize = true;
            this.DestinationLinkLabel.Location = new System.Drawing.Point(105, 17);
            this.DestinationLinkLabel.Name = "DestinationLinkLabel";
            this.DestinationLinkLabel.Size = new System.Drawing.Size(74, 14);
            this.DestinationLinkLabel.TabIndex = 10;
            this.DestinationLinkLabel.TabStop = true;
            this.DestinationLinkLabel.Text = "not selected.";
            // 
            // ExportProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancelExport;
            this.ClientSize = new System.Drawing.Size(407, 301);
            this.ControlBox = false;
            this.Controls.Add(this.DestinationLinkLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ButtonCancelExport);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.LabelMessage);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExportProgressForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EXPORT DATA";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button ButtonCancelExport;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.RadioButton ExportAsExcelRadioButton;
        private System.Windows.Forms.RadioButton ExportAsCsvRadioButton;
        private System.Windows.Forms.RadioButton ExportBothRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ExportSelectedRangeRadioButton;
        private System.Windows.Forms.RadioButton ExportFullDataSetRadioButton;
        private System.Windows.Forms.LinkLabel DestinationLinkLabel;
    }
}