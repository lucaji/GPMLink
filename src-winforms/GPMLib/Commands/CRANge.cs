using System;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {


    /// <summary>
    /// Sets or returns the check range status.
    /// </summary>
    public class CRANge : IParentDevice {


        [Flags]
        public enum CrangeBitsResponseEnum {
            VoltageShouldReduceAutoRange = 0,
            VoltageShouldRaiseAutoRange = 2,
            VoltageOverRange = 4,
            VoltagePeakOverRange = 8,
            CurrentShouldReduceAutoRange = 16,
            CurrentShouldRaiseAutoRange = 32,
            CurrentOverRange = 64,
            CurrentPeakOverRange = 128
        }


        public bool VoltageShouldReduceAutoRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.VoltageShouldReduceAutoRange); } }
        public bool VoltageShouldRaiseAutoRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.VoltageShouldRaiseAutoRange); } }
        public bool VoltageOverRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.VoltageOverRange); } }
        public bool VoltagePeakOverRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.VoltagePeakOverRange); } }
        public bool CurrentShouldReduceAutoRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.CurrentShouldReduceAutoRange); } }
        public bool CurrentShouldRaiseAutoRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.CurrentShouldRaiseAutoRange); } }
        public bool CurrentOverRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.CurrentOverRange); } }
        public bool CurrentPeakOverRange { get { return RangeResponse.HasFlag(CrangeBitsResponseEnum.CurrentPeakOverRange); } }




        public CrangeBitsResponseEnum RangeResponse { get; private set; }

        static string cmd = "[:INPut]:CRANge?";

        public GPMDevice ParentDevice { get; }

        public CRANge(GPMDevice pd) {
            this.ParentDevice = pd;
        }

        public static CRANge? ParseStatusResponse(string r) {
            if (string.IsNullOrWhiteSpace(r)) { goto bail; }


        bail: return null;
        }

        public async Task<bool> GetCheckRangeStatus() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(cmd);
            if (string.IsNullOrWhiteSpace(s)) { goto bail; }

            var success = int.TryParse(s, out int response);
            if  (success) {
                RangeResponse = (CrangeBitsResponseEnum)response;
            }
            bail:
            return false;
        }



    }
}
