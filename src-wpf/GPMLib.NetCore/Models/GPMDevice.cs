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

/*
 * *
 * 
 * GW-Instek GPM-8310 C# .NET Class
 * Digital Power Meter
 * Logging Tool
 * 
 * Written by Luca Cipressi (lucaji.github.io)
 * 
 * v. 0.1 - June 2021 - first release with crappy telnet
 * v. 0.2 - Juli 2021 - adding CSV and timers
 * v. 0.3 - Juli 2021 - restructuring and adding command models
 * v. 0.4 - August 2021 - rolling back command classes
 * v. 0.5 - October 2021 - telnet client implementation still is crappy
 * v. 1.0 - November 2021 - misc fixes
 * v. 2.0 - December 2021 - rewritten telnet uart component
 * v. 2.1 - January 2022 - cleaning up
 * 
 * *
 */


using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.Serialization;
using System.Diagnostics;
using static GPMLib.Netcore.INTEGrator;

#nullable enable

namespace GPMLib.Netcore {

    [DataContract]

    public class GPMDevice : IEquatable<GPMDevice?> {

        public static readonly char CultureDecimalSeparatorCharacter;


        static GPMDevice() {
            CultureDecimalSeparatorCharacter = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        }

       
        public static readonly bool DebugErrs = true;
        public static readonly bool DebugLogs = true;


        


        public static void LogError(string e) {
            if (DebugErrs) {
                Trace.WriteLine("GPM " + e);
            }
        }

        public static void LogToConsole(string t) {
            if (DebugLogs) {
                Trace.WriteLine("GPM " + t);
            }
        }

        #region Serializable Properties


        private static readonly string localIp = "127.0.0.1";
        private static readonly string localName = "Local";

        public static GPMDevice DefaultLocal {
            get {
                return new GPMDevice(localIp, localName);
            }
        }
        public static GPMDevice? Factory(string a, string n) {
            if (string.IsNullOrWhiteSpace(a)) { a = localIp; }
            if (string.IsNullOrWhiteSpace(n)) { n = localName; }
            if (n.Length < 1 || n.Length > 30) { return null; }
            if (ConnectionManager.IPAddressInvalid(a)) { return null; }
            return new GPMDevice(a, n);
        }


        [DataMember]
        public string? DeviceID { get; set; }

       

        [DataMember]
        public bool IsDefault { get; set; }


        [DataMember]
        public string DeviceInputModeString { get; set; } = "DC";
        [DataMember]
        public string DeviceCrestFactorModeString { get; set; } = "CF3";
        [DataMember]
        public string DeviceVoltageRangeString { get; set; } = "Auto";
        [DataMember]
        public string DeviceCurrentRangeString { get; set; } = "Auto";
        #endregion

        public GPMDevice(string a, string n) {
            
            DeviceIPAddress = a;
            DeviceName = n;
            NetworkLink = new(this);
            DeviceInputs = new(this);
            DeviceCommunicationSettings = new(this);
            TheStats = new(this);
        }





        public bool IsLocal { get { return _Address.Equals(localIp); } }


        protected string _Address = localIp;
        [DataMember]
        public string DeviceIPAddress {
            get { return _Address; }
            set {
                if (ConnectionManager.IPAddressInvalid(value)) { return; }
                _Address = value;
            }
        }

        protected string _Name = localName;
        [DataMember]
        public string DeviceName {
            get { return _Name; }
            set {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                if (value.Length < 2 || value.Length > 32) { return; }
                _Name = value;
            }
        }

        




        

        /// <summary>
        /// The GPM8310 wont respond to some commands if the Integrator is running, which make sense:
        /// ranges, crest factor and mode cannot be changed when integrating so inputs are not configurable afterwards.
        /// </summary>
        public bool IsIntegrating {
            get {
                var shallLock = this.TheStats.IntegratorCommand.IntegratorStatus == GPMIntegratorStatusEnum.Start;// ||
                //this.IntegratorCommand.IntegratorStatus == GPMIntegratorStatusEnum.Unknown ||
                //this.IntegratorCommand.IntegratorStatus == GPMIntegratorStatusEnum.Error;
                return shallLock;
            }
        }

        public bool IsConnected {
            get {
                return this.NetworkLink.IsConnected;
            }
        }

        public string IsConnectedString { get { return this.IsConnected ? "Disconnect" : "Offline"; } }

        public bool IsDisconnected {
            get {
                return !this.NetworkLink.IsConnected;
            }
        }

        public async Task<bool> GetDeviceState() {
            var success = await this.DeviceInputs.GetInput().ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError("error getting device state Input mode");
                return false;
            }
            _ = await this.TheStats.IntegratorCommand.GetIntegratorStatus().ConfigureAwait(false);
            return true;
        }


        public string DeviceStatusString {
            get {
                return this.IsConnected ? "Online" : "Offline";
            }
        }

        public async Task<bool> InitializeDevice() {
            GPMDevice.LogToConsole("Initializing Device Parameters...");
            // Set Header ON (returns query response with headers [the originating cmd])
            var success = await this.DeviceCommunicationSettings.SetCommHeader(true).ConfigureAwait(false);
            if (!success) {
                return false;
            }

            // Set Verbose Mode OFF (not yet supported otherwise)
            success = await this.DeviceCommunicationSettings.SetCommVerbose(false).ConfigureAwait(false);
            if (!success) {
                return false; 
            }

            // Set to get U, I, P in the readings vector
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM1 U").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError("INIT :NUM:NORM:ITEM1 U failed for " + DeviceIPAddress);
                return false;
            }
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM2 I");
            if (!success) {
                GPMDevice.LogError("INIT :NUM:NORM:ITEM2 I failed for " + DeviceIPAddress);
                return false; 
            }

            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM3 P").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError("INIT :NUM:NORM:ITEM3 P failed for " + DeviceIPAddress);
                return false;
            }


            // add integrated values
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM4 TIME").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError(":NUM:NORM:ITEM4 TIME failed for " + DeviceIPAddress);
            }
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM5 WH").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError(":NUM:NORM:ITEM5 WH failed for " + DeviceIPAddress);
            }
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:ITEM6 AH").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError(":NUM:NORM:ITEM6 AH failed for " + DeviceIPAddress);
            }

            // set the output number of values to all the 6 above
            success = await this.NetworkLink.SendToDevice(":NUM:NORM:NUM 6").ConfigureAwait(false);
            if (!success) {
                GPMDevice.LogError(":NUM:NORM:NUM 6 failed for " + DeviceIPAddress);
            }

            NUMeric.NumberOfValues = 6;
            return success;
        }

     

        #region Device Command Handlers

        public ConnectionManager NetworkLink { get; }

        public DataReadings TheStats { get; }

        public COMMunicate DeviceCommunicationSettings { get; }

        public INPut DeviceInputs { get; private set; }


        #endregion






        public override string ToString() {
            return this.DeviceName + " @ " + this.DeviceIPAddress;
        }

        #region Equality overrides

        public override bool Equals(object? obj) {
            return Equals(obj as GPMDevice);
        }

        public bool Equals(GPMDevice? other) {
            return other != null &&
                   DeviceName == other.DeviceName &&
                   DeviceIPAddress == other.DeviceIPAddress;
        }

        public override int GetHashCode() {
            return -1984154133 + EqualityComparer<string>.Default.GetHashCode(DeviceIPAddress);
        }


        #endregion
    }
}
