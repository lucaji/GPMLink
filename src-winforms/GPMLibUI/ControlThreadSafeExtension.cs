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
using System.Diagnostics;
using System.Windows.Forms;


namespace GPMLib.UI.Winforms {

    public static class ControlThreadSafeExtension {

        public static bool IsNotValid(this Control ctrl) {
            return (ctrl is null || ctrl.IsDisposed || ctrl.Disposing);
        }

        public static void SetText(this Control control, string text) {
            if (control.IsNotValid()) { return; }
            try {
                if (control.InvokeRequired) {
                    control.Invoke(setText, control, text);
                } else {
                    control.Text = text;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private static readonly Action<Control, string> setText = (control, text) => control.Text = text;


        public static void SetChecked(this RadioButton control, bool isChecked) {
            if (control.IsNotValid()) { return; }
            try {
                if (control.InvokeRequired) {
                    control.Invoke(setCheckedRB, control, isChecked);
                } else {
                    control.Checked = isChecked;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private static readonly Action<RadioButton, bool> setCheckedRB = (control, isChecked) => control.Checked = isChecked;

        public static void SetChecked(this CheckBox control, bool isChecked) {
            if (control.IsNotValid()) { return; }
            try {
                if (control.InvokeRequired) {
                    control.Invoke(setCheckedCB, control, isChecked);
                } else {
                    control.Checked = isChecked;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private static readonly Action<CheckBox, bool> setCheckedCB = (control, isChecked) => control.Checked = isChecked;

        //public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control {
        //    if (c.InvokeRequired) {
        //        c.Invoke(new Action(() => action(c)));
        //    } else {
        //        action(c);
        //    }
        //}
    }


}
