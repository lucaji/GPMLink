using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using GPMLib;
using static GPMLib.DataReadings;
using static GPMLib.INTEGrator;
using static GPMLib.MODE;


#nullable enable

namespace GPMLink {

    public partial class Gpm8310Form : Form, IParentDevice {

        private GPMDevice _ParentDevice;
        public GPMDevice ParentDevice { 
            get { 
                return _ParentDevice;
            }
            private set {
                _ParentDevice = value;
                this.SetWindowTitleForDevice();
            }
        }
        
        public void UpdateTargetValuePercentagesList() {
            //var tv = SettingsManager.Singleton.ReloadTargetPercentagesList(GPMLink.Properties.Settings.Default.TargetValues);
            //this.IntegratorTargetValuesOlv.ClearObjects();
            //this.IntegratorTargetValuesOlv.SetObjects(tv);
        }

        #region Form Lifecycle

        public Gpm8310Form(GPMDevice? d, string title = "GPM-8310") {
            InitializeComponent();
            if (d is null) { d = GPMDevice.DefaultLocal; }
            _ParentDevice = d;
            this.gpmPlotControl1.ParentDevice = d;
            this.liveReadingsControl1.ParentDevice = d;
        }


        private void Gpm8310Form_Load(object sender, EventArgs e) {
            this.toolStripStatusLabel2.Text = Properties.Resources.FullVersionString;
            this.FormClosing += (s, e) => {
                var shallStay = this.Disconnect();
                e.Cancel = !shallStay;
            };

            this.Activated += (s, e) => {
                if (this.ParentDevice.IsLocal) {
                    var f = new DeviceAddressAndNameForm(GPMDevice.DefaultLocal);
                    var result = f.ShowDialog();
                    if (result == DialogResult.OK) {
                        var model = new GPMDevice(f.DeviceIpAddress, f.DeviceName);
                        this.ParentDevice = model;
                        SettingsManager.Singleton.UpdateFavouriteDeviceListStoreWith(model);
                    } else { this.Close(); return; }
                }
                UpdateUIThreadSafe();
            };


            // setup power unit display selection
            foreach (var m in PowerDisplayOptions) {
                ToolStripButton tb = new(m.Item3);
                tb.Click += (s,e) => {
                    var d = DisplayPowerOptionForLongString(s.ToString());
                    this.ParentDevice.TheStats.PowerUnitDisplayOption = d;
                };
                ModesContextMenuStrip.Items.Add(tb);
            }
            ModesContextMenuStrip.Opening += (sender, e) => {
                var s = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode.ToString();
                foreach (ToolStripButton m in ModesContextMenuStrip.Items) {
                    var k = DisplayPowerOptionForLongString(m.ToString());
                    m.Checked = k == ParentDevice.TheStats.PowerUnitDisplayOption;
                }
            };
            

            foreach (var vr in ReadingsFrequency.ReadingsFrequenciesList) {
                ToolStripButton tb = new(vr);
                tb.Click += (s,e) => {
                    var ts = s.ToString();
                    ParentDevice.NetworkLink.ChangeReadingsFrequency(ts);
                };
                ReadingsFrequencyToolStripMenuItem.DropDownItems.Add(tb);
            }
            ReadingsFrequencyToolStripMenuItem.DropDownOpening += (sender, e) => {
                var s = ParentDevice.NetworkLink.CurrentReadingFrequencyString;
                foreach (ToolStripButton m in ReadingsFrequencyToolStripMenuItem.DropDownItems) {
                    m.Checked = m.Text == s;
                }
            };

            

            InputModeSetupUI();
            RangesSetupUI();
            IntegratorSetupUI();

            this.DeviceConnectToolStripMenuItem.Click += (s, e) => {
                ConnectionToggle();
            };
            this.GPM8310ToolstripButton.DropDownOpening += (sender, e) => {
                DeviceConnectToolStripMenuItem.Text = ParentDevice.IsConnected ? "Disconnect" : "Connect";
            };


            // INPUT MODE SELECTION BUTTONS
            this.InputModeACButton.Click += InputModeButtons_Click;
            this.InputModeDCButton.Click += InputModeButtons_Click;
            this.InputModeACDCButton.Click += InputModeButtons_Click;

            

            // STATS RESET BUTTONS
            this.ReadingsStatsMaxResetButton.Click += (s, e) => {
                this.ParentDevice.TheStats.StatsResetMax();
                UIStats_DisplayAverages();
            };
            this.ReadingsStatsMinResetButton.Click += (s, e) => {
                this.ParentDevice.TheStats.StatsResetMin();
                UIStats_DisplayAverages();
            };

            // STATS TARGET VALUES
            //IntegratorTargetValuesOlv.SetObjects(SettingsManager.Singleton.TargetPercentagesList);
            //IntegratorTargetValuesOlv.SelectedIndexChanged += (s, e) => {
            //    if (s is not ObjectListView olv) { return; }
            //    IntegratorTargetValueDelButton.Enabled = this.IntegratorTargetValuesOlv.SelectedObject is not null;
            //};
            //IntegratorTargetValueAddButton.Click += (s, e) => {
            //    var pf = new TargetPercentageForm();
            //    var result = pf.ShowDialog();
            //    if (result == DialogResult.OK) {
            //        IntegratorTargetValuesOlv.SetObjects(SettingsManager.Singleton.TargetPercentagesList);
            //    }
            //};

            //IntegratorTargetValueDelButton.Click += (s, e) => {
            //    if (this.IntegratorTargetValuesOlv.SelectedObject is not PowerTargetValueViewModel val) { return; }
            //    SettingsManager.Singleton.RemoveTargetPercentageFromStore(val);
            //};

            IntegratorExportToExcelButton.Click += (s, e) => {
                WinformsManager.Singleton.ReportAsExcel(this.ParentDevice, SelectedData());
            };


            IgnoreNegativesCheckBox.CheckedChanged += (s, e) => {
                DataSample.IgnoreNegatives = IgnoreNegativesCheckBox.Checked;
                if (IgnoreNegativesCheckBox.Checked) {
                    //PlotScaleOnlyPositive();
                }
            };

            

            SetWindowTitleForDevice();

            // TOOLSTRIP PROGRESS BAR
            this.toolStripProgressBar1.Minimum = 0;
            //this.toolStripProgressBar1.Maximum = GpmPlot.DataLimit;
            this.toolStripProgressBar1.Click += (s, e) => {
                this.ReadingPointsStatusLabel.Visible = true;
                this.toolStripProgressBar1.Visible = false;
            };
            this.ReadingPointsStatusLabel.Click += (s, e) => {
                this.ReadingPointsStatusLabel.Visible = false;
                this.toolStripProgressBar1.Visible = true;
            };

            UpdateTargetValuePercentagesList();
        }

