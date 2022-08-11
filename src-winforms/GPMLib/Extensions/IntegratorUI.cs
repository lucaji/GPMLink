using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GPMLib.INTEGrator;

namespace GPMLib {
    public static class IntegratorUI {

        //public static Color IntegratorStatusUIForegroundColor(this INTEGrator i) {
        //    Color fg = Color.White;
        //    switch (i.IntegratorStatus) {
        //        case GPMIntegratorStatusEnum.Unknown:
        //            break;
        //        case GPMIntegratorStatusEnum.Error:
        //            fg = Color.Red;
        //            break;
        //        case GPMIntegratorStatusEnum.Reset:
        //            fg = Color.GreenYellow;
        //            break;
        //        case GPMIntegratorStatusEnum.Start:
        //            fg = Color.Orange;
        //            break;
        //        case GPMIntegratorStatusEnum.Stop:
        //            fg = Color.DarkOrange;
        //            break;
        //        case GPMIntegratorStatusEnum.Timeup:
        //            fg = Color.Violet;
        //            break;
        //    }
        //    return fg;
        //}


        public static string IntegratorResetUICommandString(this INTEGrator i) {
            string s = string.Empty;
            switch (i.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    s = "OFFLINE";
                    break;
                case GPMIntegratorStatusEnum.Error:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Start:
                    s = "STOP";
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    s = "RESET";
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    s = "RESET";
                    break;
            }
            return s;
        }

        public static string IntegratorStatusUIString(this INTEGrator i) {
            string s = string.Empty;
            switch (i.IntegratorStatus) {
                case GPMIntegratorStatusEnum.Unknown:
                    s = "OFFLINE";
                    break;
                case GPMIntegratorStatusEnum.Error:
                    s = "ERROR";
                    break;
                case GPMIntegratorStatusEnum.Reset:
                    s = "READY";
                    break;
                case GPMIntegratorStatusEnum.Start:
                    s = "RUNNING";
                    break;
                case GPMIntegratorStatusEnum.Stop:
                    s = "PAUSED";
                    break;
                case GPMIntegratorStatusEnum.Timeup:
                    s = "STOPPED";
                    break;
            }
            return s;
        }

    }
}
