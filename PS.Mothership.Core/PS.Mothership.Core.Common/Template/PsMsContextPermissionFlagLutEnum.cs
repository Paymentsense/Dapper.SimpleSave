using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    [Flags]
    [DataContract]
    public enum PermissionFlagLutEnum : long
    {
       [Description("Add Resources")][EnumMember]Add = 1,
       [Description("Read Resources")][EnumMember]Read = 2,
       [Description("Delete Resources")][EnumMember]Delete = 4,
        
    }    
}
