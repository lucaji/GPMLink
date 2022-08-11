using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GPMLib.Netcore {
    public static class DataReadingsUI {

        #region CSV Export

        public static void ExportDataCsv(this DataReadings rs, string pathname, int x1 = 0, int x2 = 0) {
            var myExport = new CsvExport();
            var data = rs.ReadingsBetween(x1, x2);
            foreach (var r in data) {
                myExport.AddRow();
                myExport["Date"] = r.TimeStampDate;
                myExport["Time"] = r.TimeStampTimeOfDay;
                myExport["U"] = r.Voltage.ToString();
                myExport["I"] = r.Current.ToString();
                myExport["P"] = r.Power.ToString();
                myExport["Wh"] = r.Wh.ToString();
                myExport["mAh"] = r.mAh.ToString();
                myExport["Integrator Time"] = r.IntegratorTime.ToString();
            }
            myExport.ExportToFile(pathname);
            //FileShellUtils.ExecuteAtPath(pathname);
        }

        #endregion


        static readonly string VoltageUnit = "V";
        static readonly string CurrentUnit = "A";
        static readonly string PowerUnit = "W";
        static readonly string AhUnit = "Ah";
        static readonly string WhUnit = "Wh";




        public static string UMaxFormattedWithUnit(this DataReadings r) {
            string unit = VoltageUnit;
            return r.UMax.FormatWithUnit(ref unit);
        }
        public static double UMaxFormattedNoUnit(this DataReadings r) {
            string unit = VoltageUnit;
            return MeasurementValueFormatter.FormatDoubleExpand(r.UMax, ref unit);
        }

        public static string UMinFormattedWithUnit(this DataReadings r) {
            string unit = VoltageUnit;
            return r.UMin.FormatWithUnit(ref unit);
        }


        public static string IMaxFormattedWithUnit(this DataReadings r) {
            string unit = CurrentUnit;
            return r.IMax.FormatWithUnit(ref unit);
        }
        public static double IMaxFormattedNoUnit(this DataReadings r) {
            string unit = CurrentUnit;
            return MeasurementValueFormatter.FormatDoubleExpand(r.IMax, ref unit);
        }

        public static string IMinFormattedWithUnit(this DataReadings r) {
            string unit = CurrentUnit;
            return r.IMin.FormatWithUnit(ref unit);
        }
        public static double IMinFormattedNoUnit(this DataReadings r) {
            string unit = CurrentUnit;
            return MeasurementValueFormatter.FormatDoubleExpand(r.IMin, ref unit);
        }

        public static string PMaxFormattedWithUnit(this DataReadings r) {
            string unit = PowerUnit;
            return r.PMax.FormatWithUnit(ref unit);
        }

        public static string PMinFormattedWithUnit(this DataReadings r) {
            string unit = PowerUnit;
            return r.PMin.FormatWithUnit(ref unit);
        }

        public static string AhMaxFormattedWithUnit(this DataReadings r) {
            string unit = AhUnit;
            return r.AhMax.FormatWithUnit(ref unit);
        }
        public static double AhMaxFormattedNoUnit(this DataReadings r) {
            string unit = AhUnit;
            return MeasurementValueFormatter.FormatDoubleExpand(r.AhMax, ref unit);
        }

        public static string AhMinFormattedWithUnit(this DataReadings r) {
            string unit = AhUnit;
            return r.AhMin.FormatWithUnit(ref unit);
        }

        public static string WhMaxFormattedWithUnit(this DataReadings r) {
            string unit = WhUnit;
            return r.WhMax.FormatWithUnit(ref unit);
        }

        public static string WhMinFormattedWithUnit(this DataReadings r) {
            string unit = WhUnit;
            return r.WhMin.FormatWithUnit(ref unit);
        }
    }

}
