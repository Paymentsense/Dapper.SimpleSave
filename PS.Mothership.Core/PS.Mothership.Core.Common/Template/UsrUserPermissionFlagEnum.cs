using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Usr
{
    [Flags]
    [DataContract]
    public enum UserPermissionFlagEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Add Resources")][EnumMember]Add = 1,
       [Description("Read Resources")][EnumMember]Read = 2,
       [Description("Delete Resources")][EnumMember]Delete = 4,
        
    }    
}
