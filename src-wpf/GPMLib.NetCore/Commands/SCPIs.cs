using System.Collections.Generic;

namespace GPMLib.Netcore {
    public class SCPIs {


        public enum ErrorCodesEnum {
            CommunicationError = -120,
            NoError = 0,
            InvalidSeparator = 103,
            DataTypeError = 104,
            ParameterNotAllowed = 108,
            MissingParameter = 109,
            UndefinedHeader = 113,
            InvalidSuffix = 131,
            InvalidCharacterData = 141,
            SettingConflict = 221,
            DataOutOfRange = 222,
            InvalidOperation = 813
        }

        static readonly List<(ErrorCodesEnum, string)> ErrorCodes = new() {
            (ErrorCodesEnum.NoError, "No Error"),
            (ErrorCodesEnum.InvalidSeparator, "Invalid Separator"),
            (ErrorCodesEnum.DataTypeError, "Data Type Error"),
            (ErrorCodesEnum.ParameterNotAllowed, "Parameter Not Allowed"),
            (ErrorCodesEnum.MissingParameter, "Missing Parameter"),
            (ErrorCodesEnum.UndefinedHeader, "Undefined Header"),
            (ErrorCodesEnum.InvalidSuffix, "Invalid Suffix"),
            (ErrorCodesEnum.InvalidCharacterData, "Invalid Character Data"),
            (ErrorCodesEnum.SettingConflict, "Setting Conflict"),
            (ErrorCodesEnum.DataOutOfRange, "Data Out Of Range"),
            (ErrorCodesEnum.InvalidOperation, "Invalid Operation"),
        };

        public SCPIs(GPMDevice pd, IScpiCommand settings) {
        }

        public ErrorCodesEnum GetLastError() {
            //await this.SendCommandToDevice( ":STATus:ERRor");
            //var s = await this.ReadFromDevice();
            //Debug.WriteLine(s);
            //var success = Enum.TryParse(s, out ErrorCodesEnum errorCode);
            //if (!success) { return ErrorCodesEnum.CommunicationError; }
            //return errorCode;
            return ErrorCodesEnum.CommunicationError;
        }


    }
}
