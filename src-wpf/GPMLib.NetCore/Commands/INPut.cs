using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib.Netcore {
    public class INPut : BaseCommand {

        public override string CommandDescription { get => "Returns all input settings."; }
        public override string CommandString { get => ":DUMMY"; }

        /* COMMAND QUERY RESPONSES:
         * some commands might return without the ":" prefix ie. CFAC, WIR, MODE
         * 
         
        :INP?
        00.   CFAC 3;
        01.   WIR P1W2;
        02.   MODE DC;
        03.   :VOLT:RANG 15.0E+00;
        04.   AUTO 0;
        05.   :CURR:RANG 20.000E+00;
        06.   AUTO 0;
        07.   SRAT:ELEM1 10.000;
        08.   :SCAL 0;
        09.   VT:ELEM1 1.000;
        10.   :SCAL:CT:ELEM1 1.000;
        11.   :SCAL:SFAC:ELEM1 1.000;
        12.   :SYNC VOLT;
        13.   FILT:LINE 0;
        14.   FREQ 0

        :INP?
        CFAC 3;
        WIR P1W2;
        MODE DC;
        :VOLT:RANG 30.0E+00;
        AUTO 0;
        :CURR:RANG 1.000E+00;
        AUTO 0;
        SRAT:ELEM1 10.000;
        :SCAL 0;
        VT:ELEM1 1.000;
        :SCAL:CT:ELEM1 1.000;
        :SCAL:SFAC:ELEM1 1.000;
        :SYNC VOLT;
        FILT:LINE 0;
        FREQ 0

        */

        enum StatusQueryPartsEnum {
            p00_CrestFactor,
            p01_Wiring,
            p02_Mode,
            p03_VoltRange,
            p04_VoltRangeIsAuto,
            p05_CurRange,
            p06_CurRangeIsAuto,
            p07_Srat,
            p08_Scaling,
            p09_ScalingVT,
            p10_ScalingCT,
            p11_ScalingSFAC,
            p12_SyncType,
            p13_FilterLine,
            p14_FilterFreq
        }

        static readonly (StatusQueryPartsEnum, string)[] keywords = new (StatusQueryPartsEnum, string)[15] {
            (StatusQueryPartsEnum.p00_CrestFactor, "CFAC "), // crest factor
            (StatusQueryPartsEnum.p01_Wiring, "WIR "), // wiring system (P1W2 = Single Phase, 2 Wire System) fixed on GPM8310
            (StatusQueryPartsEnum.p02_Mode, "MODE "), // voltage and current measurement mode (DC, AC, ACDC, VMEAN)
            (StatusQueryPartsEnum.p03_VoltRange, ":VOLT:RANG "), // voltage range
            (StatusQueryPartsEnum.p04_VoltRangeIsAuto, "AUTO "), // voltage range is auto
            (StatusQueryPartsEnum.p05_CurRange, ":CURR:RANG "), // current range
            (StatusQueryPartsEnum.p06_CurRangeIsAuto, "AUTO "), // current range is auto
            (StatusQueryPartsEnum.p07_Srat, "SRAT:ELEM1 "), // external current sensor conversion ratio
            (StatusQueryPartsEnum.p08_Scaling, ":SCAL "), // scaling settings
            (StatusQueryPartsEnum.p09_ScalingVT, "VT:ELEM1 "), // VT ratio
            (StatusQueryPartsEnum.p10_ScalingCT, ":SCAL:CT:ELEM1 "), // CT ratio
            (StatusQueryPartsEnum.p11_ScalingSFAC, ":SCAL:SFAC:ELEM1 "), // 
            (StatusQueryPartsEnum.p12_SyncType, ":SYNC "), // sync type
            (StatusQueryPartsEnum.p13_FilterLine, "FILT:LINE "), // filter on/off
            (StatusQueryPartsEnum.p14_FilterFreq, "FREQ ") // filter frequency on/off
        };

        public enum CheckRangeStatusEnum {
            VoltageRangeReducing = 0x00,
            VoltageRangeIncreasing = 0x02,
            VoltageOverRange = 0x4,
            VoltagePeakOverRange = 0x8,

            CurrentRangeReducing = 0x10,
            CurrentRangeIncreasing = 0x20,
            CurrentOverRange = 0x40,
            CurrentPeakOverRange = 0x80,
        }


        public MODE InputMode { get { return this.DeviceInputMode; } }


        #region Inputs Control Handlers

        public CFACtor DeviceCrestFactor { get; private set; }
        public MODE DeviceInputMode { get; private set; }
        public VOLTage DeviceVoltageRange { get; private set; }
        public CURRent DeviceCurrentRange { get; private set; }

        #endregion

        public INPut(GPMDevice pd) : base(pd) {
            DeviceCrestFactor = new(pd);
            DeviceVoltageRange = new(pd);
            DeviceCurrentRange = new(pd);
            DeviceInputMode = new(pd);
        }


       
        public async Task<bool> GetInput() {
            var s = await this.ParentDevice.NetworkLink.QueryDeviceWith(":INP?");
            if (string.IsNullOrWhiteSpace(s)) { return false; }
            var parts = s!.Split(';');

            var cf = parts.FirstOrDefault(p => p.StartsWith(keywords[0].Item2));
            var success = this.DeviceCrestFactor.ParseResponseString(cf);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceCrestFactor."); }
            // input mode wont reply with ':'
            var im = parts.FirstOrDefault(p => p.StartsWith(keywords[2].Item2));
            success = this.DeviceInputMode.ParseResponseString(":" + im);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceInputMode."); }

            var vr = parts.FirstOrDefault(p => p.StartsWith(keywords[3].Item2));
            success = this.DeviceVoltageRange.ParseResponseString(vr);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceVoltageRange."); }

            var cr = parts.FirstOrDefault(p => p.StartsWith(keywords[5].Item2));
            success = this.DeviceCurrentRange.ParseResponseString(cr);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceCurrentRange."); }

            // Voltage Auto Range
            var va = parts.FirstOrDefault(p => p.StartsWith(keywords[4].Item2));
            success = this.DeviceVoltageRange.ParseResponseAutoString(":VOLT:" + va);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceVoltageRange AUTO."); }

            // Current Auto Range
            var ca = parts.FirstOrDefault(p => p.StartsWith(keywords[6].Item2));
            success = this.DeviceCurrentRange.ParseResponseAutoString(":CURR:" + ca);
            if (!success) { Trace.WriteLine("INPut GetInput error at DeviceCurrentRange AUTO."); }

            return success;
        }
    }
}
