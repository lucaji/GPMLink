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
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {
    public class NUMeric : BaseCommand {


        /// <summary>
        /// Number of values to be retrieved by the :NUM:VAL command
        /// needs to be configured or defaults to 3.
        /// </summary>
        public static int NumberOfValues { get; set; } = 3;
        public override string CommandString { get => ":DUMMY"; }


        static readonly string GetReadingsCommandString = ":NUM:VAL";

        public override string CommandDescription { get => "Manages the current range settings."; }

        public NUMeric(GPMDevice pd) : base(pd) { }



        public async Task<DataSample?> GetReadings() {
            if (ParentDevice.IsDisconnected) { return null; }
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(GetReadingsCommandString + "?");
            if (string.IsNullOrWhiteSpace(s)) {
                Console.WriteLine("query device returned empty");
                return null;
            }
            var parts = s.Split(',');
            if (parts.Length != NumberOfValues) {
                GPMDevice.LogError("get readings GPMReadings, failed to split response string into " + NumberOfValues + " parts.");
                Console.WriteLine(s);
                return null;
            }
            return DataSample.Factory(parts);
        }

        

    }
}
