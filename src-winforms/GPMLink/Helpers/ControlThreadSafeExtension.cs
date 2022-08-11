using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace GPMLink {

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

        public static void SetValue(this ProgressBar pb, int value) {
            if (pb.IsNotValid()) { return; }
            try {
                if (value < 0) { value = 0; }
                if (value > 100) { value = 100; }
                if (pb.InvokeRequired) {
                    pb.Invoke(setValue, pb, value);
                } else {
                    pb.Value = value;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }

        private static readonly Action<ProgressBar, int> setValue = (control, valo) => control.Value = valo;

    }


}
