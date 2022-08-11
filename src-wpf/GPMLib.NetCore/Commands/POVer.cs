using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMLib.Netcore {

    /// <summary>
    /// Returns the peak over-range information
    /// </summary>
    public class POVer : BaseCommand {

        public override string CommandDescription { get => "Manages the current range settings."; }
        public override string CommandString { get => ":DUMMY"; }


        static string cmd = "[:INPut]:POVer";

        public POVer(GPMDevice pd) : base(pd) { }

    }
}
