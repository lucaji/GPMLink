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

namespace GPMLib.Netcore {


    public class CURRent : BaseCommand, CommandHasQuery {
        public override string CommandDescription { get => "Manages the current settings."; }
        public override string CommandString { get => ":DUMMY"; }

        public CURRent(GPMDevice pd) : base(pd) { }

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
     
        public static readonly string[] CurrentRangesList = new string[] {
            "2.5mA",
            "5mA",
            "10mA",
            "20mA",
            "25mA",
            "50mA",
            "100mA",
            "200mA",
            "250mA",
            "0.5A",
            "1A",
            "2A",
            "5A",
            "10A",
            "20A",
        };

       
        public string CurrentRange { get; set; } = string.Empty;


        public static string CurrentRangeFromString(string modeString) {
            double val;
            try {
                val = double.Parse(modeString, NumberStyles.Float, CultureInfo.InvariantCulture);
                var i = 0;
                if (val == 0.0025) {

                } else if (val == 0.005) {
                    i = 1;
                } else if (val == 0.01) {
                    i = 2;
                } else if (val == 0.02) {
                    i = 3;
                } else if (val == 0.025) {
                    i = 4;
                } else if (val == 0.05) {
                    i = 5;
                } else if (val == 0.1) {
                    i = 6;
                } else if (val == 0.2) {
                    i = 7;
                } else if (val == 0.25) {
                    i = 8;
                } else if (val == 0.5) {
                    i = 9;
                } else if (val == 1.0) {
                    i = 10;
                } else if (val == 2.0) {
                    i = 11;
                } else if (val == 5.0) {
                    i = 12;
                } else if (val == 10.0) {
                    i = 13;
                } else if (val == 20.0) {
                    i = 14;
                }
                return CurrentRangesList[i];

            } catch (Exception ex) {
                Debug.WriteLine("Error parsing DeviceCurrentRangeFromString " + modeString + Environment.NewLine + ex.ToString());
            }
            return string.Empty;
        }


        public async Task<bool> SetDeviceCurrentRange(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            if (!CurrentRangesList.Contains(s)) { return false; }
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            if (s.ToUpperInvariant().Equals("AUTO")) {
                return await SetDeviceCurrentRangeAuto(true);
            }
            var success = await this.ParentDevice.NetworkLink.SendToDevice(":CURR:RANG " + s);
            return success;
        }


        public async Task<bool> QueryDevice() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":CURR:RANG?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(":CURR:RANG", "");
            s = s.Replace(" ", "");
            var re = CurrentRangeFromString(s);
            this.CurrentRange = re;
            return true;
        }

       
    }

}
