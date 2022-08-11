/*
 * 
    Licensed under the MIT license:

    http://www.opensource.org/licenses/mit-license.php

    Copyright(c) 2013 - 2021, Luca Cipressi(lucaji.github.io) lucaji()mail.ru


    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*
*/

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {



    public static class MeasurementValueFormatter {

        
  
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
                Debug.WriteLine("double Parse exception " + ex.Message + "\n" + s);
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
