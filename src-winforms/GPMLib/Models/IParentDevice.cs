using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMLib {
    public interface IParentDevice {
        public GPMDevice ParentDevice { get; }

    }
}
