using GPMLib.Netcore;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable enable

namespace GPMLib.UI.Wpf {
    /// <summary>
    /// Interaction logic for GpmTranscriptWindow.xaml
    /// </summary>
    public partial class GpmTranscriptWindow : Window, IParentDevice {

        public GPMDevice ParentDevice { get; private set; }

        public GpmTranscriptWindow(GPMDevice pd) {
            InitializeComponent();
            this.ParentDevice = pd;

            this.Loaded += (s, e) => {

                // ListView Initialize
                var timeStampColumn = new GridViewColumn {
                    Header = "Timestamp",
                    DisplayMemberBinding = new Binding("TimestampFormatted")
                };
                var logLineColumn = new GridViewColumn {
                    Header = "Message",
                    DisplayMemberBinding = new Binding("LogLine")
                };
                var isOutboundColumn = new GridViewColumn {
                    Header = "I/O",
                    DisplayMemberBinding = new Binding("IsOutboundString")
                };
                var gridView = new GridView();
                gridView.Columns.Add(timeStampColumn);
                gridView.Columns.Add(logLineColumn);
                gridView.Columns.Add(isOutboundColumn);
                this.GpmTranscriptListView.View = gridView;

                ParentDevice.NetworkLink.TranscriptUpdateEvent += (s, e) => {
                    Dispatcher.Invoke(new Action(() => {
                        this.GpmTranscriptListView.Items.Add(e);

                    }));
                };
            };
        }
    }
}
