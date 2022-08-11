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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {


    public class CFACtor : BaseCommand, IEquatable<CFACtor?> {

        public enum CrestFactorEnum {
            Undefined,
            CF3,
            CF6,
            CF6A
        }


        public override string CommandDescription { get => "Returns all crest factor settings."; }

        public override string CommandString { get => "CFAC"; }


        #region statics

        public static readonly (CrestFactorEnum, string, string)[] CrestFactorModes = {
            (CrestFactorEnum.Undefined, "Undefined", "x"),
            (CrestFactorEnum.CF3, "CF3", "3"),
            (CrestFactorEnum.CF6, "CF6", "6"),
            (CrestFactorEnum.CF6A, "CF-6A", "A6"),
        };

        public static string DeviceCrestFactorToString(CrestFactorEnum cf) {
            var modo = CrestFactorModes.First(im => im.Item1 == cf);
            return modo.Item2;
        }

        /// <summary>
        /// parses the name values as below:
        /// CF3, CF6, CF-6A
        /// </summary>
        /// <param name="cf"></param>
        /// <returns></returns>
        public static string DeviceCrestFactorToCommand(CrestFactorEnum cf) {
            var modo = CrestFactorModes.First(im => im.Item1 == cf);
            return modo.Item3;
        }

        public static CrestFactorEnum CrestFactorModeEnumFromString(string s) {
            var modo = CrestFactorModes.FirstOrDefault(im => im.Item2 == s);
            if (modo == default) { return CrestFactorEnum.Undefined; }
            return modo.Item1;
        }

        /// <summary>
        /// parses the command response values below:
        /// 3, 6, A6
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static CrestFactorEnum CrestFactorModeEnumFromResponseString(string s) {
            var modo = CrestFactorModes.FirstOrDefault(im => im.Item3 == s);
            if (modo == default) { return CrestFactorEnum.Undefined; }
            return modo.Item1;
        }

        #endregion


      
        public CFACtor(GPMDevice pd) : base(pd) { }


        public CrestFactorEnum CrestFactorMode { get; set; } = CrestFactorEnum.Undefined;

        public string DeviceCrestFactorString { get {
                return DeviceCrestFactorToString(this.CrestFactorMode);
            }
        }


        public async Task<bool> SetCrestFactorMode(string s) {
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating

            var mode = CFACtor.CrestFactorModeEnumFromString(s);
            return await SetCrestFactorMode(mode);
        }

        public async Task<bool> SetCrestFactorMode(CrestFactorEnum cfm) {
            if (ParentDevice.IsDisconnected) { return false; }
            if (ParentDevice.IsIntegrating) { return false; } // cannot change ranges if integrating

            if (cfm == CrestFactorEnum.Undefined) { return false; }
            if (cfm == this.CrestFactorMode) { return true; }
            var cfmString = DeviceCrestFactorToCommand(cfm);
            var success = await this.ParentDevice.NetworkLink.SendToDevice(":CFAC " + cfmString);
            if (success) {
                CrestFactorMode = cfm;
            }
            return success;
        }

        public async Task<bool> GetCrestFactorMode() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":CFAC?");
            return ParseResponseString(s!);
        }

        public bool ParseResponseString(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace("CFAC ", "");
            var cfm = CrestFactorModeEnumFromResponseString(s);
            if (cfm == CrestFactorEnum.Undefined) { return false; }
            this.CrestFactorMode = cfm;
            return true;
        }

        #region equality and ToString overrides



        public override bool Equals(object? obj) {
            return Equals(obj as CFACtor);
        }

        public bool Equals(CFACtor? other) {
            return other != null &&
                   CrestFactorMode == other.CrestFactorMode;
        }

        public override int GetHashCode() {
            return 1825579548 + CrestFactorMode.GetHashCode();
        }

        public override string ToString() {
            return DeviceCrestFactorToString(this.CrestFactorMode);
        }



        #endregion

    }
}
