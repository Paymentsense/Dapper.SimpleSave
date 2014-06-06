using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UsrLoginResultEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Success")][EnumMember]Success = 1,
       [Description("Failed")][EnumMember]Failed = 2,
       [Description("Password failed")][EnumMember]FailedPassword = 3,
       [Description("Password locked")][EnumMember]FailedPasswordRetryLock = 4,
       [Description("Administrative lock")][EnumMember]FailedAdministrativeLock = 5,
       [Description("Remote access denied")][EnumMember]FailedRemoteAccessDenied = 6,
       [Description("Remote access validation prompt")][EnumMember]RemoteAccessValidationPrompt = 7,
       [Description("Account unlocked")][EnumMember]AccountUnLocked = 8,
       [Description("User is impersonated")][EnumMember]UserImpersonated = 9,
       [Description("User password changed")][EnumMember]PasswordChanged = 10,
       [Description("Password has been reset")][EnumMember]PasswordReset = 11,
        
    }    
    
    public class UsrLoginResult
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long LoginResultKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrLoginResultCollection
    {
        private static List<UsrLoginResult> _list; 
        public static List<UsrLoginResult> UsrLoginResultList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrLoginResult>
                        {
                            new UsrLoginResult
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								LoginResultKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 1,
								EnumName = "Success",
								EnumDescription = "Success",
								LoginResultKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 2,
								EnumName = "Failed",
								EnumDescription = "Failed",
								LoginResultKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 3,
								EnumName = "FailedPassword",
								EnumDescription = "Password failed",
								LoginResultKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 4,
								EnumName = "FailedPasswordRetryLock",
								EnumDescription = "Password locked",
								LoginResultKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 5,
								EnumName = "FailedAdministrativeLock",
								EnumDescription = "Administrative lock",
								LoginResultKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 6,
								EnumName = "FailedRemoteAccessDenied",
								EnumDescription = "Remote access denied",
								LoginResultKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 7,
								EnumName = "RemoteAccessValidationPrompt",
								EnumDescription = "Remote access validation prompt",
								LoginResultKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 8,
								EnumName = "AccountUnLocked",
								EnumDescription = "Account unlocked",
								LoginResultKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 9,
								EnumName = "UserImpersonated",
								EnumDescription = "User is impersonated",
								LoginResultKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 10,
								EnumName = "PasswordChanged",
								EnumDescription = "User password changed",
								LoginResultKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrLoginResult
							{
								EnumValue = 11,
								EnumName = "PasswordReset",
								EnumDescription = "Password has been reset",
								LoginResultKey = 11,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
