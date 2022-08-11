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

/***
 * 
 * GW-Instek GPM-8310 C# Class
 * v. 0.1
 * June 2021
 * Luca Cipressi
 * 
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GPMLib {

    

    public class CURRent : IParentDevice, IEquatable<CURRent> {

        public enum DeviceCurrentRangeEnum {
            Undefined,
            CR_2_5mA,
            CR_5mA,
            CR_10mA,
            CR_20mA,
            CR_25mA,
            CR_50mA,
            CR_100mA,
            CR_200mA,
            CR_250mA,
            CR_0_5A,
            CR_1A,
            CR_2A,
            CR_2_5A,
            CR_5A,
            CR_10A,
            CR_20A
        }
        public GPMDevice ParentDevice { get; }

        public CURRent(GPMDevice pd) {
            this.ParentDevice = pd;
        }

        const string kCurrenteAutoShortCommand = ":CURR:AUTO";
        public bool IsCurrentRangeAuto { get; protected set; }


        public async Task<bool> SetDeviceCurrentRangeAuto(bool isAuto) {
            if (!ParentDevice.IsConnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (isAuto == this.IsCurrentRangeAuto) { return true; }
            var va = isAuto ? "1" : "0";
            var success = await this.ParentDevice.NetworkLink.SendToDevice(kCurrenteAutoShortCommand + " " + va);
            if (success) {
                this.IsCurrentRangeAuto = isAuto;
            }
            return success;
        }

        public async Task<bool> GetCurrentRangeAuto() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(kCurrenteAutoShortCommand + "?");
            return ParseResponseAutoString(s);
        }

        public bool ParseResponseAutoString(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(kCurrenteAutoShortCommand, "");
            s = s.Replace(" ", "");
            if (s!.Equals("1")) {
                this.IsCurrentRangeAuto = true;
                return true;
            } else if (s.Equals("0")) {
                this.IsCurrentRangeAuto = false;
                return true;
            }
            return false;
        }
        
        static readonly List<(DeviceCurrentRangeEnum, string)> _CurrentRanges = new() {
            (DeviceCurrentRangeEnum.Undefined, "Undefined"),
            (DeviceCurrentRangeEnum.CR_2_5mA, "2.5mA"),
            (DeviceCurrentRangeEnum.CR_5mA, "5mA"),
            (DeviceCurrentRangeEnum.CR_10mA, "10mA"),
            (DeviceCurrentRangeEnum.CR_20mA, "20mA"),
            (DeviceCurrentRangeEnum.CR_25mA, "25mA"),
            (DeviceCurrentRangeEnum.CR_50mA, "50mA"),
            (DeviceCurrentRangeEnum.CR_100mA, "100mA"),
            (DeviceCurrentRangeEnum.CR_200mA, "200mA"),
            (DeviceCurrentRangeEnum.CR_250mA, "250mA"),
            (DeviceCurrentRangeEnum.CR_0_5A, "0.5A"),
            (DeviceCurrentRangeEnum.CR_1A, "1A"),
            (DeviceCurrentRangeEnum.CR_2A, "2A"),
            (DeviceCurrentRangeEnum.CR_5A, "5A"),
            (DeviceCurrentRangeEnum.CR_10A, "10A"),
            (DeviceCurrentRangeEnum.CR_20A, "20A"),
        };

        public static List<(DeviceCurrentRangeEnum, string)> CurrentRangesList {
            get {
                return _CurrentRanges.Where(cr => cr.Item1 != DeviceCurrentRangeEnum.Undefined).ToList();
            }
        }

        public DeviceCurrentRangeEnum CurrentRange { get; set; } = DeviceCurrentRangeEnum.Undefined;


        public static DeviceCurrentRangeEnum CurrentRangeFromString(string modeString) {
            double val = 0.0;
            try {
                val = double.Parse(modeString, NumberStyles.Float, CultureInfo.InvariantCulture);
                if (val == 0.0025) {
                    return DeviceCurrentRangeEnum.CR_2_5mA;
                } else if (val == 0.005) {
                    return DeviceCurrentRangeEnum.CR_5mA;
                } else if (val == 0.01) {
                    return DeviceCurrentRangeEnum.CR_10mA;
                } else if (val == 0.02) {
                    return DeviceCurrentRangeEnum.CR_20mA;
                } else if (val == 0.025) {
                    return DeviceCurrentRangeEnum.CR_25mA;
                } else if (val == 0.05) {
                    return DeviceCurrentRangeEnum.CR_50mA;
                } else if (val == 0.1) {
                    return DeviceCurrentRangeEnum.CR_100mA;
                } else if (val == 0.2) {
                    return DeviceCurrentRangeEnum.CR_200mA;
                } else if (val == 0.25) {
                    return DeviceCurrentRangeEnum.CR_250mA;
                } else if (val == 0.5) {
                    return DeviceCurrentRangeEnum.CR_0_5A;
                } else if (val == 1.0) {
                    return DeviceCurrentRangeEnum.CR_1A;
                } else if (val == 2.0) {
                    return DeviceCurrentRangeEnum.CR_2A;
                } else if (val == 5.0) {
                    return DeviceCurrentRangeEnum.CR_5A;
                } else if (val == 10.0) {
                    return DeviceCurrentRangeEnum.CR_10A;
                } else if (val == 20.0) {
                    return DeviceCurrentRangeEnum.CR_20A;
                }
            } catch (Exception ex) {
                Debug.WriteLine("Error parsing DeviceCurrentRangeFromString " + modeString + Environment.NewLine + ex.ToString());
            }
            return DeviceCurrentRangeEnum.Undefined;
        }

        public static DeviceCurrentRangeEnum CurrentRangeFromStringWithUnit(string modeString) {
            var modo = _CurrentRanges.Where(im => im.Item2 == modeString).FirstOrDefault();
            if (modo == default) { return DeviceCurrentRangeEnum.Undefined; }
            return modo.Item1;
        }
        public static string CurrentRangeToString(DeviceCurrentRangeEnum mode) {
            var modo = _CurrentRanges.Where(im => im.Item1 == mode).First();
            return modo.Item2;
        }

        public static string CurrentRangeToCommandString(DeviceCurrentRangeEnum mode) {
            var modo = _CurrentRanges.Where(im => im.Item1 == mode).First();
            return modo.Item2;
        }

        public async Task<bool> SetDeviceCurrentRange(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (s.ToUpperInvariant().Equals("AUTO")) {
                return await SetDeviceCurrentRangeAuto(true);
            }
            var r = CurrentRangeFromString(s);
            return await SetDeviceCurrentRange(r);
        }

        public async Task<bool> SetDeviceCurrentRange(DeviceCurrentRangeEnum re) {
            if (!ParentDevice.IsConnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (re == DeviceCurrentRangeEnum.Undefined) { return false; }
            if (re == this.CurrentRange) { return true; }
            var res = CurrentRangeToCommandString(re);
            var success = await this.ParentDevice.NetworkLink.SendToDevice(":CURR:RANG " + res);
            if (success) {
                this.CurrentRange = re;
            }
            return success;
        }

        public async Task<bool> GetDeviceCurrentRange() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":CURR:RANG?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(":CURR:RANG", "");
            s = s.Replace(" ", "");
            var re = CurrentRangeFromString(s);
            if (re == DeviceCurrentRangeEnum.Undefined) { return false; }
            this.CurrentRange = re;
            return true;
        }

        public override string ToString() {
            return CurrentRangeToString(this.CurrentRange);
        }

        public override bool Equals(object? obj) {
            if (obj is not CURRent ob) { return false; }
            return Equals(ob);
        }

        public bool Equals(CURRent other) {
            return other != null &&
                   CurrentRange == other.CurrentRange;
        }

        public override int GetHashCode() {
            int hashCode = -318266557;
            hashCode = hashCode * -1521134295 + CurrentRange.GetHashCode();
            return hashCode;
        }
    }

}
