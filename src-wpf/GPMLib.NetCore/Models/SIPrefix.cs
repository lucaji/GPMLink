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

#nullable enable

namespace GPMLib.Netcore {
    public class SIPrefix : IEquatable<SIPrefix?> {

        public static List<SIPrefix> Prefixes = new List<SIPrefix>() {
            new SIPrefix("yotta", 'Y', 24),
            new SIPrefix("zetta", 'Z', 21),
            new SIPrefix("exa", 'E', 18),
            new SIPrefix("peta", 'P', 15),
            new SIPrefix("tera", 'T', 12),
            new SIPrefix("giga", 'G', 9),
            new SIPrefix("mega", 'M', 6),
            new SIPrefix("kilo", 'K', 3),
            SIPrefix.Unity,
            new SIPrefix("milli", 'm', -3),
            new SIPrefix("micro", 'μ', -6),
            new SIPrefix("nano", 'n', -9),
            new SIPrefix("pico", 'p', -12),
            new SIPrefix("femto", 'f', -15),
            new SIPrefix("atto", 'a', -18),
            new SIPrefix("zepto", 'z', -21),
            new SIPrefix("yocto", 'y', -24),
        };

        public static int ExpForPrefix(char p) {
            var pp = SIPrefix.Prefixes.FirstOrDefault(s => s.Symbol.Equals(p));
            return pp?.Exponent ?? 0;
        }

        public static SIPrefix? PrefixForExp(int exp) {
            var p = SIPrefix.Prefixes.FirstOrDefault(s => s.Exponent == exp);
            return p;
        }

        public SIPrefix(string n, char s, int exp) {
            Name = n;
            Symbol = s;
            Exponent = exp;
        }

        public static SIPrefix Unity { get => new SIPrefix("", '\0', 0); }

        public string Name { get; }
        public char Symbol { get; }
        public int Exponent { get; }
        public long Decimal { get { return (long)Math.Pow(10.0, (double)Exponent); } }

        public override bool Equals(object? obj) {
            return Equals(obj as SIPrefix);
        }

        public bool Equals(SIPrefix? other) {
            return other != null &&
                   Symbol == other.Symbol;
        }

        public override int GetHashCode() {
            return -1758840423 + Symbol.GetHashCode();
        }
    }
}
