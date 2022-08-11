
namespace GPMLib.UI.Winforms {
    partial class LiveReadingsControl {
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
            this.ReadingsLiveTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsPowerUnitSelectorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsPowerUnitWhButton = new System.Windows.Forms.Button();
            this.ReadingsPowerUnitAhButton = new System.Windows.Forms.Button();
            this.ReadingsPowerUnitVAButton = new System.Windows.Forms.Button();
            this.ILabel = new System.Windows.Forms.Label();
            this.ULabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsUDecimalValueLabel = new System.Windows.Forms.Label();
            this.ReadingsUIntegralValueLabel = new System.Windows.Forms.Label();
            this.ReadingsLiveUUnitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VAutoRangeLabel = new System.Windows.Forms.Label();
            this.ReadingsUUnitLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsIDecimalValueLabel = new System.Windows.Forms.Label();
            this.ReadingsIIntegralValueLabel = new System.Windows.Forms.Label();
            this.ReadingsLiveIUnitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IAutoRangeLabel = new System.Windows.Forms.Label();
            this.ReadingsIUnitLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsPDecimalValueLabel = new System.Windows.Forms.Label();
            this.ReadingsLivePUnitTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ReadingsPUnitLabel = new System.Windows.Forms.Label();
            this.ReadingsPIntegralValueLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReadingsLiveTablePanel.SuspendLayout();
            this.ReadingsPowerUnitSelectorTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.ReadingsLiveUUnitTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.ReadingsLiveIUnitTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.ReadingsLivePUnitTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReadingsLiveTablePanel
            // 
            this.ReadingsLiveTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsLiveTablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsLiveTablePanel.ColumnCount = 2;
            this.ReadingsLiveTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ReadingsLiveTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.ReadingsLiveTablePanel.Controls.Add(this.ReadingsPowerUnitSelectorTableLayoutPanel, 0, 3);
            this.ReadingsLiveTablePanel.Controls.Add(this.ILabel, 0, 2);
            this.ReadingsLiveTablePanel.Controls.Add(this.ULabel, 0, 1);
            this.ReadingsLiveTablePanel.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.ReadingsLiveTablePanel.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.ReadingsLiveTablePanel.Controls.Add(this.tableLayoutPanel7, 1, 3);
            this.ReadingsLiveTablePanel.Controls.Add(this.label3, 0, 0);
            this.ReadingsLiveTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ReadingsLiveTablePanel.Location = new System.Drawing.Point(0, 0);
            this.ReadingsLiveTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsLiveTablePanel.MinimumSize = new System.Drawing.Size(370, 250);
            this.ReadingsLiveTablePanel.Name = "ReadingsLiveTablePanel";
            this.ReadingsLiveTablePanel.RowCount = 4;
            this.ReadingsLiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReadingsLiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.ReadingsLiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.ReadingsLiveTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.ReadingsLiveTablePanel.Size = new System.Drawing.Size(370, 250);
            this.ReadingsLiveTablePanel.TabIndex = 4;
            // 
            // ReadingsPowerUnitSelectorTableLayoutPanel
            // 
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.ColumnCount = 1;
            this.ReadingsPowerUnitSelectorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Controls.Add(this.ReadingsPowerUnitWhButton, 0, 2);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Controls.Add(this.ReadingsPowerUnitAhButton, 0, 1);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Controls.Add(this.ReadingsPowerUnitVAButton, 0, 0);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Location = new System.Drawing.Point(0, 176);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Name = "ReadingsPowerUnitSelectorTableLayoutPanel";
            this.ReadingsPowerUnitSelectorTableLayoutPanel.RowCount = 3;
            this.ReadingsPowerUnitSelectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.ReadingsPowerUnitSelectorTableLayoutPanel.Size = new System.Drawing.Size(50, 75);
            this.ReadingsPowerUnitSelectorTableLayoutPanel.TabIndex = 38;
            // 
            // ReadingsPowerUnitWhButton
            // 
            this.ReadingsPowerUnitWhButton.AccessibleDescription = "Resets the last minimum value";
            this.ReadingsPowerUnitWhButton.AccessibleName = "ReadingsStatsMinResetButton";
            this.ReadingsPowerUnitWhButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ReadingsPowerUnitWhButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPowerUnitWhButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsPowerUnitWhButton.Font = new System.Drawing.Font("Bahnschrift", 7F);
            this.ReadingsPowerUnitWhButton.ForeColor = System.Drawing.Color.White;
            this.ReadingsPowerUnitWhButton.Location = new System.Drawing.Point(0, 49);
            this.ReadingsPowerUnitWhButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPowerUnitWhButton.Name = "ReadingsPowerUnitWhButton";
            this.ReadingsPowerUnitWhButton.Size = new System.Drawing.Size(50, 24);
            this.ReadingsPowerUnitWhButton.TabIndex = 2;
            this.ReadingsPowerUnitWhButton.Text = "Wh";
            this.ReadingsPowerUnitWhButton.UseVisualStyleBackColor = false;
            // 
            // ReadingsPowerUnitAhButton
            // 
            this.ReadingsPowerUnitAhButton.AccessibleDescription = "Resets the last minimum value";
            this.ReadingsPowerUnitAhButton.AccessibleName = "ReadingsStatsMinResetButton";
            this.ReadingsPowerUnitAhButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ReadingsPowerUnitAhButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPowerUnitAhButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsPowerUnitAhButton.Font = new System.Drawing.Font("Bahnschrift", 7F);
            this.ReadingsPowerUnitAhButton.ForeColor = System.Drawing.Color.White;
            this.ReadingsPowerUnitAhButton.Location = new System.Drawing.Point(0, 24);
            this.ReadingsPowerUnitAhButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPowerUnitAhButton.Name = "ReadingsPowerUnitAhButton";
            this.ReadingsPowerUnitAhButton.Size = new System.Drawing.Size(50, 24);
            this.ReadingsPowerUnitAhButton.TabIndex = 1;
            this.ReadingsPowerUnitAhButton.Text = "Ah";
            this.ReadingsPowerUnitAhButton.UseVisualStyleBackColor = false;
            // 
            // ReadingsPowerUnitVAButton
            // 
            this.ReadingsPowerUnitVAButton.AccessibleDescription = "Resets the last maximum value";
            this.ReadingsPowerUnitVAButton.AccessibleName = "ReadingsStatsMaxResetButton";
            this.ReadingsPowerUnitVAButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ReadingsPowerUnitVAButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPowerUnitVAButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsPowerUnitVAButton.Font = new System.Drawing.Font("Bahnschrift", 7F);
            this.ReadingsPowerUnitVAButton.ForeColor = System.Drawing.Color.White;
            this.ReadingsPowerUnitVAButton.Location = new System.Drawing.Point(0, 0);
            this.ReadingsPowerUnitVAButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPowerUnitVAButton.Name = "ReadingsPowerUnitVAButton";
            this.ReadingsPowerUnitVAButton.Size = new System.Drawing.Size(50, 24);
            this.ReadingsPowerUnitVAButton.TabIndex = 0;
            this.ReadingsPowerUnitVAButton.Text = "VA";
            this.ReadingsPowerUnitVAButton.UseVisualStyleBackColor = false;
            // 
            // ILabel
            // 
            this.ILabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ILabel.AutoSize = true;
            this.ILabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ILabel.Font = new System.Drawing.Font("Bahnschrift", 30F, System.Drawing.FontStyle.Bold);
            this.ILabel.ForeColor = System.Drawing.Color.Coral;
            this.ILabel.Location = new System.Drawing.Point(3, 105);
            this.ILabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ILabel.Name = "ILabel";
            this.ILabel.Size = new System.Drawing.Size(44, 66);
            this.ILabel.TabIndex = 28;
            this.ILabel.Text = "I";
            this.ILabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ULabel
            // 
            this.ULabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ULabel.AutoSize = true;
            this.ULabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ULabel.Font = new System.Drawing.Font("Bahnschrift", 30F, System.Drawing.FontStyle.Bold);
            this.ULabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ULabel.Location = new System.Drawing.Point(3, 29);
            this.ULabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ULabel.Name = "ULabel";
            this.ULabel.Size = new System.Drawing.Size(44, 66);
            this.ULabel.TabIndex = 17;
            this.ULabel.Text = "U";
            this.ULabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.Controls.Add(this.ReadingsUDecimalValueLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.ReadingsUIntegralValueLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.ReadingsLiveUUnitTableLayoutPanel, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(53, 27);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(314, 70);
            this.tableLayoutPanel5.TabIndex = 19;
            // 
            // ReadingsUDecimalValueLabel
            // 
            this.ReadingsUDecimalValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsUDecimalValueLabel.AutoSize = true;
            this.ReadingsUDecimalValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsUDecimalValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsUDecimalValueLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F);
            this.ReadingsUDecimalValueLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ReadingsUDecimalValueLabel.Location = new System.Drawing.Point(206, 31);
            this.ReadingsUDecimalValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsUDecimalValueLabel.Name = "ReadingsUDecimalValueLabel";
            this.ReadingsUDecimalValueLabel.Size = new System.Drawing.Size(40, 39);
            this.ReadingsUDecimalValueLabel.TabIndex = 17;
            this.ReadingsUDecimalValueLabel.Text = "00";
            this.ReadingsUDecimalValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReadingsUIntegralValueLabel
            // 
            this.ReadingsUIntegralValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsUIntegralValueLabel.AutoSize = true;
            this.ReadingsUIntegralValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsUIntegralValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsUIntegralValueLabel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsUIntegralValueLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ReadingsUIntegralValueLabel.Location = new System.Drawing.Point(0, 0);
            this.ReadingsUIntegralValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsUIntegralValueLabel.Name = "ReadingsUIntegralValueLabel";
            this.ReadingsUIntegralValueLabel.Size = new System.Drawing.Size(206, 70);
            this.ReadingsUIntegralValueLabel.TabIndex = 15;
            this.ReadingsUIntegralValueLabel.Text = "0,";
            this.ReadingsUIntegralValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReadingsLiveUUnitTableLayoutPanel
            // 
            this.ReadingsLiveUUnitTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsLiveUUnitTableLayoutPanel.ColumnCount = 1;
            this.ReadingsLiveUUnitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ReadingsLiveUUnitTableLayoutPanel.Controls.Add(this.VAutoRangeLabel, 0, 0);
            this.ReadingsLiveUUnitTableLayoutPanel.Controls.Add(this.ReadingsUUnitLabel, 0, 1);
            this.ReadingsLiveUUnitTableLayoutPanel.Location = new System.Drawing.Point(249, 3);
            this.ReadingsLiveUUnitTableLayoutPanel.Name = "ReadingsLiveUUnitTableLayoutPanel";
            this.ReadingsLiveUUnitTableLayoutPanel.RowCount = 2;
            this.ReadingsLiveUUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.9375F));
            this.ReadingsLiveUUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.0625F));
            this.ReadingsLiveUUnitTableLayoutPanel.Size = new System.Drawing.Size(62, 64);
            this.ReadingsLiveUUnitTableLayoutPanel.TabIndex = 16;
            // 
            // VAutoRangeLabel
            // 
            this.VAutoRangeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VAutoRangeLabel.AutoSize = true;
            this.VAutoRangeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.VAutoRangeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.VAutoRangeLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.VAutoRangeLabel.Location = new System.Drawing.Point(3, 4);
            this.VAutoRangeLabel.Name = "VAutoRangeLabel";
            this.VAutoRangeLabel.Size = new System.Drawing.Size(56, 19);
            this.VAutoRangeLabel.TabIndex = 18;
            this.VAutoRangeLabel.Text = "AUTO";
            this.VAutoRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadingsUUnitLabel
            // 
            this.ReadingsUUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsUUnitLabel.AutoSize = true;
            this.ReadingsUUnitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ReadingsUUnitLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsUUnitLabel.Location = new System.Drawing.Point(3, 35);
            this.ReadingsUUnitLabel.Name = "ReadingsUUnitLabel";
            this.ReadingsUUnitLabel.Size = new System.Drawing.Size(56, 29);
            this.ReadingsUUnitLabel.TabIndex = 16;
            this.ReadingsUUnitLabel.Text = "V";
            this.ReadingsUUnitLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel6.Controls.Add(this.ReadingsIDecimalValueLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.ReadingsIIntegralValueLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.ReadingsLiveIUnitTableLayoutPanel, 2, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(53, 103);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(314, 70);
            this.tableLayoutPanel6.TabIndex = 20;
            // 
            // ReadingsIDecimalValueLabel
            // 
            this.ReadingsIDecimalValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsIDecimalValueLabel.AutoSize = true;
            this.ReadingsIDecimalValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsIDecimalValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsIDecimalValueLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F);
            this.ReadingsIDecimalValueLabel.ForeColor = System.Drawing.Color.Coral;
            this.ReadingsIDecimalValueLabel.Location = new System.Drawing.Point(205, 31);
            this.ReadingsIDecimalValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsIDecimalValueLabel.Name = "ReadingsIDecimalValueLabel";
            this.ReadingsIDecimalValueLabel.Size = new System.Drawing.Size(40, 39);
            this.ReadingsIDecimalValueLabel.TabIndex = 18;
            this.ReadingsIDecimalValueLabel.Text = "00";
            this.ReadingsIDecimalValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReadingsIIntegralValueLabel
            // 
            this.ReadingsIIntegralValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsIIntegralValueLabel.AutoSize = true;
            this.ReadingsIIntegralValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsIIntegralValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsIIntegralValueLabel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsIIntegralValueLabel.ForeColor = System.Drawing.Color.Coral;
            this.ReadingsIIntegralValueLabel.Location = new System.Drawing.Point(0, 0);
            this.ReadingsIIntegralValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsIIntegralValueLabel.Name = "ReadingsIIntegralValueLabel";
            this.ReadingsIIntegralValueLabel.Size = new System.Drawing.Size(205, 70);
            this.ReadingsIIntegralValueLabel.TabIndex = 15;
            this.ReadingsIIntegralValueLabel.Text = "0,";
            this.ReadingsIIntegralValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReadingsLiveIUnitTableLayoutPanel
            // 
            this.ReadingsLiveIUnitTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsLiveIUnitTableLayoutPanel.ColumnCount = 1;
            this.ReadingsLiveIUnitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ReadingsLiveIUnitTableLayoutPanel.Controls.Add(this.IAutoRangeLabel, 0, 0);
            this.ReadingsLiveIUnitTableLayoutPanel.Controls.Add(this.ReadingsIUnitLabel, 0, 1);
            this.ReadingsLiveIUnitTableLayoutPanel.Location = new System.Drawing.Point(248, 3);
            this.ReadingsLiveIUnitTableLayoutPanel.Name = "ReadingsLiveIUnitTableLayoutPanel";
            this.ReadingsLiveIUnitTableLayoutPanel.RowCount = 2;
            this.ReadingsLiveIUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.78378F));
            this.ReadingsLiveIUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.21622F));
            this.ReadingsLiveIUnitTableLayoutPanel.Size = new System.Drawing.Size(63, 64);
            this.ReadingsLiveIUnitTableLayoutPanel.TabIndex = 16;
            // 
            // IAutoRangeLabel
            // 
            this.IAutoRangeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IAutoRangeLabel.AutoSize = true;
            this.IAutoRangeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.IAutoRangeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F);
            this.IAutoRangeLabel.ForeColor = System.Drawing.Color.Coral;
            this.IAutoRangeLabel.Location = new System.Drawing.Point(3, 2);
            this.IAutoRangeLabel.Name = "IAutoRangeLabel";
            this.IAutoRangeLabel.Size = new System.Drawing.Size(57, 19);
            this.IAutoRangeLabel.TabIndex = 17;
            this.IAutoRangeLabel.Text = "AUTO";
            this.IAutoRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadingsIUnitLabel
            // 
            this.ReadingsIUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsIUnitLabel.AutoSize = true;
            this.ReadingsIUnitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ReadingsIUnitLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsIUnitLabel.Location = new System.Drawing.Point(3, 35);
            this.ReadingsIUnitLabel.Name = "ReadingsIUnitLabel";
            this.ReadingsIUnitLabel.Size = new System.Drawing.Size(57, 29);
            this.ReadingsIUnitLabel.TabIndex = 16;
            this.ReadingsIUnitLabel.Text = "A";
            this.ReadingsIUnitLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel7.Controls.Add(this.ReadingsPDecimalValueLabel, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.ReadingsLivePUnitTableLayoutPanel, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.ReadingsPIntegralValueLabel, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(53, 179);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(314, 70);
            this.tableLayoutPanel7.TabIndex = 21;
            // 
            // ReadingsPDecimalValueLabel
            // 
            this.ReadingsPDecimalValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPDecimalValueLabel.AutoSize = true;
            this.ReadingsPDecimalValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsPDecimalValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsPDecimalValueLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F);
            this.ReadingsPDecimalValueLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.ReadingsPDecimalValueLabel.Location = new System.Drawing.Point(203, 31);
            this.ReadingsPDecimalValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPDecimalValueLabel.Name = "ReadingsPDecimalValueLabel";
            this.ReadingsPDecimalValueLabel.Size = new System.Drawing.Size(40, 39);
            this.ReadingsPDecimalValueLabel.TabIndex = 18;
            this.ReadingsPDecimalValueLabel.Text = "00";
            this.ReadingsPDecimalValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReadingsLivePUnitTableLayoutPanel
            // 
            this.ReadingsLivePUnitTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsLivePUnitTableLayoutPanel.ColumnCount = 1;
            this.ReadingsLivePUnitTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ReadingsLivePUnitTableLayoutPanel.Controls.Add(this.ModeLabel, 0, 0);
            this.ReadingsLivePUnitTableLayoutPanel.Controls.Add(this.ReadingsPUnitLabel, 0, 1);
            this.ReadingsLivePUnitTableLayoutPanel.Location = new System.Drawing.Point(246, 3);
            this.ReadingsLivePUnitTableLayoutPanel.Name = "ReadingsLivePUnitTableLayoutPanel";
            this.ReadingsLivePUnitTableLayoutPanel.RowCount = 2;
            this.ReadingsLivePUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.08108F));
            this.ReadingsLivePUnitTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.91892F));
            this.ReadingsLivePUnitTableLayoutPanel.Size = new System.Drawing.Size(65, 64);
            this.ReadingsLivePUnitTableLayoutPanel.TabIndex = 17;
            // 
            // ModeLabel
            // 
            this.ModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ModeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeLabel.ForeColor = System.Drawing.Color.Silver;
            this.ModeLabel.Location = new System.Drawing.Point(3, 0);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(59, 19);
            this.ModeLabel.TabIndex = 17;
            this.ModeLabel.Text = "VA";
            this.ModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadingsPUnitLabel
            // 
            this.ReadingsPUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPUnitLabel.AutoSize = true;
            this.ReadingsPUnitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ReadingsPUnitLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsPUnitLabel.Location = new System.Drawing.Point(3, 35);
            this.ReadingsPUnitLabel.Name = "ReadingsPUnitLabel";
            this.ReadingsPUnitLabel.Size = new System.Drawing.Size(59, 29);
            this.ReadingsPUnitLabel.TabIndex = 16;
            this.ReadingsPUnitLabel.Text = "W";
            this.ReadingsPUnitLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ReadingsPIntegralValueLabel
            // 
            this.ReadingsPIntegralValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPIntegralValueLabel.AutoSize = true;
            this.ReadingsPIntegralValueLabel.BackColor = System.Drawing.Color.Black;
            this.ReadingsPIntegralValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReadingsPIntegralValueLabel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingsPIntegralValueLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.ReadingsPIntegralValueLabel.Location = new System.Drawing.Point(0, 0);
            this.ReadingsPIntegralValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsPIntegralValueLabel.Name = "ReadingsPIntegralValueLabel";
            this.ReadingsPIntegralValueLabel.Size = new System.Drawing.Size(203, 70);
            this.ReadingsPIntegralValueLabel.TabIndex = 15;
            this.ReadingsPIntegralValueLabel.Text = "0,";
            this.ReadingsPIntegralValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ReadingsLiveTablePanel.SetColumnSpan(this.label3, 2);
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(370, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "LIVE READINGS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LiveReadingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReadingsLiveTablePanel);
            this.Font = new System.Drawing.Font("Bahnschrift", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LiveReadingsControl";
            this.Size = new System.Drawing.Size(370, 250);
            this.Load += new System.EventHandler(this.LiveReadingsControl_Load);
            this.ReadingsLiveTablePanel.ResumeLayout(false);
            this.ReadingsLiveTablePanel.PerformLayout();
            this.ReadingsPowerUnitSelectorTableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ReadingsLiveUUnitTableLayoutPanel.ResumeLayout(false);
            this.ReadingsLiveUUnitTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ReadingsLiveIUnitTableLayoutPanel.ResumeLayout(false);
            this.ReadingsLiveIUnitTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ReadingsLivePUnitTableLayoutPanel.ResumeLayout(false);
            this.ReadingsLivePUnitTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ReadingsLiveTablePanel;
        private System.Windows.Forms.TableLayoutPanel ReadingsPowerUnitSelectorTableLayoutPanel;
        private System.Windows.Forms.Button ReadingsPowerUnitWhButton;
        private System.Windows.Forms.Button ReadingsPowerUnitAhButton;
        private System.Windows.Forms.Button ReadingsPowerUnitVAButton;
        private System.Windows.Forms.Label ILabel;
        private System.Windows.Forms.Label ULabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label ReadingsUDecimalValueLabel;
        private System.Windows.Forms.Label ReadingsUIntegralValueLabel;
        private System.Windows.Forms.TableLayoutPanel ReadingsLiveUUnitTableLayoutPanel;
        private System.Windows.Forms.Label VAutoRangeLabel;
        private System.Windows.Forms.Label ReadingsUUnitLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label ReadingsIDecimalValueLabel;
        private System.Windows.Forms.Label ReadingsIIntegralValueLabel;
        private System.Windows.Forms.TableLayoutPanel ReadingsLiveIUnitTableLayoutPanel;
        private System.Windows.Forms.Label IAutoRangeLabel;
        private System.Windows.Forms.Label ReadingsIUnitLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label ReadingsPDecimalValueLabel;
        private System.Windows.Forms.TableLayoutPanel ReadingsLivePUnitTableLayoutPanel;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Label ReadingsPUnitLabel;
        private System.Windows.Forms.Label ReadingsPIntegralValueLabel;
        private System.Windows.Forms.Label label3;
    }
}
