using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT.Common
{
    public class Constants
    {

        public const int PIN_MINIMUM_FOR_CREATE_ACCOUNT = 5;
        public const string PIN_TRANSACTION_TYPE_INITIAL = "INITIAL ACCOUNT";
        public const string PIN_TRANSACTION_TYPE_PH = "PH";
        public const string PIN_TRANSACTION_TYPE_GH = "GH";
        public const string PIN_TRANSACTION_TYPE_SOLD = "SOLD";

        public const string KeyEncriptPass = "MHS@2013";
        public const string ParttentPass = "Password=\\s*(.*?)\\s*;";
        public const string KeyEncriptRef = "MSA@2013";

        public enum MEMBER_STATUS
        {
            WaitActive = 0,
            Actived = 1,
            Running = 2,
            Blocked = 3
        }

        public const string MEMBERS_LEVEL_V1 = "V1";
        public const string MEMBERS_LEVEL_V2 = "V2";
        public const string MEMBERS_LEVEL_V3 = "V3";
        public const string MEMBERS_LEVEL_V4 = "V4";
        public const string MEMBERS_LEVEL_V5 = "V5";

        public enum PH_STATUS
        {
            Waiting = 0,
            Pending = 1,
            Success = 2,
            Expired = 3
        }

        public enum GH_STATUS
        {
            Waiting = 0,
            Pending = 1,
            Success = 2,
            Expired = 3
        }

        public enum COMMAND_STATUS
        {
            Pending = 0,
            PH_Success = 1,
            Success = 2,
            Expired = 3,
            ProcessPhExpired = 4,
            ProcessGhExpired = 5
        }
    }
}
