using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    
    [DataContract]
    public enum LoginUserResultStatusLutEnum : int
    {
       [Description("The user credentials are valid")][EnumMember]ValidLogin = 1,
       [Description("The user credentials are not valid")][EnumMember]InValidLogin = 2,
       [Description("The user is in Impersonation mode")][EnumMember]Impersonated = 3,
       [Description("The user is Active")][EnumMember]Active = 4,
       [Description("The user account is locked, please contact your system administrator.")][EnumMember]PasswordLocked = 5,
       [Description("The user locked by Administrator")][EnumMember]AdministrativeLocked = 6,
       [Description("User Suspended")][EnumMember]Suspended = 7,
       [Description("User Terminated")][EnumMember]Terminated = 8,
       [Description("User Deleted")][EnumMember]Deleted = 9,
       [Description("The user name provided is invalid. Please check the value and try again.")][EnumMember]InvalidUserName = 12,
       [Description("The client ip address is not valid, please contact your system administrator")][EnumMember]InvalidIP = 13,
       [Description("The password provided is invalid. Please enter a valid password value.")][EnumMember]InvalidPassword = 14,
       [Description("Success")][EnumMember]Success = 15,
       [Description("Username already exists. Please enter a different user name.")][EnumMember]DuplicateUserName = 16,
       [Description("A username for that e-mail address already exists. Please enter a different e-mail address.")][EnumMember]DuplicateEmail = 17,
        
    }    
}
