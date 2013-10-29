using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    
    [DataContract]
    public enum UserStatusLutEnum : long
    {
       [Description("NewUser")][EnumMember]NewUser = 1,
       [Description("The user is active")][EnumMember]Active = 2,
       [Description("Password locked")][EnumMember]PasswordRetryLocked = 3,
       [Description("Administrative locked")][EnumMember]AdministrativeLocked = 4,
       [Description("Account suspended")][EnumMember]Suspended = 5,
       [Description("Account terminated")][EnumMember]Terminated = 6,
       [Description("Account deleted")][EnumMember]Deleted = 7,
        
    }    
}
