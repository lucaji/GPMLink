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
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {


    public class MODE : BaseCommand, CommandHasQuery {

        public enum MODEInputEnum {
            Unknown,
            InputModeAC,
            InputModeDC,
            InputModeACDC,
            InputModeVMean
        }       

        public MODEInputEnum InputMode { get; private set; } = MODEInputEnum.Unknown;
        

        public override string CommandDescription { get => "Manages the current range settings."; }
        public override string CommandString { get => ":INP:MODE"; }

        public MODE(GPMDevice pd) : base(pd) { }

        /// <summary>
        /// UI Name, Command (short syntax -> non verbose mode!)
        /// </summary>
        public static readonly (MODEInputEnum, string, string)[] InputModeListList = {
            (MODEInputEnum.InputModeAC, "AC/RMS", "RMS"),
            (MODEInputEnum.InputModeDC, "DC", "DC"),
            (MODEInputEnum.InputModeACDC, "AC+DC", "ACDC"),
            (MODEInputEnum.InputModeVMean, "VMean", "VMEAn"),
        };

        public async Task<bool> SetDeviceInputMode(MODEInputEnum m) {
            if (ParentDevice.IsDisconnected) { return false; }
            // cannot change ranges if integrator is not in RESET mode!
            if (ParentDevice.IsIntegrating) { return false; }
            var cfmString = InputModeListList.FirstOrDefault(im => im.Item1 == m).Item3;
            if (cfmString is null) { return false; }
            var success = await this.ParentDevice.NetworkLink.SendToDevice(CommandString + " " + cfmString).ConfigureAwait(false);
            //if (success) {
            //    this.InputMode = m;
            //    this.ParentDevice.DeviceInputModeString = cfmString;
            //}
            return success;
        }

        public async Task<bool> SetDeviceInputMode(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            var m = InputModeListList.FirstOrDefault(im => im.Item2 == s).Item1;
            return await SetDeviceInputMode(m).ConfigureAwait(false);
        }

        public async Task<bool> QueryDevice() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(CommandString + "?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            var l = s.Length;
            s = s!.Replace(":MODE ", "");
            if (s.Length == l) {
                // something went wrong (short form, header mode...)
                Trace.WriteLine("MODE string response parse error = " + s);
                return false;
            }
            var im = InputModeListList.FirstOrDefault(im => im.Item3 == s).Item1;
            var hasChanged = this.InputMode != im;
            if (hasChanged && this.NotifyChangedEvent is not null) {
                this.InputMode = im;
                this.ParentDevice.DeviceInputModeString = s;
                this.NotifyChangedEvent?.Invoke(this.ParentDevice, this);
            }
            return true;
        }


    }


}
