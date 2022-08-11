using System;
using System.Globalization;
using System.Linq;

#nullable enable

namespace GPMLib {
    public static class Formatters {

        public static string FormatWithUnit(this double n, ref string unit) {
            return FormatDoubleWithUnit(n, ref unit);
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





        public static double StringExponential2Double(string? s, out bool success) {
            success = !string.IsNullOrWhiteSpace(s);
            if (!success) { goto bail; }
            success = s != "NAN";
            if (!success) { goto bail; }
            success = s != "INF";
            if (!success) { goto bail; }

            try {
                return double.Parse(s!, NumberStyles.Float, CultureInfo.InvariantCulture);
            } catch (Exception ex) {
                Console.WriteLine("double Parse exception " + ex.Message + "\n" + s);
                success = false;
            }
        bail:
            return 0.0;
        }

        public static double FormatDoubleExpand(double v, ref string unit) {
            int exp = 0;
            if (unit.Length > 1) {
                var s = unit.First();
                exp = SIPrefix.ExpForPrefix(s) * -1;
                if (exp != 0) {
                    unit = unit.Remove(0, 1);
                    var d = (long)Math.Pow(10.0, exp);
                    if (exp < 0) {
                        v *= d;
                    } else {
                        v /= d;
                    }
                    exp = 0;
                }
            }
            while (v - Math.Floor(v) > 0) {
                if (Math.Abs(exp) >= 24) { break; }
                exp -= 3;
                v *= 1000.0;
                v = Math.Round(v, 6);
            }
            while (Math.Floor(v).ToString().Length > 3) {
                if (Math.Abs(exp) >= 24) { break; }
                exp += 3;
                v /= 1000.0;
                v = Math.Round(v, 6);
            }

            var p = SIPrefix.PrefixForExp(exp);
            if (p is not null) {
                if (p.Symbol != '\0') {
                    unit = p.Symbol.ToString() + unit;
                }
            }
            return v;
        }

        public static string FormatDoubleWithUnit(double v, ref string unit, bool keepUnit = true) {
            if (double.IsNaN(v)) {
                return "--" + (keepUnit ? unit : "");
            }
            if (double.IsInfinity(v)) {
                return "∞" + (keepUnit ? unit : "");
            }
            //var k = Math.Floor(Math.Log10(v) + 1);
            int exp = 0;
            if (unit.Length > 1) {
                var s = unit.First();
                exp = SIPrefix.ExpForPrefix(s) * -1;
                if (exp != 0) {
                    unit = unit.Remove(0, 1);
                    var d = (long)Math.Pow(10.0, exp);
                    if (exp < 0) {
                        v *= d;
                    } else {
                        v /= d;
                    }
                    exp = 0;
                }
            }
            while (v - Math.Floor(v) > 0) {
                if (Math.Abs(exp) >= 24) { break; }
                exp -= 3;
                v *= 1000.0;
                v = Math.Round(v, 6);
            }
            while (Math.Floor(v).ToString().Length > 3) {
                if (Math.Abs(exp) >= 24) { break; }
                exp += 3;
                v /= 1000.0;
                v = Math.Round(v, 6);
            }

            var result = v.ToString("0.00");
            if (keepUnit) {
                var p = SIPrefix.PrefixForExp(exp);
                if (p is not null) {
                    if (p.Symbol != '\0') {
                        unit = p.Symbol.ToString() + unit;
                    }
                }
                result += unit;
            }
            return result;
        }
    }

}
