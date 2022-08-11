using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {
    public class COMMunicate : BaseCommand, CommandHasQuery {

        //const string lockoutCmd = ":LOCKout";
        //const string remoteCmd = ":REMote";
        //const string statusCmd = ":STATus";
        //const string verboseCmd = ":VERBose";

        public COMMunicate(GPMDevice pd) : base(pd) { }
        public override string CommandString { get => ":COMMunicate"; }
        public override string CommandDescription { get => "Returns all communication settings."; }

        public bool CommHeader { get; private set; } = false;
        public bool CommVerbose { get; private set; } = false;

        public async Task<bool> QueryDevice() {
            var success = false;
            _ = await this.ParentDevice.NetworkLink.QueryDeviceWith(BuildCommandString() + query).ConfigureAwait(false);
            return success;
        }

        public async Task<bool> SetCommHeader(bool on) {
            if (this.ParentDevice.IsDisconnected) { return false; }
            if (on == CommHeader) { return true; }
            return await this.ParentDevice.NetworkLink.SendToDevice(":COMM:HEAD " + (on?"1":"0")).ConfigureAwait(false);
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


        public async Task<bool> SetCommVerbose(bool on) {
            if (this.ParentDevice.IsDisconnected) { return false; }
            if (on == CommVerbose) { return true; }
            return await this.ParentDevice.NetworkLink.SendToDevice(":COMM:VERB " + (on ? "1" : "0")).ConfigureAwait(false);
        }


        public async Task<bool> GetCommVerbose() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":COMM:VERB?").ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            s = s!.Replace(":COMM:VERB ", "");
            if (s == "1") {
                CommVerbose = true;
                return true;
            } else if (s == "0") {
                CommVerbose = false;
                return true;
            }
            return false;
        }


    }

}