        public void SetWindowTitleForDevice() {
            if (ParentDevice is not null) {
                this.Text = ParentDevice.ToString();
            } else {
                this.Text = "GPM8310";
            }
        }

        private void InputModeButtons_Click(object sender, EventArgs e) {
            if (this.ParentDevice.IsIntegrating) {
                MessageBox.Show("Reset the integrator first.");
                return;
            }
            if (sender is not Button c) { return; }
            _ = ParentDevice.DeviceInputs.DeviceInputMode.SetDeviceInputMode(c.Tag.ToString());
        }


        static Color ProgressBarGetColorForValue(int rangeStart, int rangeEnd, int actualValue) {
            if (rangeStart >= rangeEnd) return Color.Black;

            int max = rangeEnd - rangeStart; // make the scale start from 0
            int value = actualValue - rangeStart; // adjust the value accordingly

            //int green = (255 * value) / max; // calculate green (the closer the value is to max, the greener it gets)
            //int red = 255 - green; // set red as inverse of green

            int red = (255 * value) / max; // calculate red (the closer the value is to max, the red it gets)
            int green = 255 - red; // set green as inverse of red
            return Color.FromArgb(255, (byte)red, (byte)green, (byte)0);
        }

        #endregion

        #region connection hook

        /// <summary>
        /// If connected, disconnects and viceversa.
        /// </summary>
        void ConnectionToggle() {
            if (ParentDevice.IsConnected) {
                Disconnect(false);
            } else {
                Connect();
            }
        }

