using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    [Flags]
    [DataContract]
    public enum UserStatusOptionsFlagLutEnum : long
    {
       [Description("Manage email")][EnumMember]ManageEmail = 1,
       [Description("Allow remote access")][EnumMember]AllowRemoteAccess = 2,
       [Description("Provisionign watch list")][EnumMember]ProvisioningWatchList = 4,
       [Description("")][EnumMember]RevolutionUser = 8,
       [Description("")][EnumMember]IsSelfTA = 16,
       [Description("")][EnumMember]CanImpersonate = 32,
        
    }    
}
