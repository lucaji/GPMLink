using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GPMLib {


   

    public class INTEGrator : IParentDevice {

        public enum GPMIntegratorStatusEnum {
            Unknown,
            Error, // Integration Overflows
            Reset, // Integration resets
            Start, // Integration is in progress
            Stop, // Integration stopped
            Timeup // Integration stops due to timeout
        }

        public enum GPMIntegratorModeEnum {
            Unknown,
            Manual, // manual integration mode
            Normal, // standard integration mode
            Continuous // continuous integration mode
        }

        public enum GPMIntegratorFunctionEnum {
            Unknown,
            Watt, // select the integration function watt
            Ampere // select the integration function ampere
        }

        const string IntegratorModeCommand = ":INTEG:MODE";
        const string IntegratorStateCommand = ":INTEG:STAT";


        public GPMDevice ParentDevice { get; }

        public INTEGrator(GPMDevice pd) {
            this.ParentDevice = pd;
        }

        #region Status

        // enum, ui string, cmd string
        public static readonly List<(GPMIntegratorStatusEnum, string, string)> IntegratorStatuses = new() {
            (GPMIntegratorStatusEnum.Unknown, "Unknown", "x"),
            (GPMIntegratorStatusEnum.Error, "Error", "ERR"),
            (GPMIntegratorStatusEnum.Reset, "Reset", "RES"),
            (GPMIntegratorStatusEnum.Start, "Start", "STAR"),
            (GPMIntegratorStatusEnum.Stop, "Stop", "STOP"),
            (GPMIntegratorStatusEnum.Timeup, "Timeup", "TIM"),
        };

        public GPMIntegratorStatusEnum ParseStatusResponse(string r) {
            if (string.IsNullOrWhiteSpace(r)) { goto bail; }
            var e = IntegratorStatuses.FirstOrDefault(s => s.Item3.Equals(r));
            if (e == default) { goto bail; }
            return e.Item1;
        bail: return GPMIntegratorStatusEnum.Unknown;
        }

        public GPMIntegratorStatusEnum IntegratorStatus { get; private set; } = GPMIntegratorStatusEnum.Unknown;
       
        public string IntegratorStatusString { get { return IntegratorStatuses.First(i => i.Item1 == this.IntegratorStatus).Item2; } }

        public async Task<bool> GetIntegratorStatus() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(IntegratorStateCommand + "?");
            if (string.IsNullOrWhiteSpace(s)) { 
                return false; 
            }
            //s = s.Replace(IntegratorStateCommand + " ", ""); // not returning the query command in response
            this.IntegratorStatus = ParseStatusResponse(s);
            return this.IntegratorStatus != GPMIntegratorStatusEnum.Unknown;
        }



        #endregion


        #region Mode

        public static readonly List<(GPMIntegratorModeEnum, string, string)> IntegratorModi = new() {
            (GPMIntegratorModeEnum.Unknown, "Unknown", "x"),
            (GPMIntegratorModeEnum.Manual, "Manual", "MANU"),
            (GPMIntegratorModeEnum.Normal, "Normal", "NORM"),
            (GPMIntegratorModeEnum.Continuous, "Continuous", "CONT"),
        };

        public GPMIntegratorModeEnum ParseModusResponse(string r) {
            if (string.IsNullOrWhiteSpace(r)) { goto bail; }
            var e = IntegratorModi.FirstOrDefault(s => s.Item3.Equals(r));
            if (e == default) { goto bail; }
            return e.Item1;
        bail: return GPMIntegratorModeEnum.Unknown;
        }

        readonly GPMIntegratorModeEnum _IntegratorMode = GPMIntegratorModeEnum.Unknown;

        public GPMIntegratorModeEnum IntegratorMode {
            get { return _IntegratorMode; }
            private set {
                
            }
        } 

        public async Task<bool> GetIntegratorMode() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(IntegratorModeCommand + "?");
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s.Replace(IntegratorModeCommand + " ", "");
            this.IntegratorMode = ParseModusResponse(s);
            return this.IntegratorMode != GPMIntegratorModeEnum.Unknown;
        }


        async Task<bool> SetIntegratorMode(GPMIntegratorModeEnum e) {
            if (e == GPMIntegratorModeEnum.Unknown) { return false; }
            var modeString = IntegratorModi.First(l => l.Item1 == e).Item3;
            return await this.ParentDevice.NetworkLink.SendToDevice(IntegratorModeCommand + " " + modeString);
        }

        #endregion

        public string StartStopButtonText {
            get {
                string startIntegratorText = string.Empty;
                switch (this.ParentDevice.TheStats.IntegratorCommand.IntegratorStatus) {
                    case GPMIntegratorStatusEnum.Unknown:
                        startIntegratorText = this.ParentDevice.IsConnected ? "UNKNOWN" : "CONNECT";
                        break;
                    case GPMIntegratorStatusEnum.Error:
                        startIntegratorText = "RESTART";
                        break;
                    case GPMIntegratorStatusEnum.Reset:
                        startIntegratorText = "START";
                        break;
                    case GPMIntegratorStatusEnum.Start:
                        startIntegratorText = "PAUSE";
                        break;
                    case GPMIntegratorStatusEnum.Stop:
                        startIntegratorText = "RESUME";
                        break;
                    case GPMIntegratorStatusEnum.Timeup:
                        startIntegratorText = "RESTART";
                        break;
                }
                return this.ParentDevice.IsConnected? startIntegratorText : "CONNECT";
            }
        }

        #region Integration Function


        public static readonly List<(GPMIntegratorFunctionEnum, string, string)> IntegratorFunctions = new() {
            (GPMIntegratorFunctionEnum.Unknown, "Unknown", ""),
            (GPMIntegratorFunctionEnum.Watt, "Watt", "WATT"),
            (GPMIntegratorFunctionEnum.Ampere, "Ampere", "AMPE"),
        };

        public GPMIntegratorFunctionEnum ParseIntfunctionResponse(string r) {
            if (string.IsNullOrWhiteSpace(r)) { goto bail; }
            var e = IntegratorFunctions.FirstOrDefault(s => s.Item3.Equals(s));
            if (e == default) { goto bail; }
            return e.Item1;
        bail: return GPMIntegratorFunctionEnum.Unknown;
        }

        readonly GPMIntegratorFunctionEnum IntegratorFunction = GPMIntegratorFunctionEnum.Unknown;



        #endregion


        #region Integration Timer


        public int TimerHours { get; private set; }
        public int TimerMinutes { get; private set; }
        public int TimerSeconds { get; private set; }

        public TimeSpan TimerDuration { 
            get {
                return TimeSpan.FromSeconds(TimerSeconds) +
                    TimeSpan.FromMinutes(TimerMinutes) +
                    TimeSpan.FromHours(TimerHours);
            } 
        }

        public async Task<bool> SetTimer(int hh, int mm, int ss) {
            if (hh > 23) { hh = 23; } else if (hh < 0) { hh = 0; }
            if (mm > 59) { mm = 59; } else if (mm < 0) { mm = 0; }
            if (ss > 59) { ss = 59; } else if (ss < 0) { ss = 0; }

            var cmd = string.Format(":INTEG:TIM {0},{1},{2}", hh, mm, ss);
            var success = await this.ParentDevice.NetworkLink.SendToDevice(cmd);
            if (!success) { return false; }
            TimerHours = hh;
            TimerMinutes = mm;
            TimerSeconds = ss;
            return true;
        }

        public async Task<bool> GetTimer() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith("INTEG:TIM?");
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            var values = s.Replace("INTEG:TIM ", "").Split(',');
            if (values.Length != 3) { return false; }
            var success = Int32.TryParse(values[0], out int hh);
            if (!success) { return false; }
            success = Int32.TryParse(values[1], out int mm);
            if (!success) { return false; }
            success = Int32.TryParse(values[2], out int ss);
            if (!success) { return false; }
            TimerHours = hh;
            TimerMinutes = mm;
            TimerSeconds = ss;
            return false;
        }

        #endregion



        public async Task<bool> StartIntegrator() {
            return await this.ParentDevice.NetworkLink.SendToDevice(":INTEG:STAR");
        }

        public async Task<bool> StopIntegrator() {
            return await this.ParentDevice.NetworkLink.SendToDevice(":INTEG:STOP");
        }

        public async Task<bool> ResetIntegrator() {
            _ = await StopIntegrator();
            return await this.ParentDevice.NetworkLink.SendToDevice(":INTEG:RES");
        }






    }
}