        void Connect() {
            if (ParentDevice.IsConnected) { Console.WriteLine("already connected"); return; }
            ParentDevice.NetworkLink.GetLiveReadingsEvent += TheGPM_GetReadingsEvent;
            ParentDevice.NetworkLink.ConfigurationChangeEvent += TheGPM_ConfigurationChangeEvent;
            ParentDevice.NetworkLink.Connect().ConfigureAwait(false);
        }

        /// <summary>
        /// Disconnect GPM - UI hook
        /// </summary>
        /// <param name="askConfirmation">default true, will ask for confirmation</param>
        /// <returns>false if shall stay connected (cancelled), true if shall disconnect.</returns>
        bool Disconnect(bool askConfirmation = true) {
            if (askConfirmation && ParentDevice.IsConnected) {
                var caption = ParentDevice.IsIntegrating ? "The INTEGRATOR is still running." : "Still connected to " + this.ParentDevice.DeviceIPAddress + ".";
                var result = MessageBox.Show("You are sure you want to disconnect?", caption, MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return false; }
            }
            ParentDevice.NetworkLink.GetLiveReadingsEvent -= TheGPM_GetReadingsEvent;
            ParentDevice.NetworkLink.ConfigurationChangeEvent -= TheGPM_ConfigurationChangeEvent;
            ParentDevice.NetworkLink.Disconnect();
            return true;
        }

        #endregion

        #region Readings


        private void TheGPM_GetReadingsEvent(object sender, DataSample e) {
            // In main thread
            void ProcessReading(DataSample? reading) {
                if (this.ParentDevice.TheStats.LastReading is null) { return; }


                //if (ShallPlotOnlyWhenIntegrating) {
                //var barValue = this.ReadingsPlot.NextDataIndex;
                //if (barValue > this.toolStripProgressBar1.Maximum) {
                //    this.ReadingPointsStatusLabel.Text = "Data Buffer Full";
                //} else {
                //    var bv = barValue > 1000 ? (barValue / 1000).ToString("0") + "k" : barValue.ToString();
                //    this.ReadingPointsStatusLabel.Text = "Readings: " + bv + " of " + (GpmPlot.DataLimit / 1000).ToString("0") + "k";
                //    this.toolStripProgressBar1.Value = barValue;
                //    this.toolStripProgressBar1.ForeColor =
                //    this.ReadingPointsStatusLabel.ForeColor = ProgressBarGetColorForValue(0, GpmPlot.DataLimit, barValue);
                //}
                //}



                //IntegratorTimeLabel.Text = "Total: " + TimeSpan.FromSeconds(this.ParentDevice.TheStats.LastReading.IntegratorTime).FormatToString();
                UIStats_DisplayAverages();
            }
            if (InvokeRequired) {
                this.Invoke(new Action(() => ProcessReading(e)));
            } else {
                ProcessReading(e);
            }
        }



        private void TheGPM_ConfigurationChangeEvent(object sender, object? e) { 
            UpdateUIThreadSafe();
        }


        



        #endregion


