
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#nullable enable

namespace GPMLib.Netcore {



    public class DataReadings {

        private DataSample? _LastReading = null;
        public DataSample? LastReading {
            get => _LastReading;
            set {
                if (_FirstReading is null) {
                    _FirstReading = value;
                    _LastReading = null;
                } else {
                    _LastReading = value;
                }
            }
        }

        // to calculate the integrator start duration in the graph if any
        private DataSample? _FirstReading = null;
        public DataSample? FirstReading { get => _FirstReading; }

        public static List<(DisplayPowerOptionsEnum, string, string, string)> PowerDisplayOptions = new() {
            (DisplayPowerOptionsEnum.DisplayVA, "P", "Active Power VA", "VA"),
            (DisplayPowerOptionsEnum.DisplayWh, "WP", "Integrated W/h", "Wh"),
            (DisplayPowerOptionsEnum.DisplayAh, "Q", "Integrated A/h", "Ah"),
        };


        public static DisplayPowerOptionsEnum DisplayPowerOptionForLongString(string l) {
            var result = DisplayPowerOptionsEnum.DisplayVA;
            var o = PowerDisplayOptions.FirstOrDefault(p => p.Item3.Equals(l));
            if (o != default) {
                result = o.Item1;
            }
            return result;
        }

        public enum DisplayPowerOptionsEnum {
            DisplayVA, // P
            DisplayWh, // WP
            DisplayAh, // Q
        }

        DisplayPowerOptionsEnum _PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayAh;

        public DisplayPowerOptionsEnum PowerUnitDisplayOption {
            get { return _PowerUnitDisplayOption; }
            set {
                _PowerUnitDisplayOption = value;
                //UpdateVaWhButtonStyles();
            }
        }




        public NUMeric ReadingCommand { get; private set; }
        public INTEGrator IntegratorCommand { get; private set; }

        private readonly object _LoggedReadingsLock = new();
        private readonly List<DataSample> _LoggedReadings = new();

        /// <summary>
        /// The complete readonly dataset
        /// </summary>
        public ReadOnlyCollection<DataSample> LoggedReadings {
            get {
                lock (_LoggedReadingsLock) {
                    return new ReadOnlyCollection<DataSample>(_LoggedReadings);
                }
            }
        }



        /// <summary>
        /// Returns a range if applicable, otherwise the full dataset
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public ReadOnlyCollection<DataSample> ReadingsBetween(int x1, int x2) {
            lock (_LoggedReadingsLock) {
                var upperBound = _LoggedReadings.Count - 1;
                if (x2 > upperBound || x2 == x1) { x2 = upperBound; }
                if (x1 < 0) { x1 = 0; }
                var diff = x2 - x1;
                var result = new ReadOnlyCollection<DataSample>(_LoggedReadings.GetRange(x1, diff));
                return result;
            }
        }


