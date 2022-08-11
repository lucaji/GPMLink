using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {


    public interface CommandHasQuery {
        public abstract Task<bool> QueryDevice();

    }


    public abstract class BaseCommand : IScpiCommand {

        protected const string blanko = " ";
        protected const string query = "?";

        public BaseCommand(GPMDevice pd) { ParentDevice = pd; }

        //public abstract IScpiCommand? ParentCommand { get; }
        public abstract string CommandString { get; } 
        public abstract string CommandDescription { get; }

        public GPMDevice ParentDevice { get; }

        public EventHandler<BaseCommand> NotifyChangedEvent { get; set; }


        static Regex _commandOptionalPartRegex = new Regex(@"\[.*\]");
        public static bool GetCommandOptionalSyntax(string cmd, out string optional) {
            optional = string.Empty;
            var mc = _commandOptionalPartRegex.Matches(cmd);
            foreach (string m in mc) {
                if (string.IsNullOrWhiteSpace(m)) {
                    continue;
                } else {
                    optional = m;
                    return true;
                }
            }
            return false;
        }


        public bool IsCommandLongForm { get; protected set; }


        public static bool RemoveOptionals(string source, out string removed) {
            removed = string.Empty;
            var success = false;
            bool foundOpening = false;
            bool foundClosing = false;
            foreach (var c in source) {
                if (!foundOpening) {
                    if (c == '[') { foundOpening = true; }
                } else if (!foundClosing) {
                    if (c == ']') { foundClosing = true; }
                }
            }
            return success;
        }

        public static bool ShortCommandStringFromVerboseCommandString(string longcmd, out string shortcmd, out string optional) {
            shortcmd =
            optional = string.Empty;
            try {
                var hasOptional = GetCommandOptionalSyntax(longcmd, out string opt);
                if (hasOptional) {
                    optional = opt;
                }
                shortcmd = string.Concat(longcmd.Where(c => (c >= 'A' && c <= 'Z')
                                                        //|| (c == '[' || c == ']') // optional part
                                                        || (c == '*')
                                                        || (c == ':')
                                                   ));
                return true;
            } catch (Exception ex) {
                GPMDevice.LogError(ex.ToString());
            }
            return false;
        }

        public virtual string CleanUpResponse(string resp) {
            return resp.ToUpperInvariant().TrimStart(this.CommandString.ToCharArray()).Replace(blanko, string.Empty);
        }

        public virtual bool ParseResponseString(GPMDevice m, string s) {
            throw new NotImplementedException();
        }

        public string BuildCommandString(string[]? parameters = null) {
            //if (this.ParentCommand is null) { 
            //    return this.CommandString; 
            //}
            //var result = this.ParentCommand.BuildCommandString();
            //if (parameters is not null) {
            //    foreach (var p in parameters) {
            //        result += " " + p;
            //    }
            //}
            
            return string.Empty;
        }
    }
}
