
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {
    public class COMMunicate : BaseCommand, CommandHasQuery {
        public COMMunicate(GPMDevice pd) : base(pd) { }
        public override IScpiCommand? ParentCommand { get => null; }
        public override string CommandString { get => ":COMMunicate"; }
        public override string CommandDescription { get => "Returns all communication settings."; }

        public async Task<bool> QueryDevice() {
            var success = false;
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(BuildCommandString() + query).ConfigureAwait(false);

            return success;
        }

        public async Task<bool> SetCommHeader(bool value) {
            if (this.ParentDevice.IsDisconnected) { return false; }
            return await this.ParentDevice.NetworkLink.SendToDevice(":COMM:HEAD " + (value?"1":"0")).ConfigureAwait(false);
        }

        public async Task<bool> SetCommVerbose(bool value) {
            if (this.ParentDevice.IsDisconnected) { return false; }
            return await this.ParentDevice.NetworkLink.SendToDevice(":COMM:VERB " + (value ? "1" : "0")).ConfigureAwait(false);
        }
    }

    public class COMMHeader : COMMunicate {
        public COMMHeader(GPMDevice pd) : base(pd) { }
        public override IScpiCommand? ParentCommand { get => new COMMunicate(this.ParentDevice); }
        public override string CommandString { get => ":HEADer"; }
        public override string CommandDescription { get => "Sets or returns whether headers are attached to query responses"; }

        public bool CommHeader { get; private set; } = false;
        public bool CommVerbose { get; private set; } = false;



        public async new Task<bool> SetCommHeader(bool on) {
            if (on == CommHeader) { return true; }
            var success = await this.ParentDevice.NetworkLink.SendToDevice(this.BuildCommandString(new[] { on ? "ON" : "OFF"})).ConfigureAwait(false);
            if (success) {
                CommHeader = on;
            } else {
                GPMDevice.LogError("SetCommHeader failed for " + this.ParentDevice.ToString());
            }
            return success;
        }

        public async Task<bool> GetCommHeader() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(this.BuildCommandString() + "?").ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = CleanUpResponse(s);
            if (s == "1") {
                CommHeader = true;
                return true;
            } else if (s == "0") {
                CommHeader = false;
                return true;
            }
            return false;
        }


        public async new Task<bool> SetCommVerbose(bool on) {
            if (on == CommVerbose) { return true; }
            var success = await this.ParentDevice.NetworkLink.SendToDevice(verboseCmd + " " + (on ? "ON" : "OFF")).ConfigureAwait(false);
            if (success) {
                CommVerbose = on;
            } else {
                GPMDevice.LogError("SetCommVerbose failed for " + this.ParentDevice.ToString());
            }
            return success;
        }

        public async Task<bool> GetCommVerbose() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(verboseCmd + "?").ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(verboseCmd, "");
            s = s.Replace(" ", "");
            if (s == "1") {
                CommVerbose = true;
                return true;
            } else if (s == "0") {
                CommVerbose = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// set default of HEAD 1; VERB 0
        /// </summary>
        public async Task<bool> InitializeCommand() {
            var success = await SetCommHeader(true).ConfigureAwait(false);
            if (!success) { return success; }
            success = await SetCommVerbose(false).ConfigureAwait(false);
            return success;
        }
        
    

        const string lockoutCmd = ":LOCKout";
        const string remoteCmd = ":REMote";
        const string statusCmd = ":STATus";
        const string verboseCmd = ":VERBose";

    }
}