        void UpdateUIThreadSafe() {
            void DoUpdateAction() {
                // INPUT MODE PANEL
                InputModeTableLayoutPanel.Visible =

                // READINGS STATS PANEL
                ReadingsStatsTableLayoutPanel.Enabled =
                ReadingsStatsMaxResetButton.Visible =
                ReadingsStatsMinResetButton.Visible =

                // INTEGRATOR TARGET VALUES PANEL
                //IntegratorTargetValuesTableLayoutPanel.Enabled =
                //IntegratorTargetValueAddButton.Visible =
                //IntegratorTargetValueDelButton.Visible =
                IntegratorExportToExcelButton.Visible =

                LabelCursor.Visible = this.ParentDevice.IsConnected;

                InputModeUpdateUI();
                RangesUpdateUI();

                string? prefix = null;
                switch (this.ParentDevice.TheStats.PowerUnitDisplayOption) {
                    case DisplayPowerOptionsEnum.DisplayVA:
                        prefix = this.ParentDevice.TheStats.LastReading?.PowerUnit;
                        break;
                    case DisplayPowerOptionsEnum.DisplayWh:
                        prefix = this.ParentDevice.TheStats.LastReading?.WhUnit;
                        break;
                    case DisplayPowerOptionsEnum.DisplayAh:
                        prefix = this.ParentDevice.TheStats.LastReading?.AhUnit;
                        break;
                }

                ReadingsFrequencyToolStripMenuItem.Enabled = !ParentDevice.IsIntegrating;

                IntegratorUpdateUI();
                UpdateVaWhButtonStyles();
                RecalculateWh();
            }
            if (InvokeRequired) { 
                this.Invoke(new Action(() => DoUpdateAction())); 
            } else {
                DoUpdateAction();
            }
        }



        #region Log To File (unimplemented)


        private void LogToFileToolStripMenuItem_Click(object sender, EventArgs e) {
            //if (TheFileLogger is null) {
            //    // start recording to file
            //    var filename = "GPM8310 Log " + StringUtils.DateNowFileFormat();
            //    var sfd = new SaveFileDialog {
            //        FileName = filename + ".csv",
            //        Filter = "CSV Files (*.csv)|*.csv;*.csv" +
            //                 "|TXT Files (*.txt)|*.txt;*.txt" +
            //                 "|All files (*.*)|*.*"
            //    };

            //    if (sfd.ShowDialog() == DialogResult.OK) {
            //        TheFileLogger = new LogWriter(sfd.FileName);
            //    }
            //} else {
            //    // stop recording to file
            //    TheFileLogger = null;
            //}
        }


        #endregion

        #region Input Mode Handling

        void InputModeSetupUI() {
            foreach (var vr in MODE.InputModeListList) {
                ToolStripButton tb = new(vr.Item2);
                tb.Click += (s, e) => {
                    if (this.ParentDevice.IsIntegrating) { return; }
                    _ = ParentDevice.DeviceInputs.DeviceInputMode.SetDeviceInputMode(s.ToString());
                };
                InputModeToolStripMenuItem1.DropDownItems.Add(tb);
            }
            InputModeToolStripMenuItem1.DropDownOpening += (sender, e) => {
                if (sender is not ToolStripMenuItem tsb) { return; }
                var im = ParentDevice.DeviceInputs.DeviceInputMode.ToString();
                foreach (ToolStripButton m in tsb.DropDownItems) {
                    m.Checked = m.Text == im;
                }
            };
        }

        void InputModeUpdateUI() {
            InputModeACButton.ForeColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACRMS ? Color.Red : Color.White;
            InputModeACButton.BackColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACRMS ? Color.DarkRed : Color.FromArgb(32, 32, 32);
            InputModeDCButton.ForeColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.DC ? Color.SpringGreen : Color.White;
            InputModeDCButton.BackColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.DC ? Color.DarkGreen : Color.FromArgb(32, 32, 32);
            InputModeACDCButton.ForeColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACDC ? Color.Yellow : Color.White;
            InputModeACDCButton.BackColor = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACDC ? Color.DarkGoldenrod : Color.FromArgb(32, 32, 32);
            if (ParentDevice.IsIntegrating) {
                this.InputModeACButton.Enabled = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACRMS;
                this.InputModeDCButton.Enabled = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.DC;
                this.InputModeACDCButton.Enabled = ParentDevice.DeviceInputs.DeviceInputMode.DeviceInputMode == DeviceInputModeEnum.ACDC;
            } else {
                this.InputModeACButton.Enabled =
                this.InputModeDCButton.Enabled =
                this.InputModeACDCButton.Enabled = true;
            }
        }

