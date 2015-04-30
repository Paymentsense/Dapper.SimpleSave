using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialLogoutReasonEnum : int
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
    
    public class DialLogoutReason
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int LogoutReasonKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialLogoutReasonCollection
    {
        private static List<DialLogoutReason> _list; 
        public static List<DialLogoutReason> DialLogoutReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialLogoutReason>
                        {
                            new DialLogoutReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								LogoutReasonKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 1,
								EnumName = "StandardLogout",
								EnumDescription = "Standard Logout",
								LogoutReasonKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 2,
								EnumName = "ConnectionFaulted",
								EnumDescription = "Connection Faulted",
								LogoutReasonKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 3,
								EnumName = "LoggedInElsewhere",
								EnumDescription = "Logged In Elsewhere",
								LogoutReasonKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 4,
								EnumName = "RemoteLogout",
								EnumDescription = "Remote Logout",
								LogoutReasonKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 5,
								EnumName = "PhoneSyncLost",
								EnumDescription = "Phone Synchronisation Lost",
								LogoutReasonKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 6,
								EnumName = "UserNotConfigured",
								EnumDescription = "User Not Configured",
								LogoutReasonKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialLogoutReason
							{
								EnumValue = 7,
								EnumName = "FailedLogin",
								EnumDescription = "Failed Login",
								LogoutReasonKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
