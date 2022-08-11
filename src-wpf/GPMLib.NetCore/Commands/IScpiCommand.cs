using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {

    public interface IScpiCommand : IParentDevice {

        // public abstract IScpiCommand? ParentCommand { get; }

        public abstract string CommandString { get; }

        public string CommandDescription { get; }

        public EventHandler<BaseCommand> NotifyChangedEvent { get; set; }


        public string BuildCommandString(string[]? parameters = null);

        public bool ParseResponseString(GPMDevice m, string s);
    }
}
