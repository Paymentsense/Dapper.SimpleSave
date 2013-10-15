using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    
    [DataContract]
    public enum LoginUserResultLutEnum : int
    {
       [Description("Success")][EnumMember]Success = 1,
       [Description("Failed")][EnumMember]Failed = 2,
       [Description("Password failed")][EnumMember]FailedPassword = 3,
       [Description("Password locked")][EnumMember]FailedPasswordRetryLock = 4,
       [Description("Administrative lock")][EnumMember]FailedAdministrativeLock = 5,
       [Description("Remote access denied")][EnumMember]FailedRemoteAccessDenied = 6,
       [Description("Remote access validation prompt")][EnumMember]RemoteAccessValidationPrompt = 7,
       [Description("Account un locked")][EnumMember]AccountUnLocked = 8,
       [Description("User can impersonate")][EnumMember]UserImpersonated = 9,
       [Description("User password changed")][EnumMember]PasswordChanged = 10,
        
    }    
}
