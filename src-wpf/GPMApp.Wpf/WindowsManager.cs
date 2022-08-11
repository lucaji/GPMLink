/*
 * 
    Licensed under the MIT license:

    http://www.opensource.org/licenses/mit-license.php

    Copyright(c) 2013 - 2021, Luca Cipressi(lucaji.github.io) lucaji()mail.ru


    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*
*/

using Gpm8310.Models;

using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using System.Configuration;
using System.Windows;
using BauerMeterAppWPF;
using Gpm8310.Helpers;


#nullable enable

namespace BauerMeterApp.WPF.Helpers {
    public partial class WindowsManager {

        
        #region Singleton Definition

        private static readonly Lazy<WindowsManager> lazy = new(() => new WindowsManager());
        public static WindowsManager Singleton { get { return lazy.Value; } }
        private WindowsManager() { 
            if (!ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).HasFile) {
                Properties.Settings.Default.Upgrade();
            }

            SettingsManager.Singleton.SaveFavouriteDevicesList = SaveFavourites;
            SettingsManager.Singleton.SaveTargetValueList = SaveTargetValues;

            ReloadSettings();
        }

        void ReloadSettings() {
            var devices = SettingsManager.Singleton.ParseFavouriteDeviceList(Properties.Settings.Default.KnownDevices);
            if (devices.Count == 0) {

            }
            var values = SettingsManager.Singleton.ReloadTargetPercentagesList(Properties.Settings.Default.TargetValues);
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



        List<MainWindow> ActiveForms = new();

        MainWindow FormForDevice(Device d) {
            var f = ActiveForms.FirstOrDefault(f => f.ParentDevice.Equals(d));
            if (f is null) {
                f = new(d);
                ActiveForms.Add(f);
            }
            return f;
        }

        public void StartupForm() {
            if (SettingsManager.Singleton.FavouriteDevicesList.Count > 0) {
                var lastDevice = SettingsManager.Singleton.FavouriteDevicesList.FirstOrDefault(d => d.IsDefault);
                if (lastDevice is not null) {
                    FormForDevice(lastDevice).Show();
                }
            } else if (SettingsManager.Singleton.FavouriteDevicesList.Count == 1) {
                var lastDevice = SettingsManager.Singleton.FavouriteDevicesList.First();
                FormForDevice(lastDevice).Show();
            } else {
                FormForDevice(Device.DefaultLocal).Show();
            }
        }




    }
}
