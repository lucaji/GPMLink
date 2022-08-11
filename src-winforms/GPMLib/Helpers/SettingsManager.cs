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

using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using System.Configuration;


#nullable enable

namespace GPMLib {
    public partial class SettingsManager {

        public delegate void GpmSettingsStoreDeviceSerializedDelegate(string s);

        public GpmSettingsStoreDeviceSerializedDelegate? SaveFavouriteDevicesList { get; set; }

        public delegate void GpmSettingsStoreTargetValuesSerializedDelegate(string s);

        public GpmSettingsStoreTargetValuesSerializedDelegate? SaveTargetValueList { get; set; }

        #region Singleton Definition

        private static readonly Lazy<SettingsManager> lazy = new(() => new SettingsManager());
        public static SettingsManager Singleton { get { return lazy.Value; } }
        private SettingsManager() { }



        #endregion


        #region Known Device List


        private List<GPMDevice> _FavouriteDevicesList = new();
        public List<GPMDevice> FavouriteDevicesList => _FavouriteDevicesList;
             

        public List<GPMDevice> ParseFavouriteDeviceList(string s) {
            if (string.IsNullOrWhiteSpace(s)) { goto bail; }
            _FavouriteDevicesList.Clear();
            List<GPMDevice>? list = JsonConvert.DeserializeObject<List<GPMDevice>>(s);
            if (list is not null && list.Count > 0) {
                _FavouriteDevicesList.AddRange(list);
                var hasDefault = list.FirstOrDefault(o => o.IsDefault);
                if (hasDefault is null) {
                    hasDefault = list.First();
                    hasDefault.IsDefault = true;
                    SignalSaveStoreSettings();
                }
            }
            bail: return _FavouriteDevicesList;
        }

        void SignalSaveStoreSettings() {
            if (SaveFavouriteDevicesList is not null) {
                var json = JsonConvert.SerializeObject(_FavouriteDevicesList, Formatting.None);
                SaveFavouriteDevicesList(json);
            }
        }

        public void SetDeviceAsDefault(GPMDevice d) {
            foreach (var o in _FavouriteDevicesList) {
                o.IsDefault = o.Equals(d);
            }
            SignalSaveStoreSettings();
        }


        public GPMDevice? FindUserDeviceByIpAddress(string ip) {
            return _FavouriteDevicesList.FirstOrDefault(d => d.DeviceIPAddress.Equals(ip));
        }



        public bool IsKnownIpAddress(string addr, out GPMDevice? obj) {
            obj = _FavouriteDevicesList.FirstOrDefault(d => d.DeviceIPAddress.Equals(addr));
            return obj != null;
        }

        public bool IsKnownName(string addr, out GPMDevice? obj) {
            obj = _FavouriteDevicesList.FirstOrDefault(d => d.DeviceName.Equals(addr));
            return obj != null;
        }

        public bool UpdateFavouriteDeviceListStoreWith(GPMDevice dm) {
            return UpdateFavouriteDeviceListStoreWith(dm.DeviceIPAddress, dm.DeviceName);
        }


        public bool UpdateFavouriteDeviceListStoreWith(string addr, string name) {
            if (IsKnownIpAddress(addr, out GPMDevice? d)) {
                if (d!.DeviceName != name) {
                    d.DeviceName = name;
                }
            } else {
                var device = GPMDevice.Factory(addr, name);
                if (device is null) { return false; }
                FavouriteDevicesList.Add(device);
            }
            SignalSaveStoreSettings();
            return true;
        }

        public void RemoveFavouriteDeviceFromStore(string addr) {
            if (IsKnownIpAddress(addr, out GPMDevice? d)) {
                RemoveFavouriteDeviceFromStore(d);
            }
        }

        public void RemoveFavouriteDeviceFromStore(GPMDevice? d) {
            if (d is null) { return; }
            if (FavouriteDevicesList.Remove(d)) {
                SignalSaveStoreSettings();
            }
        }

        #endregion




        #region Target Value Settings

        private List<PowerTargetValueViewModel> _TargetPercentagesList = new();
        public List<PowerTargetValueViewModel> TargetPercentagesList {
            get {
                if (_TargetPercentagesList.Count == 0) { StoreTargetPercentagesListIntoUserPreferenceString(); }
                return _TargetPercentagesList;
            }
        }

        public List<PowerTargetValueViewModel> ReloadTargetPercentagesList(string s) {
            _TargetPercentagesList.Clear();

            if (string.IsNullOrWhiteSpace(s)) { goto defaultTargetVals; }

            List<PowerTargetValueViewModel>? list = JsonConvert.DeserializeObject<List<PowerTargetValueViewModel>>(s);
            if ((list?.Count ?? 0) > 0) {
                _TargetPercentagesList.AddRange(list);
                goto bail;
            } 

        defaultTargetVals:
            _TargetPercentagesList.AddRange(PowerTargetValueViewModel.Defaults);
            StoreTargetPercentagesListIntoUserPreferenceString();
        bail: 
            return _TargetPercentagesList;
        }

        void StoreTargetPercentagesListIntoUserPreferenceString() {
            if (SaveTargetValueList is not null) {
                string json = JsonConvert.SerializeObject(TargetPercentagesList, Formatting.None);
                SaveTargetValueList(json);
            }
        }

        public PowerTargetValueViewModel? PowerTargetValueByPercentage(double p) {
            return _TargetPercentagesList.FirstOrDefault(x => x.Percentage == p);
        }

        public bool UpdateTargetPercentagesListStoreWith(double val) {
            var found = PowerTargetValueByPercentage(val);
            if (found is not null) { return false; }
            found = PowerTargetValueViewModel.Factory(val);
            if (found is null) { return false; }
            _TargetPercentagesList.Add(found);
            _TargetPercentagesList.Sort();
            StoreTargetPercentagesListIntoUserPreferenceString();
            return true;
        }

        public void RemoveTargetPercentageFromStore(double val) {
            var found = PowerTargetValueByPercentage(val);
            if (found is null) { return; }
            _TargetPercentagesList.Remove(found);
            StoreTargetPercentagesListIntoUserPreferenceString();
        }

        public void RemoveTargetPercentageFromStore(PowerTargetValueViewModel val) {
            if (_TargetPercentagesList.Remove(val)) {
                StoreTargetPercentagesListIntoUserPreferenceString();
            }
        }

        #endregion


    }
}
