using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    
    [DataContract]
    public enum LoginUserResultStatusLutEnum : int
    {
       [EnumMember]ValidLogin = 1,
       [EnumMember]InValidLogin = 2,
       [EnumMember]Impersonated = 3,
       [EnumMember]Active = 4,
       [EnumMember]PasswordLocked = 5,
       [EnumMember]AdministrativeLocked = 6,
       [EnumMember]Suspended = 7,
       [EnumMember]Terminated = 8,
       [EnumMember]Deleted = 9,
       [EnumMember]InvalidUserName = 12,
       [EnumMember]InvalidIP = 13,
       [EnumMember]InvalidPassword = 14,
        
    }
}
