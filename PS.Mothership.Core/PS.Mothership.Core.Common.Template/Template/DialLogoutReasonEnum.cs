using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum LogoutReasonEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Standard Logout")][EnumMember]StandardLogout = 1,
       [Description("Connection Faulted")][EnumMember]ConnectionFaulted = 2,
       [Description("Logged In Elsewhere")][EnumMember]LoggedInElsewhere = 3,
       [Description("Remote Logout")][EnumMember]RemoteLogout = 4,
       [Description("Phone Synchronisation Lost")][EnumMember]PhoneSyncLost = 5,
       [Description("User Not Configured")][EnumMember]UserNotConfigured = 6,
       [Description("Failed Login")][EnumMember]FailedLogin = 7,
        
    }

    public class LogoutReason
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long LogoutReasonKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class LogoutReasonCollection
    {
        private static List<LogoutReason> _list; 
        public static List<LogoutReason> LogoutReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<LogoutReason>
                        {
                            new LogoutReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								LogoutReasonKey = 0
							},
							new LogoutReason
							{
								EnumValue = 1,
								EnumName = "StandardLogout",
								EnumDescription = "Standard Logout",
								LogoutReasonKey = 1
							},
							new LogoutReason
							{
								EnumValue = 2,
								EnumName = "ConnectionFaulted",
								EnumDescription = "Connection Faulted",
								LogoutReasonKey = 2
							},
							new LogoutReason
							{
								EnumValue = 3,
								EnumName = "LoggedInElsewhere",
								EnumDescription = "Logged In Elsewhere",
								LogoutReasonKey = 3
							},
							new LogoutReason
							{
								EnumValue = 4,
								EnumName = "RemoteLogout",
								EnumDescription = "Remote Logout",
								LogoutReasonKey = 4
							},
							new LogoutReason
							{
								EnumValue = 5,
								EnumName = "PhoneSyncLost",
								EnumDescription = "Phone Synchronisation Lost",
								LogoutReasonKey = 5
							},
							new LogoutReason
							{
								EnumValue = 6,
								EnumName = "UserNotConfigured",
								EnumDescription = "User Not Configured",
								LogoutReasonKey = 6
							},
							new LogoutReason
							{
								EnumValue = 7,
								EnumName = "FailedLogin",
								EnumDescription = "Failed Login",
								LogoutReasonKey = 7
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
