using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum StatusOptionFlagEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Manage Email")][EnumMember]ManageEmail = 1,
       [Description("Allow remote access")][EnumMember]AllowRemoteAccess = 2,
       [Description("Provisionign watch list")][EnumMember]ProvisioningWatchList = 4,
       [Description("")][EnumMember]RevolutionUser = 8,
       [Description("")][EnumMember]IsSelfTA = 16,
       [Description("")][EnumMember]CanImpersonate = 32,
        
    }    
}
