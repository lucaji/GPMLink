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

/*
 * *
 * 
 * GW-Instek GPM-8310 C# Class
 * Luca Cipressi
 * 
 * v. 0.1 - June 2021 - first release
 * v. 0.2 - Juli 2021 - adding CSV and timers
 * 
 */

using System;

#nullable enable

namespace GPMLib {

    public class SerialTranscript {

        public static bool UseTimestamp = false;

        public DateTime Timestamp { get; } = DateTime.Now;

        public string LogLine { get; }

        public bool IsOutbound { get; }


        public string TimestampString { get { return Timestamp.ToString("HH:mm:ss"); } }
        public string IsOutboundString { get { return IsOutbound ? "OUT" : "IN"; } }

        public SerialTranscript(string log, bool isOutbound) {
            LogLine = log;
            IsOutbound = isOutbound;
        }

        public override string ToString() {
            var s = string.Empty;
            if (UseTimestamp) {
                s = Timestamp.ToString("HH:mm:ss") + " ";
            }
            s += (IsOutbound ? "> " : "< ") + LogLine;
            return s;
        }
    }

    
}
