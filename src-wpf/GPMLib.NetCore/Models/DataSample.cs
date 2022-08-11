using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {

    /// <summary>
    /// The Reading class stores one single reading from the GPM8310
    /// containing voltage, current, power
    /// and integrator values
    /// </summary>
    public class DataSample {

        public static DataSample? Factory(string[] parts) {
            if (parts.Length < NUMeric.NumberOfValues) { return null; }
            var u = MeasurementValueFormatter.StringExponential2Double(parts[0], out bool success);
            if (!success) { GPMDevice.LogToConsole("cannot parse U"); goto bail; }
            var i = MeasurementValueFormatter.StringExponential2Double(parts[1], out success);
            if (!success) { GPMDevice.LogToConsole("cannot parse I"); goto bail; }
            var p = MeasurementValueFormatter.StringExponential2Double(parts[2], out success);
            if (!success) { GPMDevice.LogToConsole("cannot parse P"); goto bail; }
            var r = new DataSample(u, i, p);

            // it should always contain an integral value as time in seconds 0-based.
            success = Int32.TryParse(parts[3], out int integratorTime);
            if (!success) { GPMDevice.LogToConsole("get readings, could not parse 4th value " + parts[3]); }
            r.IntegratorTime = integratorTime;
            // the integrator might not have data, then we ignore as we will be parsing NaNs below
            r.Wh = Math.Abs(MeasurementValueFormatter.StringExponential2Double(parts[4], out success));
            r.Ah = Math.Abs(MeasurementValueFormatter.StringExponential2Double(parts[5], out success));
            return r;
        bail:
            return null;
        }

        private DataSample(double up, double ip, double pp) {
            this.u = up;
            this.i = ip;
            this.p = pp;
        }

        public static bool IgnoreNegatives { get; set; } = true;

        private DateTime _TimeStamp = DateTime.Now;
        public DateTime TimeStamp => _TimeStamp;

        public string TimeStampDate => this.TimeStamp.Date.ToString("yyyy/MM/dd");
        public string TimeStampTimeOfDay => this.TimeStamp.TimeOfDay.ToString(@"hh\:mm\:ss");
        /// <summary>
        /// Displays the formatted time on X axis onto a diagram (ScottPlot)
        /// </summary>
        public double TimeX {
            get {
                return TimeStamp.ToOADate();
            }
        }

        /// <summary>
        /// Integrator current running time from GPM8310 in seconds
        /// </summary>
        public int IntegratorTime { get; private set; }
        public string IntegratorExcelTime => (this.IntegratorTime / 86400.0).ToString();

        public TimeSpan Duration { get { return new TimeSpan(0, 0, IntegratorTime); } }
        public string DurationFormatted {
            get {
                return TimeSpanFormatToString(Duration);
            }
        }

        public static string TimeSpanFormatToString(TimeSpan t) {
            var d = t.Days;
            var h = t.Hours;
            var m = t.Minutes;
            var s = t.Seconds;
            var result = d > 0 ? d.ToString() + "d " : string.Empty;
            result += h > 0 ? h.ToString() + "h " : string.Empty;
            result += m.ToString() + "m " + s.ToString() + "s";
            return result;
        }

        private readonly double u;
        private readonly double i;
        private readonly double p;


        private string u_unit = "V";
        private string i_unit = "A";
        private string p_unit = "W";
        private string wh_unit = "Wh";
        private string ah_unit = "Ah";



        private double _Wh = 0.0;
        public double Wh {
            get { return IgnoreNegatives ? Math.Abs(_Wh) : _Wh; }
            private set { _Wh = value; }
        }
        public double mWh { get { return Wh * 1000.0; } }
        public string WhFormattedValue {
            get {
                wh_unit = "Wh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Wh, ref wh_unit, keepUnit: false);
            }
        }
        public string mWhFormattedValue {
            get {
                wh_unit = "mWh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(mWh, ref wh_unit, keepUnit: false);
            }
        }
        public string WhUnit {
            get {
                wh_unit = "Wh";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(Wh, ref wh_unit);
                return wh_unit;
            }
        }
        public string mWhUnit {
            get {
                wh_unit = "mWh";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(mWh, ref wh_unit);
                return wh_unit;
            }
        }

        public string WhFormattedStringWithUnit {
            get {
                wh_unit = "Wh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Wh, ref wh_unit);
            }
        }
        public string mWhFormattedStringWithUnit {
            get {
                wh_unit = "mWh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(mWh, ref wh_unit);
            }
        }
        private double _Ah = 0.0;
        public double Ah {
            get { return IgnoreNegatives ? Math.Abs(_Ah) : _Ah; }
            private set { _Ah = value; }
        }
        public string AhFormattedValue {
            get {
                ah_unit = "Ah";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Ah, ref ah_unit, keepUnit: false);
            }
        }
        public double mAh { get { return Ah * 1000.0; } }
        public string mAhFormattedValue {
            get {
                ah_unit = "mAh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(mAh, ref ah_unit, keepUnit: false);
            }
        }
        public string AhUnit {
            get {
                ah_unit = "Ah";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(Ah, ref ah_unit);
                return ah_unit;
            }
        }
        public string mAhUnit {
            get {
                ah_unit = "mAh";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(mAh, ref ah_unit);
                return ah_unit;
            }
        }
        public string mAhFormattedStringWithUnit {
            get {
                ah_unit = "mAh";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Ah, ref ah_unit);
            }
        }

        /// <summary>
        /// Voltage in V
        /// </summary>
        public double Voltage { get { return IgnoreNegatives ? Math.Abs(u) : u; } }

        public double VoltageValue {
            get {
                u_unit = "V";
                return MeasurementValueFormatter.FormatDoubleExpand(Voltage, ref u_unit);
            }
        }
        public string VoltageFormattedValue {
            get {
                u_unit = "V";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Voltage, ref u_unit, keepUnit: false);
            }
        }
        public string VoltageFormattedWithUnit {
            get {
                u_unit = "V";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Voltage, ref u_unit);
            }
        }
        public string VoltageUnit {
            get {
                u_unit = "V";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(Voltage, ref u_unit);
                return u_unit;
            }
        }


        /// <summary>
        /// Current in A
        /// </summary>
        public double Current { get { return IgnoreNegatives ? Math.Abs(i) : i; } }
        public double CurrentValue {
            get {
                i_unit = "A";
                return MeasurementValueFormatter.FormatDoubleExpand(Current, ref u_unit);
            }
        }
        public string CurrentFormattedValue {
            get {
                i_unit = "A";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Current, ref i_unit, keepUnit: false);
            }
        }

        public string CurrentFormattedWithUnit {
            get {
                i_unit = "A";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Current, ref i_unit);
            }
        }
        public string CurrentUnit {
            get {
                i_unit = "A";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(Current, ref i_unit);
                return i_unit;
            }
        }

        /// <summary>
        /// Active Power in W
        /// </summary>
        public double Power { get { return IgnoreNegatives ? Math.Abs(p) : p; } }
        public double PowerValue {
            get {
                p_unit = "VA";
                return MeasurementValueFormatter.FormatDoubleExpand(Power, ref u_unit);
            }
        }
        public string PowerFormattedValue {
            get {
                p_unit = "VA";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Power, ref p_unit, keepUnit: false);
            }
        }

        public string PowerFormattedWithUnit {
            get {
                p_unit = "W";
                return MeasurementValueFormatter.FormatDoubleWithUnit(Power, ref p_unit);
            }
        }
        public string PowerUnit {
            get {
                p_unit = "W";
                _ = MeasurementValueFormatter.FormatDoubleWithUnit(Power, ref p_unit);
                return p_unit;
            }
        }

    }
}
