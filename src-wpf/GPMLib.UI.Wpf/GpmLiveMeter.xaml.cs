using GPMLib.Netcore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static GPMLib.Netcore.DataReadings;

#nullable enable

namespace GPMLib.UI.Wpf {
    /// <summary>
    /// Interaction logic for GpmLiveMeter.xaml
    /// </summary>
    public partial class GpmLiveMeter : UserControl, IParentDevice {

        GPMDevice? _ParentDevice;
        public GPMDevice? ParentDevice {
            get => _ParentDevice;
            set {
                _ParentDevice = value;
                if (_ParentDevice is null) { return; }
                _ParentDevice.NetworkLink.GetLiveReadingsEvent += (object? sender, DataSample e) => {
                    Dispatcher.Invoke(new Action(() => {
                        if (sender is not GPMDevice pd) { return; }
                        // if (this.ParentDevice?.TheStats.LastReading is null) { return; }
                        var volto = e.VoltageFormattedValue.Split(GPMDevice.CultureDecimalSeparatorCharacter);
                        UIntegralValueLabel.Content = volto.First() + GPMDevice.CultureDecimalSeparatorCharacter;
                        UDecimalValueLabel.Content = volto.Last();
                        UUnitLabel.Content = e.VoltageUnit;

                        var curro = e.CurrentFormattedValue.Split(GPMDevice.CultureDecimalSeparatorCharacter);
                        IIntegralValueLabel.Content = curro.First() + GPMDevice.CultureDecimalSeparatorCharacter;
                        IDecimalValueLabel.Content = curro.Last();
                        IUnitLabel.Content = e.CurrentUnit;

                        var pv = string.Empty;
                        var pu = string.Empty;
                        switch (pd.TheStats.PowerUnitDisplayOption) {
                            case DisplayPowerOptionsEnum.DisplayVA:
                                pv = e.PowerFormattedValue;
                                pu = e.PowerUnit;
                                break;
                            case DisplayPowerOptionsEnum.DisplayWh:
                                pv = e.WhFormattedValue;
                                pu = e.WhUnit;
                                break;
                            case DisplayPowerOptionsEnum.DisplayAh:
                                pv = e.AhFormattedValue;
                                pu = e.AhUnit;
                                break;
                        }
                        var powo = pv.Split(GPMDevice.CultureDecimalSeparatorCharacter);
                        PIntegralValueLabel.Content = powo.First() + GPMDevice.CultureDecimalSeparatorCharacter;
                        PDecimalValueLabel.Content = powo.Last();
                        PUnitLabel.Content = pu;
                    }));

                };
                
            }
        }

        public GpmLiveMeter() {
            InitializeComponent();
            this.PowerDisplayOptionVAButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                this.ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayVA;
            };
            this.PowerDisplayOptionAhButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayAh;
            };
            this.PowerDisplayOptionWhButton.Click += (s, e) => {
                if (this.ParentDevice is null) { return; }
                ParentDevice.TheStats.PowerUnitDisplayOption = DisplayPowerOptionsEnum.DisplayWh;
            };
        }
    }
}
