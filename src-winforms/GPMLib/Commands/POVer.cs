using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMLib {

    /// <summary>
    /// Returns the peak over-range information
    /// </summary>
    public class POVer : IParentDevice {

        static string cmd = "[:INPut]:POVer";

        public GPMDevice ParentDevice { get; }

        public POVer(GPMDevice pd) {
            this.ParentDevice = pd;
        }

    }
}
