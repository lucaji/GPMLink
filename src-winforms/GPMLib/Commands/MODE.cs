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
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {

    public class MODE : IParentDevice, IEquatable<MODE?> {

        public enum DeviceInputModeEnum {
            Undefined,
            ACRMS,
            ACDC,
            DC,
            VMEAN
        }

        public DeviceInputModeEnum DeviceInputMode { get; private set; }
        public GPMDevice ParentDevice { get; }

        public MODE(GPMDevice pd) {
            this.ParentDevice = pd;
        }

        const string kInputModeCommand = ":MODE";

        /// <summary>
        /// InputModeEnum, UI Name, Command (short syntax -> non verbose mode!)
        /// </summary>
        static readonly (DeviceInputModeEnum, string, string)[] _InputModes = {
            (DeviceInputModeEnum.Undefined, "Undefined", "x"),
            (DeviceInputModeEnum.ACRMS, "AC/RMS", "RMS"),
            (DeviceInputModeEnum.ACDC, "AC+DC", "ACDC"),
            (DeviceInputModeEnum.DC, "DC", "DC"),
            (DeviceInputModeEnum.VMEAN, "Vmean", "VME"),
        };

        public static List<(DeviceInputModeEnum, string, string)> InputModeListList {
            get {
                return _InputModes.Where(cr => cr.Item1 != DeviceInputModeEnum.Undefined).ToList();
            }
        }

        public async Task<bool> SetDeviceInputMode(string s) {
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating
            var im = _InputModes.Where(im => im.Item2 == s).FirstOrDefault().Item1;
            if (im == DeviceInputModeEnum.Undefined) { return false; }
            var cfmString = _InputModes.Where(i => i.Item1 == im).First().Item3;
            var success = await this.ParentDevice.NetworkLink.SendToDevice(kInputModeCommand + " " + cfmString).ConfigureAwait(false);
            if (success) {
                this.DeviceInputMode = im;
                this.ParentDevice.DeviceInputModeString = s;
            }
            return success;
        }

        public async Task<bool> SetDeviceInputMode(DeviceInputModeEnum im) {
            var s = _InputModes.Where(i => i.Item1 == im).First().Item2;
            return await SetDeviceInputMode(s).ConfigureAwait(false);
        }



        public async Task<bool> GetInputMode() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(kInputModeCommand + "?");
            return ParseResponseString(s);
        }

        public bool ParseResponseString(string s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(kInputModeCommand, "");
            s = s.Replace(" ", "");
            var im = _InputModes.Where(im => im.Item3 == s).FirstOrDefault().Item1;
            this.DeviceInputMode = im;
            this.ParentDevice.DeviceInputModeString = s;
            return (im != DeviceInputModeEnum.Undefined);
        }

        public override string ToString() {
            return _InputModes.Where(i => i.Item1 == this.DeviceInputMode).First().Item2;
        }

        public override bool Equals(object? obj) {
            return Equals(obj as MODE);
        }

        public bool Equals(MODE? other) {
            return other != null &&
                   DeviceInputMode == other.DeviceInputMode;
        }

        public override int GetHashCode() {
            return 496932414 + DeviceInputMode.GetHashCode();
        }
    }


}
