using System;

namespace GPMLib.Netcore {
    public static class Formatters {

        public static string FormatWithUnit(this double n, ref string unit) {
            return MeasurementValueFormatter.FormatDoubleWithUnit(n, ref unit);
        }

        public static string ddHHmmDDString(this DateTime t) {
            var d = t.Day;
            var h = t.Hour;
            var m = t.Minute;
            var s = t.Second;
            var result = d > 0 ? d.ToString() + "d " : string.Empty;
            result += h > 0 ? h.ToString() + "h " : string.Empty;
            result += m.ToString() + "m " + s.ToString() + "s";
            return result;
        }

        
    }

}
