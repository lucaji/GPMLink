using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static GPMLib.DataReadings;

#nullable enable

namespace GPMLib.UI.Winforms {
    public partial class LiveReadingsControl : UserControl, IParentDevice {

        GPMDevice? _ParentDevice;
        public GPMDevice? ParentDevice {
            get => _ParentDevice;
            set {
                _ParentDevice = value;
                if (_ParentDevice is not null) {
                    _ParentDevice.NetworkLink.GetLiveReadingsEvent += (object sender, DataSample e) => {
                        if (this.InvokeRequired) {
                            this.Invoke(new Action(() => ProcessReading(e)));
                        } else {
                            ProcessReading(e);
                        }
                    };
                }
            }
        }

        public LiveReadingsControl() {
            InitializeComponent();
        }

        public void ProcessReading(DataSample r) {
            if (this.ParentDevice?.TheStats.LastReading is null) { return; }
            var volto = this.ParentDevice.TheStats.LastReading.VoltageFormattedValue.Split(GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsUIntegralValueLabel.SetText(volto.First() + GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsUDecimalValueLabel.SetText(volto.Last());
            ReadingsUUnitLabel.SetText(this.ParentDevice.TheStats.LastReading.VoltageUnit);

            var curro = this.ParentDevice.TheStats.LastReading.CurrentFormattedValue.Split(GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsIIntegralValueLabel.SetText(curro.First() + GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsIDecimalValueLabel.SetText(curro.Last());
            ReadingsIUnitLabel.SetText(this.ParentDevice.TheStats.LastReading.CurrentUnit);

            var pv = string.Empty;
            var pu = string.Empty;
            switch (this.ParentDevice.TheStats.PowerUnitDisplayOption) {
                case DisplayPowerOptionsEnum.DisplayVA:
                    pv = this.ParentDevice.TheStats.LastReading.PowerFormattedValue;
                    pu = this.ParentDevice.TheStats.LastReading.PowerUnit;
                    break;
                case DisplayPowerOptionsEnum.DisplayWh:
                    pv = this.ParentDevice.TheStats.LastReading.WhFormattedValue;
                    pu = this.ParentDevice.TheStats.LastReading.WhUnit;
                    break;
                case DisplayPowerOptionsEnum.DisplayAh:
                    pv = this.ParentDevice.TheStats.LastReading.AhFormattedValue;
                    pu = this.ParentDevice.TheStats.LastReading.AhUnit;
                    break;
            }
            var powo = pv.Split(GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsPIntegralValueLabel.SetText(powo.First() + GPMDevice.CultureDecimalSeparatorCharacter);
            ReadingsPDecimalValueLabel.SetText(powo.Last());
            ReadingsPUnitLabel.SetText(pu);
        }

        private void LiveReadingsControl_Load(object sender, EventArgs e) {
            // POWER UNIT SELECTION BUTTONS
            this.ReadingsPowerUnitVAButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                this.ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayVA;
            };
            this.ReadingsPowerUnitAhButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayAh;
            };
            this.ReadingsPowerUnitWhButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayWh;
            };
        }
    }
}
