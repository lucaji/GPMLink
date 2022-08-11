using ScottPlot;
using ScottPlot.Plottable;
using ScottPlot.Renderable;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static GPMLib.DataReadings;

#nullable enable

namespace GPMLib.UI.Winforms {
    public partial class GpmPlotControl : UserControl, IParentDevice {


        GPMDevice? _ParentDevice;
        public GPMDevice? ParentDevice { 
            get => _ParentDevice; 
            set {
                _ParentDevice = value;
                if (_ParentDevice is not null) {
                    /// TODO: check for r nullability
                    _ParentDevice.NetworkLink.GetLiveReadingsEvent += (object sender, DataSample r) => {
                        if (sender is not GPMDevice d) { return; }
                        // bypass the plotting if not needed earlier here.
                        if (ShallPlotOnlyWhenIntegrating) {
                            var shallPlot = d.IsIntegrating;
                            if (!shallPlot) { return; }
                        }
                        if (this.InvokeRequired) {
                            this.Invoke(new Action(() => ProcessReading(r)));
                        } else {
                            ProcessReading(r);
                        }
                    };
                }
            } 
        }

        public bool ShallPlotOnlyWhenIntegrating { get; set; } = true;

        public const int DataLimit = 360_000; // 100 hours at 1 Hz rate

        void ProcessReading(DataSample r) {
            if (nextDataIndex >= DataLimit) {
                nextDataIndex = 1; // should check when overflowing (untested)
            }

            VoltageData[nextDataIndex] = r.Voltage;
            CurrentData[nextDataIndex] = r.Current;
            VAData[nextDataIndex] = r.Power;

            WattHoursData[nextDataIndex] = r.Wh;
            AmpHoursData[nextDataIndex] = r.Ah;

            if (voltagePlot is null) { return; }
            if (currentPlot is null) { return; }
            if (powerPlot is null) { return; }
            currentPlot.MaxRenderIndex =
            voltagePlot.MaxRenderIndex =
            powerPlot.MaxRenderIndex = nextDataIndex++;
            if (HasAutoScale) {
                ReadingsPlot.Plot.AxisAuto();
            }

            ReadingsPlot.Render(lowQuality: false, skipIfCurrentlyRendering: true);

        }

        public void DiagramReset() {
            nextDataIndex = 1;
            VoltageData = new double[DataLimit];
            CurrentData = new double[DataLimit];
            VAData = new double[DataLimit];

            WattHoursData = new double[DataLimit];
            AmpHoursData = new double[DataLimit];

            if (voltagePlot is null) { return; }
            if (currentPlot is null) { return; }
            if (powerPlot is null) { return; }
            powerPlot.MaxRenderIndex =
            currentPlot.MaxRenderIndex =
            voltagePlot.MaxRenderIndex = nextDataIndex;

            ReadingsPlot.Update();

            ReadingsPlot.Plot.AxisAuto();
        }

        public void UpdateWa(DisplayPowerOptionsEnum opt, string label) {
            if (powerPlot is null) { return; }
            if (yAxisW is null) { return; }
            powerPlot.IsVisible = false;
            yAxisW.Label(label);
            switch (opt) {
                case DisplayPowerOptionsEnum.DisplayVA:
                    powerPlot.Ys = VAData;
                    break;
                case DisplayPowerOptionsEnum.DisplayWh:
                    powerPlot.Ys = WattHoursData;
                    break;
                case DisplayPowerOptionsEnum.DisplayAh:
                    powerPlot.Ys = AmpHoursData;
                    break;
            }
            ReadingsPlot.Plot.AxisAuto();
            powerPlot.IsVisible = true;
            ReadingsPlot.Render(lowQuality: false, skipIfCurrentlyRendering: true);
        }

        public GpmPlotControl() {
            InitializeComponent();
        }


        int nextDataIndex = 1;
        public int NextDataIndex { get => nextDataIndex; }

        
        double[] VoltageData = new double[DataLimit];
        double[] CurrentData = new double[DataLimit];
        double[] VAData = new double[DataLimit];

        double[] WattHoursData = new double[DataLimit];
        double[] AmpHoursData = new double[DataLimit];


        SignalPlot? voltagePlot;
        SignalPlot? currentPlot;
        SignalPlot? powerPlot;


        Axis? yAxisI;
        Axis? yAxisW;

        HSpan? _Selection;
        public HSpan? Selection { get => _Selection; }

        void PlotScaleOnlyPositive() {
            ReadingsPlot.Plot.AxisAuto(null, null, 0, 0);
            ReadingsPlot.Plot.AxisAuto(null, null, 0, 2);
            ReadingsPlot.Plot.AxisAuto(null, null, 0, 3);
        }