        public List<DataSample> ReadingsAt(int x1, int x2, List<PowerTargetValueViewModel> targets) {
            var results = new List<DataSample>();
            //if (targets is null) {
            //    targets = UserSettingsManager.Instance.TargetPercentagesList;
            //}
            try {
                lock (_LoggedReadingsLock) {
                    var upperBound = _LoggedReadings.Count - 1;
                    if (x1 > upperBound || x2 > upperBound) { goto bail; }
                    if (x1 < 0) { goto bail; }
                    if (x2 <= x1) { goto bail; }
                    var diff = x2 - x1 - 1;
                    var argmax = _LoggedReadings.Max(item => item.Ah);
                    var max = _LoggedReadings.First(item => item.Ah == argmax);

                    var argmin = _LoggedReadings.Min(item => item.Ah);
                    var min = _LoggedReadings.First(item => item.Ah == argmin);
                    if (max is null || min is null) { goto bail; }
                    if (targets.First().Percentage == 0) {
                        results.Add(min);
                    }

                        var delta = Math.Abs(max.Ah - min.Ah);
                        for (int i = x1; i < x2; i++) {
                            var item = _LoggedReadings[i];
                            foreach (var t in targets) {
                                var targetValue = (delta * t.Percentage + min.Ah);
                                if (item.mAh <= targetValue) {
                                    results.Add(item);
                                }
                            }
                        }
                        if (targets.Last().Percentage == 1) {
                            results.Add(max);
                        }
                    
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            bail:
            return results;
        }


        public DataSample? ReadingAtX(ref int x) {
            if (x < 0) { x = 0; }
            lock (_LoggedReadingsLock) {
                var n = _LoggedReadings.Count;
                if (x >= n) { x = n - 1; }
                if (n <= 0) { return null; }
                return _LoggedReadings[x];
            }
        }


        

        public void AddReading(DataSample r) {
            LastReading = r;
            lock (_LoggedReadingsLock) {
                UMax = UMin = r.Voltage;
                IMax = IMin = r.Current;
                PMax = PMin = r.Power;

                WhMax = WhMin = r.Wh;
                AhMax = AhMin = r.Ah;

                _LoggedReadings.Add(r);
            }
        }

        



        public DataReadings(GPMDevice d) {
            ParentDevice = d;
            ReadingCommand = new(d);
            IntegratorCommand = new(d);
        }

        private readonly GPMDevice ParentDevice;


        #region U


        public double UMax { 
            get { return _UMax is null ? double.NaN : _UMax.Value; } 
            private set { if (_UMax is null || value > _UMax.Value) { _UMax = value; } } 
        }
        
        

        public double UMin {
            get { return _UMin is null ? double.NaN : _UMin.Value; }
            private set { if (_UMin is null || value < _UMin.Value) { _UMin = value; } }
        }
        

        #endregion

        #region I


        public double IMax {
            get { return _IMax is null ? double.NaN : _IMax.Value; }
            private set { if (_IMax is null || value > _IMax.Value) { _IMax = value; } } }
        

        public double IMin {
            get { return _IMin is null ? double.NaN : _IMin.Value; }
            private set { if (_IMin is null || value < _IMin.Value) { _IMin = value; } }
        }
        

        #endregion

        #region P



        public double PMax {
            get { return _PMax is null ? double.NaN : _PMax.Value; } 
            private set { if (_PMax is null || value > _PMax.Value) { _PMax = value; } } }
        
        

        
        public double PMin { 
            get { return _PMin is null ? double.NaN : _PMin.Value; }
            private set { if (_PMin is null || value < _PMin.Value) { _PMin = value; } } }
        

        #endregion

        #region Ah



        public double AhMax { 
            get { return _AhMax is null ? double.NaN : _AhMax.Value; }
            private set { if (_AhMax is null || value > _AhMax.Value) { _AhMax = value; } } }
        

        public double AhMin {
            get { return _AhMin is null ? double.NaN : _AhMin.Value; }
            private set { if (_AhMin is null || value < _AhMin.Value) { _AhMin = value; } } }
        

        #endregion

        #region Wh



        public double WhMax { 
            get { return _WhMax is null ? double.NaN : _WhMax.Value; }
            private set { if (_WhMax is null || value > _WhMax.Value) { _WhMax = value; } } }
        

        public double WhMin {
            get { return _WhMin is null ? double.NaN : _WhMin.Value; }
            private set { if (_WhMin is null || value < _WhMin.Value) { _WhMin = value; } } }
        

        #endregion

        #region Fields

        double? _UMax;
        double? _IMax;
        double? _PMax;

        double? _UMin;
        double? _IMin;
        double? _PMin;

        double? _AhMax;
        double? _AhMin;

        double? _WhMax;
        double? _WhMin;

        public void StatsAllReset() {
            lock (_LoggedReadingsLock) {
                _LoggedReadings.Clear();
            }
            _LastReading = null;
            _FirstReading = null;
            StatsResetMin();
            StatsResetMax();
        }

        public void StatsResetMax() {
            var last = LoggedReadings.LastOrDefault();
            _UMax = last?.Voltage;
            _IMax = last?.Current;
            _PMax = last?.Power;

            _WhMax = last?.Wh;
            _AhMax = last?.Ah;

        }

        public void StatsResetMin() {
            var last = LoggedReadings.LastOrDefault();
            _UMin = last?.Voltage;
            _IMin = last?.Current;
            _PMin = last?.Power;

            _WhMin = last?.Wh;
            _AhMin = last?.Ah;
        }

        public override string ToString() {
            return this.ParentDevice.ToString() + " Stats";
        }

        #endregion



    }


}
