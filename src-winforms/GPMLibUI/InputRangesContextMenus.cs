using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable enable

namespace GPMLib.UI.Winforms {
    public partial class InputRangesContextMenus : Component, IParentDevice {
        public GPMDevice? ParentDevice { get; set; }
        
        public InputRangesContextMenus() {
            InitializeComponent();
        }

        ToolStripButton[]? _CurrentRangeOptionsToolStripButtonList;
        public ToolStripButton[] CurrentRangeOptionsToolStripButtonList {
            get {
                if (_CurrentRangeOptionsToolStripButtonList is null) {
                    var n = CURRent.CurrentRangesList.Count;
                    _CurrentRangeOptionsToolStripButtonList = new ToolStripButton[n];
                    int i = 0;
                    foreach (var cr in CURRent.CurrentRangesList) {
                        ToolStripButton tb = new(cr.Item2);
                        tb.Click += (s, e) => {
                            if (this.ParentDevice?.IsIntegrating ?? true) { return; }
                            var t = s.ToString();
                            if (t.Equals("Auto")) {
                                _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRangeAuto(true);
                            } else {
                                var ir = CURRent.CurrentRangeFromStringWithUnit(t);
                                _ = ParentDevice.DeviceInputs.DeviceCurrentRange.SetDeviceCurrentRange(ir);
                            }
                        };
                        _CurrentRangeOptionsToolStripButtonList[i++] = tb;
                    }
                }
                return _CurrentRangeOptionsToolStripButtonList;
            }
        }

        ToolStripButton[]? _VoltageRangeOptionsToolStripButtonList;

        public ToolStripButton[] VoltageRangeOptionsToolStripButtonList {
            get {
                if (_VoltageRangeOptionsToolStripButtonList is null) {
                    var n = VOLTage.VoltageRangesList.Count;
                    _VoltageRangeOptionsToolStripButtonList = new ToolStripButton[n];
                    int i = 0;
                    foreach (var cr in VOLTage.VoltageRangesList) {
                        ToolStripButton tb = new(cr.Item2);
                        tb.Click += (s, e) => {
                            if (this.ParentDevice?.IsIntegrating ?? true) { return; }
                            var t = s.ToString();
                            if (t.Equals("Auto")) {
                                _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRangeAuto(true);
                            } else {
                                var vr = VOLTage.VoltageRangeFromStringWithUnit(t);
                                _ = ParentDevice.DeviceInputs.DeviceVoltageRange.SetDeviceVoltageRange(vr);
                            }
                        };
                        _VoltageRangeOptionsToolStripButtonList[i++] = tb;
                    }
                }
                return _VoltageRangeOptionsToolStripButtonList;
            }
        }

        public InputRangesContextMenus(IContainer container) {
            container.Add(this);

            InitializeComponent();

            
            this.CurrentRangeContextMenuStrip.Items.AddRange(this.CurrentRangeOptionsToolStripButtonList);
            this.CurrentRangeContextMenuStrip.Opening += (sender, e) => {
                if (sender is not ContextMenuStrip ts) { return; }
                if (ts is not IParentDevice pd) { return; }
                var s = pd.ParentDevice.DeviceInputs.DeviceCurrentRange.ToString();
                foreach (ToolStripButton m in ts.Items) {
                    m.Checked = m.Text == s;
                    m.Enabled = !pd.ParentDevice.IsIntegrating;
                }
            };

            this.VoltageRangeContextMenuStrip.Items.AddRange(this.VoltageRangeOptionsToolStripButtonList);
            this.VoltageRangeContextMenuStrip.Opening += (sender, e) => {
                if (sender is not ContextMenuStrip ts) { return; }
                if (ts is not IParentDevice pd) { return; }
                var s = pd.ParentDevice.DeviceInputs.DeviceVoltageRange.ToString();
                foreach (ToolStripButton m in ts.Items) {
                    m.Checked = m.Text == s;
                    m.Enabled = !pd.ParentDevice.IsIntegrating;
                }
            };
        }
    }
}
