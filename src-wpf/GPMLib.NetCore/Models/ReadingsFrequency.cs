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
 * Luca Cipressi
 * 
 * v. 0.1 - June 2021 - first release
 * v. 0.2 - Juli 2021 - adding CSV and timers
 * 
 */


#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace GPMLib.Netcore {
    public enum ReadingsFrequencyEnum {
        Undefined,
        Hz_0_1, // 0,1 Hz 10,0s
        Hz_0_2, // 0,2 Hz  5,0s
        Hz_0_5, // 0,5 Hz  2,0s
        Hz_1_0, // 1,0 Hz  1,0s
        Hz_2_0  // 2,0 Hz  0,5s
    }

    public static class ReadingsFrequency {


        static readonly List<(ReadingsFrequencyEnum, string, int)> _ReadingsSpeeds = new() {
            (ReadingsFrequencyEnum.Undefined, "Undefined", 0),
            (ReadingsFrequencyEnum.Hz_0_1, "10 s", 10000),
            (ReadingsFrequencyEnum.Hz_0_1, "5 s", 5000),
            (ReadingsFrequencyEnum.Hz_0_5, "2 s", 2000),
            (ReadingsFrequencyEnum.Hz_1_0, "1 s", 1000),
            (ReadingsFrequencyEnum.Hz_2_0, "0,5 s", 500),
        };


        public static List<string> ReadingsFrequenciesList {
            get {
                var f = _ReadingsSpeeds.Where(cr => cr.Item1 != ReadingsFrequencyEnum.Undefined);
                return f.Select<(ReadingsFrequencyEnum, string, int), string>(r => r.Item2).ToList();
            }
        }

        public static ReadingsFrequencyEnum ReadingsSpeedEnumFromString(string modeString) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item2 == modeString);
            if (r == default) { return ReadingsFrequencyEnum.Undefined; }
            return r.Item1;
        }

        public static string ReadingsSpeedEnumToString(ReadingsFrequencyEnum rse) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item1 == rse);
            if (r == default) { return "Undefined"; }
            return r.Item2;
        }

        public static int ReadingsSpeedEnumToDelay(ReadingsFrequencyEnum rse) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item1 == rse);
            if (r == default) { return 1000; }
            return r.Item3;
        }

        public static ReadingsFrequencyEnum DelayToReadingsSpeedEnum(int d) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item3 == d);
            if (r == default) { return ReadingsFrequencyEnum.Undefined; }
            return r.Item1;
        }


        public static int ReadingsSpeedStringToDelay(string rse) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item2 == rse);
            if (r == default) { return 1000; }
            return r.Item3;
        }

        public static string DelayToString(int d) {
            var r = _ReadingsSpeeds.FirstOrDefault(cr => cr.Item3 == d);
            if (r == default) { return "Undefined"; }
            return r.Item2;
        }
    }
}
