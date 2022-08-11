using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using System.Diagnostics;
using GPMLib;

#nullable enable

namespace GPMLink {
    public partial class ExportProgressForm : Form, IParentDevice {

        public List<DataSample>? Data { get; set; }

        public enum ExportDataFormatEnum {
            ExportAsExcel,
            ExportAsCsv,
            ExportExcelAndCsv
        }

        ExportDataFormatEnum ExportFileFormat {
            get {
                if (this.ExportAsExcelRadioButton.Checked) { return ExportDataFormatEnum.ExportAsExcel; }
                if (this.ExportAsCsvRadioButton.Checked) { return ExportDataFormatEnum.ExportAsCsv; }
                return ExportDataFormatEnum.ExportExcelAndCsv;
            }
        }

        bool exportCsv => ExportFileFormat == ExportDataFormatEnum.ExportExcelAndCsv ? true : ExportFileFormat == ExportDataFormatEnum.ExportAsCsv;
        bool exportExcel => ExportFileFormat == ExportDataFormatEnum.ExportExcelAndCsv ? true : ExportFileFormat == ExportDataFormatEnum.ExportAsExcel;

        bool ExportRangeSelectionOnly => this.ExportSelectedRangeRadioButton.Checked;



        public string Message { 
            set {
                LabelMessage.SetText(value); 
            } 
        }

        public int ProgressValue { set { 
                ProgressBar1.SetValue(value); 
            } 
        }

        private string? _DestinationPath;
        private string? _DestinationFileName => LastPathComponent(_DestinationPath);

        static string? LastPathComponent(string? s) {
            if (string.IsNullOrWhiteSpace(s)) { return null; }
            var n = s!.LastIndexOf(Path.DirectorySeparatorChar);
            if (n < 1) return string.Empty;
            return s.Substring(n + 1);
        }

        public string DateNowFileFormatted => DateTime.Now.ToString("yyMMdd hhmmss");

        private void BrowseButton_Click(object sender, EventArgs e) {
            string filterOptions() {
                if (ExportFileFormat == ExportDataFormatEnum.ExportAsCsv) {
                    return "CSV Files (*.csv)|*.csv;*.csv";
                }
                return "Excel Document (*.*)|*.xlsx;*.xlsx";
            }

            var filename = "GPM8310 Log " + DateNowFileFormatted;
            var sfd = new SaveFileDialog {
                FileName = filename,
                CheckPathExists = true,
                Filter = filterOptions(),
                OverwritePrompt = true,
                Title = "Save GPM830 Data to..."
            };

            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            _DestinationPath = sfd.FileName;
            this.DestinationLinkLabel.SetText(_DestinationPath);
            if (File.Exists(_DestinationPath)) {
                try {
                    File.Delete(_DestinationPath);
                } catch (Exception ex) {
                    Trace.WriteLine(ex);
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }

            

            if (exportCsv) {

            }

            if (exportExcel) {
                try {
                    var data = Properties.Resources.ChargingPlotTemplate;
                    var len = data.Length;
                    using var fs = new FileStream(_DestinationPath, FileMode.Create, FileAccess.Write);
                    fs.Write(data, 0, len);
                } catch (Exception ex) {
                    Trace.WriteLine(ex);
                    return;
                }
            }

            Exporta();
            // this.backgroundWorker1.RunWorkerAsync();
            this.Close();
        }

        public GPMDevice? ParentDevice { get; private set; }

        public void ShowFileDialogAndExport(GPMDevice gpm, List<DataSample> data) {
            ParentDevice = gpm;
            Data = data;
            this.ShowDialog();
        }

        public ExportProgressForm() {
            InitializeComponent();


        }



        public event EventHandler<EventArgs>? Canceled;

        private void buttonCancel_Click(object sender, EventArgs e) {
            // Create a copy of the event to work with
            //EventHandler<EventArgs>? ea = Canceled;
            //if (ea is not null) { ea(this, e); }
            this.Close();
        }


        private void ProgressForm_Load(object sender, EventArgs e) {
            //if (backgroundWorker1.IsBusy) return;
            //this.Canceled += new EventHandler<EventArgs>(buttonCancelAction_Click);
        }

     

        private void buttonCancelAction_Click(object sender, EventArgs e) {
            //if (backgroundWorker1.WorkerSupportsCancellation) {
            //    backgroundWorker1.CancelAsync();
            //}
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            if (sender is not BackgroundWorker bg) { return; } 
        }

        private bool Exporta() { 
            if (string.IsNullOrWhiteSpace(_DestinationPath)) { goto bail; }
            if ((Data?.Count ?? 0) == 0) { goto bail; }

            var wb = new XLWorkbook(_DestinationPath);
            if (wb is null) { goto bail; }
            var ws1 = wb.Worksheets.FirstOrDefault(ws => ws.Name == "DATA");
            if (ws1 is null) { goto bail; }

            //ws1.Cell("A1").Value = "TIMESTAMP";
            //ws1.Cell("B1").Value = "TIME";
            //ws1.Cell("C1").Value = "U";
            //ws1.Cell("D1").Value = "I";
            //ws1.Cell("E1").Value = "P";
            //ws1.Cell("F1").Value = "Wh";
            //ws1.Cell("G1").Value = "mAh";
            //ws1.Cell("H1").Value = "DUR";

            long rowCursor = 2;
            var count = Data!.Count;
            var progStep = count / 100;
            var prog = 0;
            foreach (var s in Data) {
                ws1.Cell("A" + rowCursor).Value = s.TimeStampDate;
                ws1.Cell("B" + rowCursor).Value = s.TimeStampTimeOfDay;
                ws1.Cell("C" + rowCursor).Value = s.Voltage;
                ws1.Cell("D" + rowCursor).Value = s.Current;
                ws1.Cell("E" + rowCursor).Value = s.Power;
                ws1.Cell("F" + rowCursor).Value = s.Wh;
                ws1.Cell("G" + rowCursor).Value = s.mAh;
                ws1.Cell("H" + rowCursor).Value = s.IntegratorExcelTime;
                rowCursor++;
                prog += progStep;
                this.ProgressValue = prog;
                // bg.ReportProgress(prog);
            }
            //var t = ws1.Tables.FirstOrDefault(t => t.Name == "GPMTable");
            //if (t is null) {
            //    MessageBox.Show("Unable to find the template table.");
            //    goto bail;
            //}
            //var range = t.Rows().
            wb.Save();
            return true;
        bail:
            return false;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) return;
            if (e.Error != null) return;
            this.Close();
        }

        private void ExportProgressForm_FormClosing(object sender, FormClosingEventArgs e) {

        }


    }
}
