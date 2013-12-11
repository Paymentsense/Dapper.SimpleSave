using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UserStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("New Hire")][EnumMember]NewHire = 1,
       [Description("Active User")][EnumMember]Active = 2,
       [Description("Password Locked")][EnumMember]PasswordLock = 3,
       [Description("System Locked")][EnumMember]SystemLock = 4,
       [Description("Suspended")][EnumMember]Suspended = 5,
       [Description("Terminated")][EnumMember]Terminated = 6,
       [Description("Password Reset")][EnumMember]PasswordReset = 7,
        
    }

    public class UserStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long UserStatusKey {get;set;}
		public bool IsLoginEnabled {get;set;}
		public bool IsVisibleInUI {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UserStatusCollection
    {
        private static List<UserStatus> _list; 
        public static List<UserStatus> UserStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UserStatus>
                        {
                            							new UserStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								UserStatusKey=0,
								IsLoginEnabled=false,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 1,
								EnumName = "NewHire",
								EnumDescription = "New Hire",
								UserStatusKey=1,
								IsLoginEnabled=false,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 2,
								EnumName = "Active",
								EnumDescription = "Active User",
								UserStatusKey=2,
								IsLoginEnabled=true,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 3,
								EnumName = "PasswordLock",
								EnumDescription = "Password Locked",
								UserStatusKey=3,
								IsLoginEnabled=false,
								IsVisibleInUI=false
							},
							new UserStatus
							{
								EnumValue = 4,
								EnumName = "SystemLock",
								EnumDescription = "System Locked",
								UserStatusKey=4,
								IsLoginEnabled=false,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 5,
								EnumName = "Suspended",
								EnumDescription = "Suspended",
								UserStatusKey=5,
								IsLoginEnabled=false,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 6,
								EnumName = "Terminated",
								EnumDescription = "Terminated",
								UserStatusKey=6,
								IsLoginEnabled=false,
								IsVisibleInUI=true
							},
							new UserStatus
							{
								EnumValue = 7,
								EnumName = "PasswordReset",
								EnumDescription = "Password Reset",
								UserStatusKey=7,
								IsLoginEnabled=false,
								IsVisibleInUI=false
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
