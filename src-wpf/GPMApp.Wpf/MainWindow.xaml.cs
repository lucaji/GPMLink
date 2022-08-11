using BauerMeterApp.WPF.Helpers;

using Gpm8310.Commands;
using Gpm8310.Helpers;
using Gpm8310.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

using UIComponents.WPF;

using UIComponentsWPF;

#nullable enable

namespace BauerMeterAppWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IParentDevice {

        Device _ParentDevice = Device.DefaultLocal;

        public Device ParentDevice { 
            get { 
                if (_ParentDevice is null) {
                    _ParentDevice = Device.DefaultLocal;
                }
                return _ParentDevice;
            } 
            private set {
                _ParentDevice = value;
                this.Title = _ParentDevice.ToString();
                this.PlotControl.ParentDevice =
                this.InputModeControl.ParentDevice =
                this.IntegratorControl.ParentDevice =
                this.LiveReadingsControl.ParentDevice = _ParentDevice;
            }
        }

        public MainWindow(Device d) {
            InitializeComponent();
            ParentDevice = d;
        }

        private static void VoltageRangeMenuItem_Click(object sender, object e) {
            if (sender is not MenuItem m) { return; }
            Trace.WriteLine("Clicked " + m.Header);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.Loaded += (s, e) => {
                MenuItem voltageRangeMenu = new();
                voltageRangeMenu.Header = "Voltage Range";
                foreach (var r in VOLTage.VoltageRangesList) {
                    MenuItem m = new();
                    m.IsCheckable = true;
                    m.Header = r;
                    m.Click += VoltageRangeMenuItem_Click;
                    voltageRangeMenu.Items.Add(m);
                }

                MenuItem gpmMenuItem = new();
                gpmMenuItem.Header = "_GPM8310";
                gpmMenuItem.Icon = "Resources/gpm-8310-128.png";
                Menu gpmMenu = new();
                gpmMenu.Items.Add(gpmMenuItem);
                gpmMenu.Items.Add(voltageRangeMenu);

                StatusBarVoltageRangeStatusBarItem.Content = gpmMenu;
            };

            this.Activated += (s, e) => {
                if (this.ParentDevice.IsLocal) {
                    var f = new GpmDevicePropertiesWindow(Device.DefaultLocal);
                    var result = f.ShowDialog();
                    if (result == true) {
                        var model = new Device(f.DeviceIpAddress, f.DeviceName);
                        this.ParentDevice = model;
                        SettingsManager.Singleton.UpdateFavouriteDeviceListStoreWith(model);
                    } else { 
                        this.Close();
                        return; 
                    }
                }
            };
        }

       

    }
}
