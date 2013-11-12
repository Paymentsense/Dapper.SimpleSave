using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum LoginResultEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Sucess")][EnumMember]Success = 1,
       [Description("Failed")][EnumMember]Failed = 2,
       [Description("Password failed")][EnumMember]FailedPassword = 3,
       [Description("Password locked")][EnumMember]FailedPasswordRetryLock = 4,
       [Description("Administrative lock")][EnumMember]FailedAdministrativeLock = 5,
       [Description("Remote access denied")][EnumMember]FailedRemoteAccessDenied = 6,
       [Description("Remote access validation prompt")][EnumMember]RemoteAccessValidationPrompt = 7,
       [Description("Account un locked")][EnumMember]AccountUnLocked = 8,
       [Description("User can impersonate")][EnumMember]UserImpersonated = 9,
       [Description("User password changed")][EnumMember]PasswordChanged = 10,
       [Description("User name already exists")][EnumMember]DuplicateUserName = 11,
       [Description("Password has been reset")][EnumMember]PasswordReset = 12,
        
    }    
}
