
namespace GPMLink {
    partial class Gpm8310Form {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gpm8310Form));
            this.ModesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReadingsLiveStatsValuesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IAvgLabel = new System.Windows.Forms.Label();
            this.PAvgLabel = new System.Windows.Forms.Label();
            this.UAvgLabel = new System.Windows.Forms.Label();
            this.UMaxLabel = new System.Windows.Forms.Label();
            this.IMaxLabel = new System.Windows.Forms.Label();
            this.PMaxLabel = new System.Windows.Forms.Label();
            this.InputModeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.InputModeButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.InputModeACDCButton = new System.Windows.Forms.Button();
            this.InputModeDCButton = new System.Windows.Forms.Button();
            this.InputModeACButton = new System.Windows.Forms.Button();
            this.ReadingsStatsResetTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ReadingsStatsMinResetButton = new System.Windows.Forms.Button();
            this.ReadingsStatsMaxResetButton = new System.Windows.Forms.Button();
            this.IntegratorTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IntegratorExportToExcelButton = new System.Windows.Forms.Button();
            this.IntegratorTitleLabel = new System.Windows.Forms.Label();
            this.IntegratorResetButton = new System.Windows.Forms.Button();
            this.IntegratorStartButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.IgnoreNegativesCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.IntegratorTimeLabel = new System.Windows.Forms.Label();
            this.LabelCursor = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.GPM8310ToolstripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceTranscriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KnownDeviceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ReadingsFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.InputVoltageRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCurrentRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.IntegratorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.IntegratorStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IntegratorStartPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IntegratorStopResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DeviceConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReadingPointsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.liveReadingsControl1 = new GPMLib.UI.Winforms.LiveReadingsControl();
            this.ReadingsStatsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.gpmPlotControl1 = new GPMLib.UI.Winforms.GpmPlotControl();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReadingsLiveStatsValuesTableLayoutPanel.SuspendLayout();
            this.InputModeTableLayoutPanel.SuspendLayout();
            this.InputModeButtonsTableLayoutPanel.SuspendLayout();
            this.ReadingsStatsResetTableLayoutPanel.SuspendLayout();
            this.IntegratorTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ReadingsStatsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModesContextMenuStrip
            // 
            this.ModesContextMenuStrip.Name = "ModesContextMenuStrip";
            this.ModesContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // ReadingsLiveStatsValuesTableLayoutPanel
            // 
            this.ReadingsLiveStatsValuesTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsLiveStatsValuesTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ReadingsLiveStatsValuesTableLayoutPanel.ColumnCount = 3;
            this.ReadingsLiveStatsValuesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ReadingsLiveStatsValuesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ReadingsLiveStatsValuesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.IAvgLabel, 1, 1);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.PAvgLabel, 2, 1);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.UAvgLabel, 0, 1);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.UMaxLabel, 0, 0);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.IMaxLabel, 1, 0);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Controls.Add(this.PMaxLabel, 2, 0);
            this.ReadingsLiveStatsValuesTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ReadingsLiveStatsValuesTableLayoutPanel.Location = new System.Drawing.Point(50, 24);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsLiveStatsValuesTableLayoutPanel.Name = "ReadingsLiveStatsValuesTableLayoutPanel";
            this.ReadingsLiveStatsValuesTableLayoutPanel.RowCount = 2;
            this.ReadingsLiveStatsValuesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReadingsLiveStatsValuesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsLiveStatsValuesTableLayoutPanel.Size = new System.Drawing.Size(320, 48);
            this.ReadingsLiveStatsValuesTableLayoutPanel.TabIndex = 25;
            // 
            // IAvgLabel
            // 
            this.IAvgLabel.AccessibleDescription = "Indicates the minimum current level so far. It can be reset by the user via the R" +
    "eset Min Button.";
            this.IAvgLabel.AccessibleName = "ReadingsStatsMinILabel";
            this.IAvgLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IAvgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IAvgLabel.AutoSize = true;
            this.IAvgLabel.BackColor = System.Drawing.Color.Black;
            this.IAvgLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.IAvgLabel.ForeColor = System.Drawing.Color.Orange;
            this.IAvgLabel.Location = new System.Drawing.Point(108, 25);
            this.IAvgLabel.Margin = new System.Windows.Forms.Padding(1);
            this.IAvgLabel.Name = "IAvgLabel";
            this.IAvgLabel.Size = new System.Drawing.Size(105, 22);
            this.IAvgLabel.TabIndex = 23;
            this.IAvgLabel.Text = "min";
            this.IAvgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PAvgLabel
            // 
            this.PAvgLabel.AccessibleDescription = "Indicates the minimum power level so far. It can be reset by the user via the Res" +
    "et Min Button.";
            this.PAvgLabel.AccessibleName = "ReadingsStatsMinPLabel";
            this.PAvgLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.PAvgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PAvgLabel.AutoSize = true;
            this.PAvgLabel.BackColor = System.Drawing.Color.Black;
            this.PAvgLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.PAvgLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PAvgLabel.Location = new System.Drawing.Point(215, 25);
            this.PAvgLabel.Margin = new System.Windows.Forms.Padding(1);
            this.PAvgLabel.Name = "PAvgLabel";
            this.PAvgLabel.Size = new System.Drawing.Size(104, 22);
            this.PAvgLabel.TabIndex = 24;
            this.PAvgLabel.Text = "min";
            this.PAvgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UAvgLabel
            // 
            this.UAvgLabel.AccessibleDescription = "Indicates the minimum voltage level so far. It can be reset by the user via the R" +
    "eset Min Button.";
            this.UAvgLabel.AccessibleName = "ReadingsStatsMinULabel";
            this.UAvgLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.UAvgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UAvgLabel.AutoSize = true;
            this.UAvgLabel.BackColor = System.Drawing.Color.Black;
            this.UAvgLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.UAvgLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.UAvgLabel.Location = new System.Drawing.Point(1, 25);
            this.UAvgLabel.Margin = new System.Windows.Forms.Padding(1);
            this.UAvgLabel.Name = "UAvgLabel";
            this.UAvgLabel.Size = new System.Drawing.Size(105, 22);
            this.UAvgLabel.TabIndex = 22;
            this.UAvgLabel.Text = "min";
            this.UAvgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UMaxLabel
            // 
            this.UMaxLabel.AccessibleDescription = "Indicates the maximum voltage level so far. It can be reset by the user via the R" +
    "eset Max Button.";
            this.UMaxLabel.AccessibleName = "ReadingsStatsMaxULabel";
            this.UMaxLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.UMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UMaxLabel.AutoSize = true;
            this.UMaxLabel.BackColor = System.Drawing.Color.Black;
            this.UMaxLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.UMaxLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.UMaxLabel.Location = new System.Drawing.Point(1, 1);
            this.UMaxLabel.Margin = new System.Windows.Forms.Padding(1);
            this.UMaxLabel.Name = "UMaxLabel";
            this.UMaxLabel.Size = new System.Drawing.Size(105, 22);
            this.UMaxLabel.TabIndex = 19;
            this.UMaxLabel.Text = "max";
            this.UMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IMaxLabel
            // 
            this.IMaxLabel.AccessibleDescription = "Indicates the maximum current level so far. It can be reset by the user via the R" +
    "eset Max Button.";
            this.IMaxLabel.AccessibleName = "ReadingsStatsMaxILabel";
            this.IMaxLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IMaxLabel.AutoSize = true;
            this.IMaxLabel.BackColor = System.Drawing.Color.Black;
            this.IMaxLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.IMaxLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.IMaxLabel.Location = new System.Drawing.Point(108, 1);
            this.IMaxLabel.Margin = new System.Windows.Forms.Padding(1);
            this.IMaxLabel.Name = "IMaxLabel";
            this.IMaxLabel.Size = new System.Drawing.Size(105, 22);
            this.IMaxLabel.TabIndex = 20;
            this.IMaxLabel.Text = "max";
            this.IMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PMaxLabel
            // 
            this.PMaxLabel.AccessibleDescription = "Indicates the maximum power level so far. It can be reset by the user via the Res" +
    "et Max Button.";
            this.PMaxLabel.AccessibleName = "ReadingsStatsMaxPLabel";
            this.PMaxLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.PMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PMaxLabel.AutoSize = true;
            this.PMaxLabel.BackColor = System.Drawing.Color.Black;
            this.PMaxLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.PMaxLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PMaxLabel.Location = new System.Drawing.Point(215, 1);
            this.PMaxLabel.Margin = new System.Windows.Forms.Padding(1);
            this.PMaxLabel.Name = "PMaxLabel";
            this.PMaxLabel.Size = new System.Drawing.Size(104, 22);
            this.PMaxLabel.TabIndex = 21;
            this.PMaxLabel.Text = "max";
            this.PMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InputModeTableLayoutPanel
            // 
            this.InputModeTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.InputModeTableLayoutPanel.ColumnCount = 1;
            this.InputModeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InputModeTableLayoutPanel.Controls.Add(this.label6, 0, 0);
            this.InputModeTableLayoutPanel.Controls.Add(this.InputModeButtonsTableLayoutPanel, 0, 1);
            this.InputModeTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.InputModeTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.InputModeTableLayoutPanel.MaximumSize = new System.Drawing.Size(370, 60);
            this.InputModeTableLayoutPanel.MinimumSize = new System.Drawing.Size(370, 60);
            this.InputModeTableLayoutPanel.Name = "InputModeTableLayoutPanel";
            this.InputModeTableLayoutPanel.RowCount = 2;
            this.InputModeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.InputModeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.InputModeTableLayoutPanel.Size = new System.Drawing.Size(370, 60);
            this.InputModeTableLayoutPanel.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "INPUT MODE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InputModeButtonsTableLayoutPanel
            // 
            this.InputModeButtonsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputModeButtonsTableLayoutPanel.ColumnCount = 3;
            this.InputModeButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InputModeButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InputModeButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InputModeButtonsTableLayoutPanel.Controls.Add(this.InputModeACDCButton, 2, 0);
            this.InputModeButtonsTableLayoutPanel.Controls.Add(this.InputModeDCButton, 1, 0);
            this.InputModeButtonsTableLayoutPanel.Controls.Add(this.InputModeACButton, 0, 0);
            this.InputModeButtonsTableLayoutPanel.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputModeButtonsTableLayoutPanel.Location = new System.Drawing.Point(3, 27);
            this.InputModeButtonsTableLayoutPanel.Name = "InputModeButtonsTableLayoutPanel";
            this.InputModeButtonsTableLayoutPanel.RowCount = 1;
            this.InputModeButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.InputModeButtonsTableLayoutPanel.Size = new System.Drawing.Size(364, 42);
            this.InputModeButtonsTableLayoutPanel.TabIndex = 25;
            // 
            // InputModeACDCButton
            // 
            this.InputModeACDCButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputModeACDCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.InputModeACDCButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.InputModeACDCButton.ForeColor = System.Drawing.Color.White;
            this.InputModeACDCButton.Location = new System.Drawing.Point(245, 3);
            this.InputModeACDCButton.Name = "InputModeACDCButton";
            this.InputModeACDCButton.Size = new System.Drawing.Size(116, 26);
            this.InputModeACDCButton.TabIndex = 23;
            this.InputModeACDCButton.Tag = "AC+DC";
            this.InputModeACDCButton.Text = "AC+DC";
            this.InputModeACDCButton.UseMnemonic = false;
            this.InputModeACDCButton.UseVisualStyleBackColor = false;
            // 
            // InputModeDCButton
            // 
            this.InputModeDCButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputModeDCButton.BackColor = System.Drawing.Color.DarkGreen;
            this.InputModeDCButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.InputModeDCButton.ForeColor = System.Drawing.Color.Lime;
            this.InputModeDCButton.Location = new System.Drawing.Point(124, 3);
            this.InputModeDCButton.Name = "InputModeDCButton";
            this.InputModeDCButton.Size = new System.Drawing.Size(115, 26);
            this.InputModeDCButton.TabIndex = 22;
            this.InputModeDCButton.Tag = "DC";
            this.InputModeDCButton.Text = "DC";
            this.InputModeDCButton.UseVisualStyleBackColor = false;
            // 
            // InputModeACButton
            // 
            this.InputModeACButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputModeACButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.InputModeACButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.InputModeACButton.ForeColor = System.Drawing.Color.White;
            this.InputModeACButton.Location = new System.Drawing.Point(3, 3);
            this.InputModeACButton.Name = "InputModeACButton";
            this.InputModeACButton.Size = new System.Drawing.Size(115, 26);
            this.InputModeACButton.TabIndex = 21;
            this.InputModeACButton.Tag = "AC/RMS";
            this.InputModeACButton.Text = "AC";
            this.InputModeACButton.UseVisualStyleBackColor = false;
            // 
            // ReadingsStatsResetTableLayoutPanel
            // 
            this.ReadingsStatsResetTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsStatsResetTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ReadingsStatsResetTableLayoutPanel.ColumnCount = 1;
            this.ReadingsStatsResetTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsStatsResetTableLayoutPanel.Controls.Add(this.ReadingsStatsMinResetButton, 0, 1);
            this.ReadingsStatsResetTableLayoutPanel.Controls.Add(this.ReadingsStatsMaxResetButton, 0, 0);
            this.ReadingsStatsResetTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ReadingsStatsResetTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.ReadingsStatsResetTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsStatsResetTableLayoutPanel.Name = "ReadingsStatsResetTableLayoutPanel";
            this.ReadingsStatsResetTableLayoutPanel.RowCount = 2;
            this.ReadingsStatsResetTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReadingsStatsResetTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsStatsResetTableLayoutPanel.Size = new System.Drawing.Size(50, 48);
            this.ReadingsStatsResetTableLayoutPanel.TabIndex = 26;
            // 
            // ReadingsStatsMinResetButton
            // 
            this.ReadingsStatsMinResetButton.AccessibleDescription = "Resets the last minimum value";
            this.ReadingsStatsMinResetButton.AccessibleName = "ReadingsStatsMinResetButton";
            this.ReadingsStatsMinResetButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ReadingsStatsMinResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsStatsMinResetButton.Font = new System.Drawing.Font("Bahnschrift", 7F);
            this.ReadingsStatsMinResetButton.ForeColor = System.Drawing.Color.White;
            this.ReadingsStatsMinResetButton.Location = new System.Drawing.Point(0, 24);
            this.ReadingsStatsMinResetButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsStatsMinResetButton.Name = "ReadingsStatsMinResetButton";
            this.ReadingsStatsMinResetButton.Size = new System.Drawing.Size(50, 24);
            this.ReadingsStatsMinResetButton.TabIndex = 1;
            this.ReadingsStatsMinResetButton.Text = "MIN";
            this.ReadingsStatsMinResetButton.UseVisualStyleBackColor = false;
            // 
            // ReadingsStatsMaxResetButton
            // 
            this.ReadingsStatsMaxResetButton.AccessibleDescription = "Resets the last maximum value";
            this.ReadingsStatsMaxResetButton.AccessibleName = "ReadingsStatsMaxResetButton";
            this.ReadingsStatsMaxResetButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ReadingsStatsMaxResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsStatsMaxResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ReadingsStatsMaxResetButton.Font = new System.Drawing.Font("Bahnschrift", 7F);
            this.ReadingsStatsMaxResetButton.ForeColor = System.Drawing.Color.White;
            this.ReadingsStatsMaxResetButton.Location = new System.Drawing.Point(0, 0);
            this.ReadingsStatsMaxResetButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReadingsStatsMaxResetButton.Name = "ReadingsStatsMaxResetButton";
            this.ReadingsStatsMaxResetButton.Size = new System.Drawing.Size(50, 24);
            this.ReadingsStatsMaxResetButton.TabIndex = 0;
            this.ReadingsStatsMaxResetButton.Text = "MAX";
            this.ReadingsStatsMaxResetButton.UseVisualStyleBackColor = false;
            // 
            // IntegratorTableLayoutPanel
            // 
            this.IntegratorTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntegratorTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.IntegratorTableLayoutPanel.ColumnCount = 2;
            this.IntegratorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IntegratorTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.IntegratorTableLayoutPanel.Controls.Add(this.IntegratorExportToExcelButton, 1, 3);
            this.IntegratorTableLayoutPanel.Controls.Add(this.IntegratorTitleLabel, 0, 0);
            this.IntegratorTableLayoutPanel.Controls.Add(this.IntegratorResetButton, 1, 1);
            this.IntegratorTableLayoutPanel.Controls.Add(this.IntegratorStartButton, 0, 1);
            this.IntegratorTableLayoutPanel.Controls.Add(this.tableLayoutPanel8, 1, 2);
            this.IntegratorTableLayoutPanel.Controls.Add(this.tableLayoutPanel16, 0, 2);
            this.IntegratorTableLayoutPanel.Location = new System.Drawing.Point(3, 399);
            this.IntegratorTableLayoutPanel.Name = "IntegratorTableLayoutPanel";
            this.IntegratorTableLayoutPanel.RowCount = 4;
            this.IntegratorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.IntegratorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.IntegratorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.IntegratorTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.IntegratorTableLayoutPanel.Size = new System.Drawing.Size(370, 309);
            this.IntegratorTableLayoutPanel.TabIndex = 0;
            // 
            // IntegratorExportToExcelButton
            // 
            this.IntegratorExportToExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntegratorExportToExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.IntegratorExportToExcelButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.IntegratorExportToExcelButton.ForeColor = System.Drawing.Color.White;
            this.IntegratorExportToExcelButton.Image = global::GPMLink.Properties.Resources.ExportToExcel_16x;
            this.IntegratorExportToExcelButton.Location = new System.Drawing.Point(185, 233);
            this.IntegratorExportToExcelButton.Margin = new System.Windows.Forms.Padding(0);
            this.IntegratorExportToExcelButton.Name = "IntegratorExportToExcelButton";
            this.IntegratorExportToExcelButton.Size = new System.Drawing.Size(185, 76);
            this.IntegratorExportToExcelButton.TabIndex = 3;
            this.IntegratorExportToExcelButton.Text = " EXPORT DATA...";
            this.IntegratorExportToExcelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IntegratorExportToExcelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IntegratorExportToExcelButton.UseVisualStyleBackColor = false;
            // 
            // IntegratorTitleLabel
            // 
            this.IntegratorTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntegratorTitleLabel.AutoSize = true;
            this.IntegratorTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.IntegratorTableLayoutPanel.SetColumnSpan(this.IntegratorTitleLabel, 2);
            this.IntegratorTitleLabel.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntegratorTitleLabel.ForeColor = System.Drawing.Color.White;
            this.IntegratorTitleLabel.Location = new System.Drawing.Point(0, 2);
            this.IntegratorTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IntegratorTitleLabel.Name = "IntegratorTitleLabel";
            this.IntegratorTitleLabel.Size = new System.Drawing.Size(370, 23);
            this.IntegratorTitleLabel.TabIndex = 36;
            this.IntegratorTitleLabel.Text = "INTEGRATOR";
            this.IntegratorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IntegratorResetButton
            // 
            this.IntegratorResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntegratorResetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.IntegratorResetButton.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.IntegratorResetButton.ForeColor = System.Drawing.Color.White;
            this.IntegratorResetButton.Image = global::GPMLink.Properties.Resources.CleanData_16x;
            this.IntegratorResetButton.Location = new System.Drawing.Point(188, 28);
            this.IntegratorResetButton.Name = "IntegratorResetButton";
            this.IntegratorResetButton.Size = new System.Drawing.Size(179, 64);
            this.IntegratorResetButton.TabIndex = 23;
            this.IntegratorResetButton.Text = "RESET DATA";
            this.IntegratorResetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IntegratorResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IntegratorResetButton.UseVisualStyleBackColor = false;
            // 
            // IntegratorStartButton
            // 
            this.IntegratorStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntegratorStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(96)))), ((int)(((byte)(16)))));
            this.IntegratorStartButton.Font = new System.Drawing.Font("Bahnschrift", 16F);
            this.IntegratorStartButton.ForeColor = System.Drawing.Color.White;
            this.IntegratorStartButton.Image = global::GPMLink.Properties.Resources.StartWithoutDebug_16x;
            this.IntegratorStartButton.Location = new System.Drawing.Point(3, 28);
            this.IntegratorStartButton.Name = "IntegratorStartButton";
            this.IntegratorStartButton.Size = new System.Drawing.Size(179, 64);
            this.IntegratorStartButton.TabIndex = 22;
            this.IntegratorStartButton.Text = "START";
            this.IntegratorStartButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IntegratorStartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IntegratorStartButton.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.IgnoreNegativesCheckBox, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(188, 98);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(179, 72);
            this.tableLayoutPanel8.TabIndex = 34;
            // 
            // IgnoreNegativesCheckBox
            // 
            this.IgnoreNegativesCheckBox.AutoSize = true;
            this.IgnoreNegativesCheckBox.Checked = true;
            this.IgnoreNegativesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreNegativesCheckBox.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IgnoreNegativesCheckBox.Location = new System.Drawing.Point(3, 3);
            this.IgnoreNegativesCheckBox.Name = "IgnoreNegativesCheckBox";
            this.IgnoreNegativesCheckBox.Size = new System.Drawing.Size(133, 17);
            this.IgnoreNegativesCheckBox.TabIndex = 40;
            this.IgnoreNegativesCheckBox.Text = "Absolute Readings";
            this.IgnoreNegativesCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 1;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.IntegratorTimeLabel, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.LabelCursor, 0, 1);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 98);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(174, 72);
            this.tableLayoutPanel16.TabIndex = 40;
            // 
            // IntegratorTimeLabel
            // 
            this.IntegratorTimeLabel.AutoSize = true;
            this.IntegratorTimeLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9F);
            this.IntegratorTimeLabel.Location = new System.Drawing.Point(3, 3);
            this.IntegratorTimeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.IntegratorTimeLabel.Name = "IntegratorTimeLabel";
            this.IntegratorTimeLabel.Size = new System.Drawing.Size(82, 14);
            this.IntegratorTimeLabel.TabIndex = 34;
            this.IntegratorTimeLabel.Text = "Not started yet.";
            // 
            // LabelCursor
            // 
            this.LabelCursor.AutoSize = true;
            this.LabelCursor.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9F);
            this.LabelCursor.Location = new System.Drawing.Point(3, 26);
            this.LabelCursor.Margin = new System.Windows.Forms.Padding(3);
            this.LabelCursor.Name = "LabelCursor";
            this.LabelCursor.Size = new System.Drawing.Size(60, 14);
            this.LabelCursor.TabIndex = 41;
            this.LabelCursor.Text = "Cursors off.";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GPM8310ToolstripButton,
            this.toolStripStatusLabel1,
            this.ReadingPointsStatusLabel,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 712);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1266, 29);
            this.StatusStrip1.TabIndex = 4;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // GPM8310ToolstripButton
            // 
            this.GPM8310ToolstripButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GPM8310ToolstripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupToolStripMenuItem,
            this.DeviceTranscriptToolStripMenuItem,
            this.KnownDeviceListToolStripMenuItem,
            this.toolStripSeparator4,
            this.ReadingsFrequencyToolStripMenuItem,
            this.toolStripSeparator1,
            this.InputsToolStripMenuItem,
            this.toolStripSeparator3,
            this.IntegratorToolStripMenuItem1,
            this.toolStripSeparator2,
            this.DeviceConnectToolStripMenuItem});
            this.GPM8310ToolstripButton.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPM8310ToolstripButton.ForeColor = System.Drawing.Color.Black;
            this.GPM8310ToolstripButton.Image = global::GPMLink.Properties.Resources.gpm_8310_128;
            this.GPM8310ToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GPM8310ToolstripButton.Name = "GPM8310ToolstripButton";
            this.GPM8310ToolstripButton.Size = new System.Drawing.Size(105, 27);
            this.GPM8310ToolstripButton.Text = "GPM8310";
            this.GPM8310ToolstripButton.ToolTipText = "Device Control and Properties Menu";
            // 
            // SetupToolStripMenuItem
            // 
            this.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem";
            this.SetupToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.SetupToolStripMenuItem.Text = "Setup...";
            this.SetupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // DeviceTranscriptToolStripMenuItem
            // 
            this.DeviceTranscriptToolStripMenuItem.Name = "DeviceTranscriptToolStripMenuItem";
            this.DeviceTranscriptToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.DeviceTranscriptToolStripMenuItem.Text = "Transcript...";
            this.DeviceTranscriptToolStripMenuItem.Click += new System.EventHandler(this.transcriptToolStripMenuItem_Click);
            // 
            // KnownDeviceListToolStripMenuItem
            // 
            this.KnownDeviceListToolStripMenuItem.Name = "KnownDeviceListToolStripMenuItem";
            this.KnownDeviceListToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.KnownDeviceListToolStripMenuItem.Text = "Device List";
            this.KnownDeviceListToolStripMenuItem.Click += new System.EventHandler(this.deviceListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // ReadingsFrequencyToolStripMenuItem
            // 
            this.ReadingsFrequencyToolStripMenuItem.Name = "ReadingsFrequencyToolStripMenuItem";
            this.ReadingsFrequencyToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.ReadingsFrequencyToolStripMenuItem.Text = "Readings Frequency";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // InputsToolStripMenuItem
            // 
            this.InputsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputModeToolStripMenuItem1,
            this.InputVoltageRangeToolStripMenuItem,
            this.InputCurrentRangeToolStripMenuItem});
            this.InputsToolStripMenuItem.Name = "InputsToolStripMenuItem";
            this.InputsToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.InputsToolStripMenuItem.Text = "Inputs";
            // 
            // InputModeToolStripMenuItem1
            // 
            this.InputModeToolStripMenuItem1.Name = "InputModeToolStripMenuItem1";
            this.InputModeToolStripMenuItem1.Size = new System.Drawing.Size(157, 28);
            this.InputModeToolStripMenuItem1.Text = "InputMode";
            // 
            // InputVoltageRangeToolStripMenuItem
            // 
            this.InputVoltageRangeToolStripMenuItem.Name = "InputVoltageRangeToolStripMenuItem";
            this.InputVoltageRangeToolStripMenuItem.Size = new System.Drawing.Size(157, 28);
            this.InputVoltageRangeToolStripMenuItem.Text = "VRange";
            // 
            // InputCurrentRangeToolStripMenuItem
            // 
            this.InputCurrentRangeToolStripMenuItem.Name = "InputCurrentRangeToolStripMenuItem";
            this.InputCurrentRangeToolStripMenuItem.Size = new System.Drawing.Size(157, 28);
            this.InputCurrentRangeToolStripMenuItem.Text = "IRange";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // IntegratorToolStripMenuItem1
            // 
            this.IntegratorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IntegratorStatusToolStripMenuItem,
            this.IntegratorStartPauseToolStripMenuItem,
            this.IntegratorStopResetToolStripMenuItem});
            this.IntegratorToolStripMenuItem1.Name = "IntegratorToolStripMenuItem1";
            this.IntegratorToolStripMenuItem1.Size = new System.Drawing.Size(228, 28);
            this.IntegratorToolStripMenuItem1.Text = "Integrator";
            // 
            // IntegratorStatusToolStripMenuItem
            // 
            this.IntegratorStatusToolStripMenuItem.Name = "IntegratorStatusToolStripMenuItem";
            this.IntegratorStatusToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.IntegratorStatusToolStripMenuItem.Text = "IntStatus";
            // 
            // IntegratorStartPauseToolStripMenuItem
            // 
            this.IntegratorStartPauseToolStripMenuItem.Name = "IntegratorStartPauseToolStripMenuItem";
            this.IntegratorStartPauseToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.IntegratorStartPauseToolStripMenuItem.Text = "IntStartPause";
            // 
            // IntegratorStopResetToolStripMenuItem
            // 
            this.IntegratorStopResetToolStripMenuItem.Name = "IntegratorStopResetToolStripMenuItem";
            this.IntegratorStopResetToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.IntegratorStopResetToolStripMenuItem.Text = "IntStopReset";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // DeviceConnectToolStripMenuItem
            // 
            this.DeviceConnectToolStripMenuItem.Name = "DeviceConnectToolStripMenuItem";
            this.DeviceConnectToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.DeviceConnectToolStripMenuItem.Text = "Connect";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 12F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 24);
            this.toolStripStatusLabel1.Text = "Data Buffer:";
            // 
            // ReadingPointsStatusLabel
            // 
            this.ReadingPointsStatusLabel.AutoSize = false;
            this.ReadingPointsStatusLabel.BackColor = System.Drawing.Color.White;
            this.ReadingPointsStatusLabel.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadingPointsStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.ReadingPointsStatusLabel.Name = "ReadingPointsStatusLabel";
            this.ReadingPointsStatusLabel.Size = new System.Drawing.Size(120, 24);
            this.ReadingPointsStatusLabel.Text = "0 Points";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.BackColor = System.Drawing.Color.White;
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.Lime;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(120, 23);
            this.toolStripProgressBar1.Step = 360;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar1.ToolTipText = "Amount of data available";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.liveReadingsControl1);
            this.splitContainer1.Panel1.Controls.Add(this.InputModeTableLayoutPanel);
            this.splitContainer1.Panel1.Controls.Add(this.IntegratorTableLayoutPanel);
            this.splitContainer1.Panel1.Controls.Add(this.ReadingsStatsTableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpmPlotControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1266, 709);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 5;
            // 
            // liveReadingsControl1
            // 
            this.liveReadingsControl1.Font = new System.Drawing.Font("Bahnschrift", 15.75F);
            this.liveReadingsControl1.Location = new System.Drawing.Point(0, 66);
            this.liveReadingsControl1.Margin = new System.Windows.Forms.Padding(0);
            this.liveReadingsControl1.Name = "liveReadingsControl1";
            this.liveReadingsControl1.ParentDevice = null;
            this.liveReadingsControl1.Size = new System.Drawing.Size(370, 250);
            this.liveReadingsControl1.TabIndex = 27;
            // 
            // ReadingsStatsTableLayoutPanel
            // 
            this.ReadingsStatsTableLayoutPanel.ColumnCount = 2;
            this.ReadingsStatsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ReadingsStatsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsStatsTableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.ReadingsStatsTableLayoutPanel.Controls.Add(this.ReadingsLiveStatsValuesTableLayoutPanel, 1, 1);
            this.ReadingsStatsTableLayoutPanel.Controls.Add(this.ReadingsStatsResetTableLayoutPanel, 0, 1);
            this.ReadingsStatsTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ReadingsStatsTableLayoutPanel.Location = new System.Drawing.Point(3, 324);
            this.ReadingsStatsTableLayoutPanel.Name = "ReadingsStatsTableLayoutPanel";
            this.ReadingsStatsTableLayoutPanel.RowCount = 2;
            this.ReadingsStatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReadingsStatsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReadingsStatsTableLayoutPanel.Size = new System.Drawing.Size(370, 72);
            this.ReadingsStatsTableLayoutPanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ReadingsStatsTableLayoutPanel.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "STATISTICS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gpmPlotControl1
            // 
            this.gpmPlotControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpmPlotControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.gpmPlotControl1.Font = new System.Drawing.Font("Bahnschrift", 15.75F);
            this.gpmPlotControl1.ForeColor = System.Drawing.Color.White;
            this.gpmPlotControl1.HasAutoScale = false;
            this.gpmPlotControl1.HasGradientFill = false;
            this.gpmPlotControl1.Location = new System.Drawing.Point(0, 0);
            this.gpmPlotControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gpmPlotControl1.Name = "gpmPlotControl1";
            this.gpmPlotControl1.ParentDevice = null;
            this.gpmPlotControl1.ShallPlotOnlyWhenIntegrating = true;
            this.gpmPlotControl1.Size = new System.Drawing.Size(882, 707);
            this.gpmPlotControl1.TabIndex = 0;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(133, 24);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // Gpm8310Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1266, 741);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Gpm8310Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "GPM-8310";
            this.Load += new System.EventHandler(this.Gpm8310Form_Load);
            this.ReadingsLiveStatsValuesTableLayoutPanel.ResumeLayout(false);
            this.ReadingsLiveStatsValuesTableLayoutPanel.PerformLayout();
            this.InputModeTableLayoutPanel.ResumeLayout(false);
            this.InputModeTableLayoutPanel.PerformLayout();
            this.InputModeButtonsTableLayoutPanel.ResumeLayout(false);
            this.ReadingsStatsResetTableLayoutPanel.ResumeLayout(false);
            this.IntegratorTableLayoutPanel.ResumeLayout(false);
            this.IntegratorTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ReadingsStatsTableLayoutPanel.ResumeLayout(false);
            this.ReadingsStatsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton GPM8310ToolstripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel IntegratorTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel ReadingsLiveStatsValuesTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ReadingsStatsResetTableLayoutPanel;
        private System.Windows.Forms.Label IAvgLabel;
        private System.Windows.Forms.Label PAvgLabel;
        private System.Windows.Forms.Label UAvgLabel;
        private System.Windows.Forms.Label UMaxLabel;
        private System.Windows.Forms.Label IMaxLabel;
        private System.Windows.Forms.Label PMaxLabel;
        private System.Windows.Forms.Button ReadingsStatsMinResetButton;
        private System.Windows.Forms.Button ReadingsStatsMaxResetButton;
        private System.Windows.Forms.ContextMenuStrip ModesContextMenuStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.ToolStripMenuItem DeviceTranscriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KnownDeviceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label IntegratorTimeLabel;
        private System.Windows.Forms.TableLayoutPanel InputModeTableLayoutPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel InputModeButtonsTableLayoutPanel;
        private System.Windows.Forms.Label IntegratorTitleLabel;
        private System.Windows.Forms.Button InputModeACDCButton;
        private System.Windows.Forms.Button InputModeDCButton;
        private System.Windows.Forms.Button InputModeACButton;
        private System.Windows.Forms.Button IntegratorResetButton;
        private System.Windows.Forms.Button IntegratorStartButton;
        private System.Windows.Forms.Label LabelCursor;
        private System.Windows.Forms.CheckBox IgnoreNegativesCheckBox;
        private System.Windows.Forms.ToolStripMenuItem DeviceConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem InputsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InputModeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem InputVoltageRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InputCurrentRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem IntegratorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem IntegratorStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IntegratorStartPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IntegratorStopResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ReadingPointsStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ReadingsFrequencyToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel ReadingsStatsTableLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private GPMLib.UI.Winforms.GpmPlotControl gpmPlotControl1;
        private GPMLib.UI.Winforms.LiveReadingsControl liveReadingsControl1;
        private System.Windows.Forms.Button IntegratorExportToExcelButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}