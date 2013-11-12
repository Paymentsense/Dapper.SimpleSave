using System;
using System.Runtime.Serialization;
using System.ComponentModel;

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
}
