using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum LogoutReasonEnum : long
    {
       [Description("Standard Logout")][EnumMember]StandardLogout = 0,
       [Description("Connection Faulted")][EnumMember]ConnectionFaulted = 1,
       [Description("Logged In Elsewhere")][EnumMember]LoggedInElsewhere = 2,
       [Description("Remote Logout")][EnumMember]RemoteLogout = 3,
       [Description("Phone Synchronisation Lost")][EnumMember]PhoneSyncLost = 4,
       [Description("User Not Configured")][EnumMember]UserNotConfigured = 5,
        
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
								EnumName = "StandardLogout",
								EnumDescription = "Standard Logout",
								LogoutReasonKey=0
							},
							new LogoutReason
							{
								EnumValue = 1,
								EnumName = "ConnectionFaulted",
								EnumDescription = "Connection Faulted",
								LogoutReasonKey=1
							},
							new LogoutReason
							{
								EnumValue = 2,
								EnumName = "LoggedInElsewhere",
								EnumDescription = "Logged In Elsewhere",
								LogoutReasonKey=2
							},
							new LogoutReason
							{
								EnumValue = 3,
								EnumName = "RemoteLogout",
								EnumDescription = "Remote Logout",
								LogoutReasonKey=3
							},
							new LogoutReason
							{
								EnumValue = 4,
								EnumName = "PhoneSyncLost",
								EnumDescription = "Phone Synchronisation Lost",
								LogoutReasonKey=4
							},
							new LogoutReason
							{
								EnumValue = 5,
								EnumName = "UserNotConfigured",
								EnumDescription = "User Not Configured",
								LogoutReasonKey=5
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
