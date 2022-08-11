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

namespace GPMLib.Netcore {



    public class VOLTage : BaseCommand, CommandHasQuery {

        public string CommandValue { get; private set; } = string.Empty;

        // :INP:VOLT?
        // :VOLT:RANG 15.0E+00;AUTO 1
        //
        // :INP:VOLT:RANG?
        // :VOLT:RANG 15.0E+00
        public override string CommandDescription { get => "Manages the voltage settings."; }

        public override string CommandString { get => ":DUMMY"; }

        static readonly string CommandString_VoltageRange = "[:INPut]:VOLTage:RANGe";
        //static readonly string CommandString_VoltageRangeAuto = "[:INPut]:VOLTage:AUTO";
        const string kVoltageAutoShortCommand = ":VOLT:AUTO";

        #region Statics


        public static readonly string[] VoltageRangesList = new string[] {
            "7.5V",
            "15V",
            "30V",
            "60V",
            "75V",
            "150V",
            "300V",
            "600V",
        };

       

        /// <summary>
        /// Parses the string number value without the "V" unit
        /// </summary>
        /// <param name="modeString"></param>
        /// <returns>The corresponding enum</returns>
        public static string VoltageRangeFromNumericString(string rangeString) {
            if (string.IsNullOrWhiteSpace(rangeString)) { goto bail; }
            try {
                // parse the exponential number format as provided by the GPM8310
                double val = double.Parse(rangeString, NumberStyles.Float, CultureInfo.InvariantCulture);
                if (val == 7.5) {
                    return VoltageRangesList[0];
                } else if (val == 15.0) {
                    return VoltageRangesList[1];
                } else if (val == 30.0) {
                    return VoltageRangesList[2];
                } else if (val == 60.0) {
                    return VoltageRangesList[3];
                } else if (val == 75.0) {
                    return VoltageRangesList[4];
                } else if (val == 150.0) {
                    return VoltageRangesList[5];
                } else if (val == 300.0) {
                    return VoltageRangesList[6];
                } else if (val == 600.0) {
                    return VoltageRangesList[7];
                }
            } catch (Exception ex) {
                Debug.WriteLine("Error DeviceVoltageRangeFromString parsing " + rangeString + Environment.NewLine + ex.ToString());
            }
            bail:  return string.Empty;
        }

       
        #endregion


        public VOLTage(GPMDevice pd) : base(pd) { }



        public string VoltageRange { get; set; } = string.Empty;

        public bool IsVoltageRangeAuto { get; set; }

        public async Task<bool> SetDeviceVoltageRange(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            if (!VoltageRangesList.Contains(s)) { return false; }
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (s.ToUpperInvariant().Equals("AUTO")) {
                return await this.SetDeviceVoltageRangeAuto(true);
            }
            var res = VoltageRangeFromNumericString(s);
            var success = await this.ParentDevice.NetworkLink.SendToDevice(":VOLT:RANG " + res);
            return success;
        }

       
        public async Task<bool> QueryDevice() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":VOLT:RANG?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(":VOLT:RANG", "");
            s = s.Replace(" ", "");
            var re = VoltageRangeFromNumericString(s);
            if (!VoltageRangesList.Contains(s)) { return false; }
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







        
    }
}
