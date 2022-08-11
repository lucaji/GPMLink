using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Configuration;
using System.ComponentModel;
using GPMLib;


#nullable enable

namespace GPMLink {
    public partial class WinformsManager {


        #region Singleton Definition

        private static readonly Lazy<WinformsManager> lazy = new(() => new WinformsManager());
        public static WinformsManager Singleton { get { return lazy.Value; } }
        private WinformsManager() { 
            if (!ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).HasFile) {
                Properties.Settings.Default.Upgrade();
            }

            SettingsManager.Singleton.SaveFavouriteDevicesList = SaveFavourites;
            SettingsManager.Singleton.SaveTargetValueList = SaveTargetValues;

            _ = SettingsManager.Singleton.ParseFavouriteDeviceList(Properties.Settings.Default.KnownDevices);
            _ = SettingsManager.Singleton.ReloadTargetPercentagesList(Properties.Settings.Default.TargetValues);
        }

      

        void SaveFavourites(string s) {
            Properties.Settings.Default.KnownDevices = s;
            Properties.Settings.Default.Save();
        }

        void SaveTargetValues(string s) {
            Properties.Settings.Default.TargetValues = s;
            Properties.Settings.Default.Save();
        }

        #endregion



        List<Gpm8310Form> ActiveForms = new();

        Gpm8310Form FormForDevice(GPMDevice d) {
            var f = ActiveForms.FirstOrDefault(f => f.ParentDevice.Equals(d));
            if (f is null) {
                f = new(d);
                ActiveForms.Add(f);
            }
            return f;
        }

        public Form StartupForm() {
            if (SettingsManager.Singleton.FavouriteDevicesList.Count > 0) {
                var lastDevice = SettingsManager.Singleton.FavouriteDevicesList.FirstOrDefault(d => d.IsDefault);
                if (lastDevice is not null) {
                    return FormForDevice(lastDevice);
                }
            } else if (SettingsManager.Singleton.FavouriteDevicesList.Count == 1) {
                var lastDevice = SettingsManager.Singleton.FavouriteDevicesList.First();
                return FormForDevice(lastDevice);
            }
            return FormForDevice(GPMDevice.DefaultLocal);
        }


        ExportProgressForm? _pf;

        public bool ReportAsExcel(GPMDevice pd, List<DataSample>data) {
            if (_pf is null || _pf.IsDisposed) {
                _pf = new ExportProgressForm();
            }
            _pf.ShowFileDialogAndExport(pd, data);
            return _pf.DialogResult == DialogResult.OK;
        }


        

    
    }
}