        #endregion

        #region Ranges Handling

        ToolStripButton[]? _CurrentRangeOptionsToolStripButtonList;
        public ToolStripButton[] CurrentRangeOptionsToolStripButtonList {
            get {
                if (_CurrentRangeOptionsToolStripButtonList is null) {
                    var n = CURRent.CurrentRangesList.Count;
                    _CurrentRangeOptionsToolStripButtonList = new ToolStripButton[n];
                    int i = 0;
                    foreach (var cr in CURRent.CurrentRangesList) {
                        ToolStripButton tb = new(cr.Item2);
                        tb.Click += (s, e) => {
                            if (this.ParentDevice.IsIntegrating) { return; }
                            var t = s.ToString();
                            if (t.Equals("Auto")) {
                                _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRangeAuto(true);
                            } else {
                                var ir = CURRent.CurrentRangeFromStringWithUnit(t);
                                _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRange(ir);
                            }
                        };
                        _CurrentRangeOptionsToolStripButtonList[i++] = tb;
                    }
                }
                return _CurrentRangeOptionsToolStripButtonList;
            }
        }

        ToolStripButton[]? _VoltageRangeOptionsToolStripButtonList;

        public ToolStripButton[] VoltageRangeOptionsToolStripButtonList {
            get {
                if (_VoltageRangeOptionsToolStripButtonList is null) {
                    var n = VOLTage.VoltageRangesList.Count;
                    _VoltageRangeOptionsToolStripButtonList = new ToolStripButton[n];
                    int i = 0;
                    foreach (var cr in VOLTage.VoltageRangesList) {
                        ToolStripButton tb = new(cr.Item2);
                        tb.Click += (s, e) => {
                            if (this.ParentDevice?.IsIntegrating ?? true) { return; }
                            var t = s.ToString();
                            if (t.Equals("Auto")) {
                                _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRangeAuto(true);
                            } else {
                                var vr = VOLTage.VoltageRangeFromStringWithUnit(t);
                                _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRange(vr);
                            }
                        };
                        _VoltageRangeOptionsToolStripButtonList[i++] = tb;
                    }
                }
                return _VoltageRangeOptionsToolStripButtonList;
            }
        }

        void RangesSetupUI() {
            //this.VAutoRangeLabel.Click += (s, e) => {
            //    var toggle = ParentDevice.DeviceInputs.DeviceVoltageRange.IsVoltageRangeAuto;
            //    _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRangeAuto(!toggle);
            //};
            //this.IAutoRangeLabel.Click += (s, e) => {
            //    var toggle = ParentDevice.DeviceInputs.DeviceCurrentRange.IsCurrentRangeAuto;
            //    _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRangeAuto(!toggle);
            //};

            InputVoltageRangeToolStripMenuItem.DropDownItems.AddRange(this.VoltageRangeOptionsToolStripButtonList);
            InputVoltageRangeToolStripMenuItem.DropDownOpening += (sender, e) => {
                if (sender is not ContextMenuStrip ts) { return; }
                if (ts is not IParentDevice pd) { return; }
                var s = pd.ParentDevice.DeviceInputs.DeviceVoltageRange.ToString();
                foreach (ToolStripButton m in ts.Items) {
                    m.Checked = m.Text == s;
                    m.Enabled = !pd.ParentDevice.IsIntegrating;
                }
            };
            InputCurrentRangeToolStripMenuItem.DropDownItems.AddRange(this.CurrentRangeOptionsToolStripButtonList);
            InputCurrentRangeToolStripMenuItem.DropDownOpening += (sender, e) => {
                if (sender is not ContextMenuStrip ts) { return; }
                if (ts is not IParentDevice pd) { return; }
                var s = pd.ParentDevice.DeviceInputs.DeviceCurrentRange.ToString();
                foreach (ToolStripButton m in ts.Items) {
                    m.Checked = m.Text == s;
                    m.Enabled = !pd.ParentDevice.IsIntegrating;
                }
            };
        }