        #region plot theming

        private bool _HasGradientFill = false;
        public bool HasGradientFill {
            get => _HasGradientFill;
            set {
                if (value == _HasGradientFill) { return; }
                _HasGradientFill = value;
                if (voltagePlot is null || currentPlot is null) { return; }
                if (value) {
                    
                    voltagePlot.FillBelow(Color.Blue);
                    //voltagePlot.FillType = FillType.FillBelow;
                    //voltagePlot.FillColor1 = Color.Blue;
                    voltagePlot.GradientFillColor1 = Color.Transparent;

                    currentPlot.FillBelow(Color.Red);
                    //currentPlot.FillType = FillType.FillBelow;
                    //currentPlot.FillColor1 = Color.Red;
                    currentPlot.GradientFillColor1 = Color.Transparent;
                } else {

                    voltagePlot.FillDisable();
                    currentPlot.FillDisable();

                    //voltagePlot.FillType = FillType.NoFill;
                    //currentPlot.FillType = FillType.NoFill;
                }


                ReadingsPlot.Render(lowQuality: false, skipIfCurrentlyRendering: true);
            }
        }

        private bool _HasAutoScale = false;
        public bool HasAutoScale {
            get { return _HasAutoScale; }
            set {
                this.PlotAutoResizeCheckBox.Checked = value;
                if (value == _HasAutoScale) { return; }
                _HasAutoScale = value;
                if (value) {
                    ReadingsPlot.Plot.AxisAuto();
                }
            }
        }

        #endregion

        #region plot init

        // custom time tick format for ScottPlot
        // starts with (at Form.OnLoad) position values:
        // 0, 100000, 200000, 30000
        // then might ask for:
        // 0, 0.25, 0.5, 0.75, 1
        // depending on zoom level
        string CustomTimeTickFormatter(double position) {

            string SecondsToTimeString(double ts) {
                string result = string.Empty;
                int s = (int)Math.Floor(ts % 60);
                int m = (int)Math.Floor((ts / 60) % 60);
                int h = (int)Math.Floor((ts / 3600) % 24);
                if (h > 0) { result += h.ToString("00") + ":"; }
                return result += m.ToString("00") + ":" + s.ToString("00");
            }

            if (position == 0.0 || this.ParentDevice is null) { return "00:00"; }
            var index = (int)Math.Floor(position);
            if (index < 0 || index > nextDataIndex) { goto bail; }

            var reading = this.ParentDevice.TheStats.ReadingAtX(ref index);
            if (reading is null) { goto bail; }
            return SecondsToTimeString(reading.IntegratorTime);

        bail:
            if (this.ParentDevice.IsLocal) { return string.Empty; }
            var timebase = this.ParentDevice.NetworkLink.ReadingsDelay / 1000;
            var ts = ((position - 1) * timebase) + index > nextDataIndex ? (this.ParentDevice.TheStats.LastReading?.IntegratorTime ?? 0) : (this.ParentDevice.TheStats.FirstReading?.IntegratorTime ?? 0);
            return SecondsToTimeString(ts);             
        }



        #endregion

        #region Plot Data Export

        void DisplayExportDataDialog() {
            if (this.ParentDevice is null) { return; }
            int x1 = (int)(Selection?.X1 ?? 0);
            int x2 = (int)(Selection?.X2 ?? 0);

            var filename = GPMDevice.DateNowFileFormat() + " GPM8310";
            var sfd = new SaveFileDialog {
                FileName = filename + ".csv",
                Filter = "CSV Files (*.csv)|*.csv;*.csv" +
                         "|TXT Files (*.txt)|*.txt;*.txt" +
                         "|All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK) {
                this.ParentDevice.TheStats.ExportDataCsv(sfd.FileName, x1, x2);
            }
        }



        #endregion

        #region Plot Custom Context Menu

