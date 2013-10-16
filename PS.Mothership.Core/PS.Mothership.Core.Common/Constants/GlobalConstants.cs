using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Constants
{
    public class GlobalConstants
    {
        public const string ApplicationName = "PS.WEB.UI";
        public const string TaskNotificationID = "TaskNotificationID";
        public const string UserName = "UserName";

        // Ip Matching constants
        public const char Dot = '.';
        public const char Star = '*';
        public const int IPAddressPadding = 3;
        public const int InitalMatch = 2;
        public const int ExactMatchScore = 5;
        public const int WildCardMatchScore = 1;
        //postcodeanywhere constants
        public const string PostCodeAnywhereRetrieveUrl = "PostCodeAnywhereRetrieveUrl";
        public const string PostCodeAnywhereAccountCode = "PostCodeAnywhereAccountCode";
        public const string PostCodeAnywhereLicenseKey = "PostCodeAnywhereLicenseKey";
        public const string PostCodeAnywhereBindingName = "PostcodeAnywhere_Soap";
    }
}