        void RangesUpdateUI() {
            //VAutoRangeLabel.ForeColor = ParentDevice.DeviceInputs.DeviceVoltageRange.IsVoltageRangeAuto ? Color.White : Color.RoyalBlue;
            //VAutoRangeLabel.BackColor = ParentDevice.DeviceInputs.DeviceVoltageRange.IsVoltageRangeAuto ? Color.RoyalBlue : Color.FromArgb(32, 32, 32);

            //IAutoRangeLabel.ForeColor = ParentDevice.DeviceInputs.DeviceCurrentRange.IsCurrentRangeAuto ? Color.White : Color.Coral;
            //IAutoRangeLabel.BackColor = ParentDevice.DeviceInputs.DeviceCurrentRange.IsCurrentRangeAuto ? Color.Coral : Color.FromArgb(32, 32, 32);

            //VAutoRangeLabel.Text = ParentDevice.DeviceInputs.DeviceVoltageRange.ToString();
            //IAutoRangeLabel.Text = ParentDevice.DeviceInputs.DeviceCurrentRange.ToString();
        }

        #endregion

        #region Integrator Handling

        void IntegratorSetupUI() {
            // INTEGRATOR START
            this.IntegratorStartButton.Click += (s, e) => {
                IntegratorStartStopClick();
            };
            this.IntegratorStartPauseToolStripMenuItem.Click += (s, e) => {
                IntegratorStartStopClick();
            };
            // INTEGRATOR STOP
            this.IntegratorResetButton.Click += (s, e) => {
                _ = IntegratorReset(askConfirmation: true);
            };
            this.IntegratorStopResetToolStripMenuItem.Click += (s, e) => {
                _ = IntegratorReset(askConfirmation: true);
            };

            IntegratorToolStripMenuItem1.DropDownOpening += (sender, e) => {
                if (sender is not ToolStripMenuItem tsb) { return; }
                IntegratorStatusToolStripMenuItem.Text = "CURRENTLY " + ParentDevice.TheStats.IntegratorCommand.IntegratorStatusUIString();
                IntegratorStartPauseToolStripMenuItem.Text = ParentDevice.TheStats.IntegratorCommand.StartStopButtonText;
                IntegratorStopResetToolStripMenuItem.Text = ParentDevice.TheStats.IntegratorCommand.IntegratorResetUICommandString();
            };

        }

        void IntegratorUpdateUI() {
            IntegratorResetButton.Visible = ParentDevice.IsConnected && ParentDevice.TheStats.IntegratorCommand.IntegratorStatus != GPMIntegratorStatusEnum.Start;
            IntegratorStartButton.Text = ParentDevice.TheStats.IntegratorCommand.StartStopButtonText;
            IntegratorResetButton.Text = ParentDevice.TheStats.IntegratorCommand.IntegratorResetUICommandString();
            //IntegratorStartButton.ForeColor = ParentDevice.TheStats.IntegratorCommand.IntegratorStatusUIForegroundColor();

            if (ParentDevice.IsIntegrating) {
                this.IntegratorTitleLabel.BackColor = Color.Red;
                this.IntegratorTitleLabel.ForeColor = Color.White;
            } else {
                this.IntegratorTitleLabel.BackColor = Color.LightGray;
                this.IntegratorTitleLabel.ForeColor = Color.Black;
            }
            if (this.ParentDevice.IsConnected) {
                this.IntegratorTitleLabel.Text = "INTEGRATOR " + this.ParentDevice.TheStats.IntegratorCommand.IntegratorStatusUIString();
            } else {
                this.IntegratorTitleLabel.Text = "OFFLINE";
            }
        }


