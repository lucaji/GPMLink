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


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {

    

    public class VOLTage : IParentDevice {

        public enum DeviceVoltageRangeEnum {
            Undefined,
            VR_7_5V,
            VR_15V,
            VR_30V,
            VR_60V,
            VR_75V,
            VR_150V,
            VR_300V,
            VR_600V,
        }


        // :INP:VOLT?
        // :VOLT:RANG 15.0E+00;AUTO 1
        //
        // :INP:VOLT:RANG?
        // :VOLT:RANG 15.0E+00


        static readonly string CommandString_VoltageRange = "[:INPut]:VOLTage:RANGe";
        //static readonly string CommandString_VoltageRangeAuto = "[:INPut]:VOLTage:AUTO";
        const string kVoltageAutoShortCommand = ":VOLT:AUTO";

        #region Statics      

        static readonly List<(DeviceVoltageRangeEnum, string)> _VoltageRanges = new() {
            (DeviceVoltageRangeEnum.Undefined, "Undefined"),
            (DeviceVoltageRangeEnum.VR_7_5V, "7.5V"),
            (DeviceVoltageRangeEnum.VR_15V, "15V"),
            (DeviceVoltageRangeEnum.VR_30V, "30V"),
            (DeviceVoltageRangeEnum.VR_60V, "60V"),
            (DeviceVoltageRangeEnum.VR_75V, "75V"),
            (DeviceVoltageRangeEnum.VR_150V, "150V"),
            (DeviceVoltageRangeEnum.VR_300V, "300V"),
            (DeviceVoltageRangeEnum.VR_600V, "600V"),
        };

        /// <summary>
        /// Removes the "Undefined" row from the list of ranges
        /// </summary>
        public static List<(DeviceVoltageRangeEnum, string)> VoltageRangesList {
            get {
                return _VoltageRanges.Where(cr => cr.Item1 != DeviceVoltageRangeEnum.Undefined).ToList();
            }
        }

        /// <summary>
        /// Parses the string number value without the "V" unit
        /// </summary>
        /// <param name="modeString"></param>
        /// <returns>The corresponding enum</returns>
        public static DeviceVoltageRangeEnum VoltageRangeFromNumericString(string rangeString) {
            if (string.IsNullOrWhiteSpace(rangeString)) { goto bail; }
            try {
                // parse the exponential number format as provided by the GPM8310
                double val = double.Parse(rangeString, NumberStyles.Float, CultureInfo.InvariantCulture);
                if (val == 7.5) {
                    return DeviceVoltageRangeEnum.VR_7_5V;
                } else if (val == 15.0) {
                    return DeviceVoltageRangeEnum.VR_15V;
                } else if (val == 30.0) {
                    return DeviceVoltageRangeEnum.VR_30V;
                } else if (val == 60.0) {
                    return DeviceVoltageRangeEnum.VR_60V;
                } else if (val == 75.0) {
                    return DeviceVoltageRangeEnum.VR_75V;
                } else if (val == 150.0) {
                    return DeviceVoltageRangeEnum.VR_150V;
                } else if (val == 300.0) {
                    return DeviceVoltageRangeEnum.VR_300V;
                } else if (val == 600.0) {
                    return DeviceVoltageRangeEnum.VR_600V;
                }
            } catch (Exception ex) {
                Debug.WriteLine("Error DeviceVoltageRangeFromString parsing " + rangeString + Environment.NewLine + ex.ToString());
            }
            bail:  return DeviceVoltageRangeEnum.Undefined;
        }

        public static DeviceVoltageRangeEnum VoltageRangeFromStringWithUnit(string modeString) {
            if (string.IsNullOrWhiteSpace(modeString)) { return DeviceVoltageRangeEnum.Undefined; }
            var modo = _VoltageRanges.Where(im => im.Item2 == modeString).FirstOrDefault();
            if (modo == default) { return DeviceVoltageRangeEnum.Undefined; }
            return modo.Item1;
        }
        public static string VoltageRangeToString(DeviceVoltageRangeEnum mode) {
            var modo = _VoltageRanges.Where(im => im.Item1 == mode).First();
            return modo.Item2;
        }

        public static string VoltageRangeToCommandString(DeviceVoltageRangeEnum mode) {
            var modo = _VoltageRanges.Where(im => im.Item1 == mode).First();
            return modo.Item2;
        }

        #endregion


        public VOLTage(GPMDevice pd, DeviceVoltageRangeEnum vr = DeviceVoltageRangeEnum.Undefined) {
            this.ParentDevice = pd;
            this.VoltageRange = vr;
        }


        #region Instance Properties
        public GPMDevice ParentDevice { get; }

        public DeviceVoltageRangeEnum VoltageRange { get; set; } = DeviceVoltageRangeEnum.Undefined;

        public bool IsVoltageRangeAuto { get; set; }

        public async Task<bool> SetDeviceVoltageRange(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (s.ToUpperInvariant().Equals("AUTO")) {
                return await this.SetDeviceVoltageRangeAuto(true);
            }
            var r = VoltageRangeFromNumericString(s);
            return await SetDeviceVoltageRange(r);
        }

        public async Task<bool> SetDeviceVoltageRange(DeviceVoltageRangeEnum re) {
            if (!ParentDevice.IsConnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (re == DeviceVoltageRangeEnum.Undefined) { return false; }
            if (re == this.VoltageRange) { return true; }
            var res = VoltageRangeToCommandString(re);
            var success = await this.ParentDevice.NetworkLink.SendToDevice(":VOLT:RANG " + res);
            if (success) {
                this.VoltageRange = re;
            }
            return success;
        }

        public async Task<bool> GetDeviceVoltageRange() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":VOLT:RANG?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(":VOLT:RANG", "");
            s = s.Replace(" ", "");
            var re = VoltageRangeFromNumericString(s);
            if (re == DeviceVoltageRangeEnum.Undefined) { return false; }
            this.VoltageRange = re;
            return true;
        }


        public async Task<bool> SetDeviceVoltageRangeAuto(bool isAuto) {
            if (!ParentDevice.IsConnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (isAuto == this.IsVoltageRangeAuto) { return true; }
            var va = isAuto ? "1" : "0";
            var success = await this.ParentDevice.NetworkLink.SendToDevice(kVoltageAutoShortCommand + " " + va);
            if (success) {
                this.IsVoltageRangeAuto = isAuto;
            }
            return success;
        }

        public async Task<bool> GetVoltageRangeAuto() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(kVoltageAutoShortCommand + "?");
            return ParseResponseAutoString(s);
        }

        public bool ParseResponseAutoString(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(kVoltageAutoShortCommand, "");
            s = s.Replace(" ", "");
            if (s!.Equals("1")) {
                this.IsVoltageRangeAuto = true;
                return true;
            } else if (s.Equals("0")) {
                this.IsVoltageRangeAuto = false;
                return true;
            }
            return false;
        }


        #endregion



        public override string ToString() {
            return VoltageRangeToString(VoltageRange);
        }


        
    }
}