        ContextMenuStrip? _customMenu = null;
        ContextMenuStrip customMenu {
            get {
                if (_customMenu is null) {
                    _customMenu = new();
                    var autoscaleItem = new ToolStripMenuItem("Autoscale", null, new EventHandler((s, e) => {
                        HasAutoScale = !HasAutoScale;
                        this.ReadingsPlot.Refresh();
                    }));
                    _customMenu.Items.Add(autoscaleItem);
                    var gradientItem = new ToolStripMenuItem("Gradient fill", null, new EventHandler((s, e) => {
                        HasGradientFill = !HasGradientFill;
                        this.ReadingsPlot.Refresh();
                    }));
                    _customMenu.Items.Add(gradientItem);
                    _customMenu.Items.Add(new ToolStripMenuItem("Open graph in new window", null, new EventHandler((s, e) => {
                        new FormsPlotViewer(ReadingsPlot.Plot).Show();
                    })));
                    _customMenu.Items.Add(new ToolStripSeparator());
                    _customMenu.Items.Add(new ToolStripMenuItem("Copy Picture to Clipboard", null, new EventHandler((s, e) => {
                        Clipboard.SetImage(ReadingsPlot.Plot.Render());
                    })));
                    _customMenu.Items.Add(new ToolStripMenuItem("Save Image As...", null, new EventHandler((s, e) => {
                        var filename = GPMDevice.DateNowFileFormat() + " GPM8310";
                        var sfd = new SaveFileDialog {
                            FileName = filename + ".png",
                            Filter = "PNG Files (*.png)|*.png;*.png" +
                                     "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                                     "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                                     "|All files (*.*)|*.*"
                        };

                        if (sfd.ShowDialog() == DialogResult.OK) {
                            ReadingsPlot.Plot.SaveFig(sfd.FileName);
                        }
                    })));
                    _customMenu.Items.Add(new ToolStripMenuItem("Export all data as CSV...", null, new EventHandler((s, e) => {
                        DisplayExportDataDialog();
                    })));

                    _customMenu.Opening += (s, e) => {
                        gradientItem.Checked = this.HasGradientFill;
                        autoscaleItem.Checked = this.HasAutoScale;
                    };
                }
                return _customMenu;
            }
        }




        #endregion

        private void GpmPlot_Load(object sender, EventArgs e) {
            Console.WriteLine("GPMPLOT LOAD");
            // Plot Init
            // Replace context click menu event
            ReadingsPlot.RightClicked -= ReadingsPlot.DefaultRightClickEvent;
            ReadingsPlot.RightClicked += (s, e) => {
                customMenu.Show(System.Windows.Forms.Cursor.Position);
            };

            ReadingsPlot.Plot.Style(Style.Black);

            voltagePlot = ReadingsPlot.Plot.AddSignal(VoltageData);
            voltagePlot.YAxisIndex = 0;


            ReadingsPlot.Plot.XLabel("Duration");
            ReadingsPlot.Plot.XAxis.TickLabelStyle(rotation: 90);
            ReadingsPlot.Plot.XAxis.TickLabelFormat(CustomTimeTickFormatter);

            ReadingsPlot.Plot.YLabel("V");
            ReadingsPlot.Plot.YAxis.Color(voltagePlot.Color);


            currentPlot = ReadingsPlot.Plot.AddSignal(CurrentData);
            yAxisI = ReadingsPlot.Plot.AddAxis(ScottPlot.Renderable.Edge.Left, axisIndex: 2);
            currentPlot.YAxisIndex = 2;
            yAxisI.Label("I");
            yAxisI.Color(currentPlot.Color);

            powerPlot = ReadingsPlot.Plot.AddSignal(WattHoursData);
            yAxisW = ReadingsPlot.Plot.AddAxis(ScottPlot.Renderable.Edge.Right, axisIndex: 3);
            powerPlot.YAxisIndex = 3;
            yAxisW.Label("W/h");
            yAxisW.Color(powerPlot.Color);

            PlotScaleOnlyPositive();

            ReadingsPlot.Refresh();

            // PLOT OPTIONS CONTROLS
            this.PlotAutoResizeCheckBox.CheckedChanged += (s, e) => {
                this.HasAutoScale = !this.HasAutoScale;
            };
            this.PlotRangeSelectionCheckBox.CheckedChanged += (s, e) => {
                if (nextDataIndex < 2) { return; }
                if (_Selection is null) {
                    if (nextDataIndex < 3) { return; }
                    double first = Math.Floor(nextDataIndex * 0.1);
                    double last = Math.Ceiling(nextDataIndex * 0.9);
                    if (last <= first) {
                        first = 0;
                        last = nextDataIndex - 1;
                    }
                    _Selection = ReadingsPlot.Plot.AddHorizontalSpan(first, last);
                    _Selection.DragEnabled = true;
                    _Selection.Dragged += (s, e) => {
                        if (_Selection is null) { return; }
                        if (_Selection.X1 < 0) {
                            _Selection.X1 = 0;
                        }
                        if (_Selection.X2 > nextDataIndex) {
                            _Selection.X2 = nextDataIndex - 1;
                        }
                        _Selection.X1 = Math.Round(_Selection.X1);
                        _Selection.X2 = Math.Round(_Selection.X2);
                        //RecalculateWh();
                    };
                    _Selection.IsVisible = true;
                } else {
                    _Selection.IsVisible = !_Selection.IsVisible;
                }
            };

            
        }
    }
}