        void IntegratorStartStopClick() {
            async Task Start(bool resetIntegrator) {
                if (resetIntegrator) {
                    await ParentDevice.TheStats.IntegratorCommand.ResetIntegrator().ConfigureAwait(false);
                }
                await ParentDevice.TheStats.IntegratorCommand.StartIntegrator().ConfigureAwait(false);
            }

            if (ParentDevice.IsDisconnected) {
                this.Connect();
                return;
            }

            switch (this.ParentDevice.TheStats.IntegratorCommand.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    _ = this.ParentDevice.NetworkLink.Connect(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Error:
                    _ = Start(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    _ = Start(false).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Start:
                    _ = IntegratorStop(askConfirmation: false);
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    _ = Start(true).ConfigureAwait(false);
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    _ = Start(true).ConfigureAwait(false);
                    break;
            }

            if (ParentDevice.TheStats.IntegratorCommand.IntegratorStatus == GPMIntegratorStatusEnum.Start) {
                _ = IntegratorStop(askConfirmation: false);
            } else {
                _ = Start(false);
            }
        }

        async Task<bool> IntegratorStop(bool askConfirmation) {
            var result = DialogResult.OK;
            if (askConfirmation) {
                result = MessageBox.Show("Stop logging?", "Logging", MessageBoxButtons.OKCancel);
            }
            if (result == DialogResult.OK) {
                await ParentDevice.TheStats.IntegratorCommand.StopIntegrator(); return true;
            }
            return false;
        }

        async Task IntegratorReset(bool askConfirmation = true) {
            var result = DialogResult.OK;
            if (askConfirmation) {
                result = MessageBox.Show("Clear all collected data and reset integrator?", "Integrator", MessageBoxButtons.OKCancel);
            }
            if (result == DialogResult.OK) {
                this.ParentDevice.NetworkLink.ReadingsTimerStop();
                await ParentDevice.TheStats.IntegratorCommand.ResetIntegrator();
                ClearAllData();
                UpdateUIThreadSafe();
                this.ParentDevice.NetworkLink.ReadingsTimerStart();

            }
        }

        void ClearAllData() {
            this.gpmPlotControl1.DiagramReset();
            this.ParentDevice.TheStats.StatsAllReset();
            UIStats_DisplayAverages();
            if (this.gpmPlotControl1.Selection is not null) {
                this.gpmPlotControl1.Selection.IsVisible = false;
            }
        }

        #endregion

        #region POWER UNITS

       
        public double maxPForYScale {
            get {
                double m = 0.0;
                switch (this.ParentDevice.TheStats.PowerUnitDisplayOption) {
                    case DisplayPowerOptionsEnum.DisplayVA:
                        m = this.ParentDevice.TheStats.PMax;
                        break;
                    case DisplayPowerOptionsEnum.DisplayWh:
                        m = this.ParentDevice.TheStats.WhMax;
                        break;
                    case DisplayPowerOptionsEnum.DisplayAh:
                        m = this.ParentDevice.TheStats.AhMaxFormattedNoUnit();
                        break;
                }
                return Math.Ceiling(m);
            }
        }

        public double maxUForYScale { get { return Math.Ceiling(this.ParentDevice.TheStats.UMaxFormattedNoUnit()); } }
        public double maxIForYScale { get { return Math.Ceiling(this.ParentDevice.TheStats.IMaxFormattedNoUnit()); } }
        public double minIForYScale { get { return Math.Ceiling(this.ParentDevice.TheStats.IMinFormattedNoUnit()); } }

        void UpdateVaWhButtonStyles() {
            var o = PowerDisplayOptions.FirstOrDefault(p => p.Item1 == ParentDevice.TheStats.PowerUnitDisplayOption);
            //ModeLabel.Text = o.Item2;

            //ReadingsPowerUnitVAButton.ForeColor = o.Item1 == DisplayPowerOptionsEnum.DisplayVA ? Color.GreenYellow : Color.White;
            //ReadingsPowerUnitVAButton.BackColor = o.Item1 == DisplayPowerOptionsEnum.DisplayVA ? Color.DarkGreen : Color.Black;

            //ReadingsPowerUnitAhButton.ForeColor = o.Item1 == DisplayPowerOptionsEnum.DisplayAh ? Color.GreenYellow : Color.White;
            //ReadingsPowerUnitAhButton.BackColor = o.Item1 == DisplayPowerOptionsEnum.DisplayAh ? Color.DarkGreen : Color.Black;

            //ReadingsPowerUnitWhButton.ForeColor = o.Item1 == DisplayPowerOptionsEnum.DisplayWh ? Color.GreenYellow : Color.White;
            //ReadingsPowerUnitWhButton.BackColor = o.Item1 == DisplayPowerOptionsEnum.DisplayWh ? Color.DarkGreen : Color.Black;

            //gpmPlotControl1.UpdateWa(_PowerUnitDisplayOption, o.Item4);
        }

        public List<DataSample> SelectedData() {
            if (gpmPlotControl1.Selection is null) { 
                return this.ParentDevice.TheStats.LoggedReadings.ToList();
            }
            var startCursor = (int)gpmPlotControl1.Selection.X1;
            var endCursor = (int)gpmPlotControl1.Selection.X2;

            var results = this.ParentDevice.TheStats.ReadingsAt(startCursor, endCursor, SettingsManager.Singleton.TargetPercentagesList);
            return results;
        }

        void RecalculateWh() {
            var results = SelectedData();
            //this.IntegratorTargetValuesOlv.SetObjects(results);
            var min = results.FirstOrDefault();
            if (min is null) { return; }
            var max = results.LastOrDefault();
            if (max is null) { return; }
            var delta = Math.Abs(max.Ah - min.Ah);

            var aunit = "Ah";
            //LabelCursor.Text = (max.Duration - min.Duration).FormatToString() + " Δi =" + MeasurementValueFormatter.FormatDoubleWithUnit(delta, ref aunit);
        }


        #endregion

        #region STATS READINGS
        

        


        void UIStats_DisplayAverages() {

            void DisplayAverages() {
                UMaxLabel.Text = this.ParentDevice.TheStats.UMaxFormattedWithUnit();
                UAvgLabel.Text = this.ParentDevice.TheStats.UMinFormattedWithUnit();

                IMaxLabel.Text = this.ParentDevice.TheStats.IMaxFormattedWithUnit();
                IAvgLabel.Text = this.ParentDevice.TheStats.IMinFormattedWithUnit();

                switch (this.ParentDevice.TheStats.PowerUnitDisplayOption) {
                    case DisplayPowerOptionsEnum.DisplayVA:
                        PMaxLabel.Text = this.ParentDevice.TheStats.PMaxFormattedWithUnit();
                        PAvgLabel.Text = this.ParentDevice.TheStats.PMinFormattedWithUnit();
                        break;
                    case DisplayPowerOptionsEnum.DisplayWh:
                        PMaxLabel.Text = this.ParentDevice.TheStats.WhMaxFormattedWithUnit();
                        PAvgLabel.Text = this.ParentDevice.TheStats.WhMinFormattedWithUnit();
                        break;
                    case DisplayPowerOptionsEnum.DisplayAh:
                        PMaxLabel.Text = this.ParentDevice.TheStats.AhMaxFormattedWithUnit();
                        PAvgLabel.Text = this.ParentDevice.TheStats.AhMinFormattedWithUnit();
                        break;
                }
                
            }


            if (InvokeRequired) {
                this.Invoke(new Action(() => DisplayAverages()));
            } else {
                DisplayAverages();
            }

        }


        #endregion

        #region External Forms

        DeviceLogForm? TranscriptForm = null;

        private void transcriptToolStripMenuItem_Click(object sender, EventArgs e) {
            if (TranscriptForm is null || TranscriptForm.IsDisposed) {
                TranscriptForm = new DeviceLogForm(this.ParentDevice);
            }
            TranscriptForm.Show();
        }

        DeviceSetupForm? SetupForm = null;
        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SetupForm is null || SetupForm.IsDisposed) {
                SetupForm = new DeviceSetupForm(this.ParentDevice);
            }
            SetupForm.Show();
        }
        private void deviceListToolStripMenuItem_Click(object sender, EventArgs e) {
            //SettingsManager.Singleton.ShowKnownDeviceListForm();
        }


        #endregion




    }



}
