using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum IpStatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Active")][EnumMember]Active = 1,
       [Description("In Active")][EnumMember]InActive = 2,
       [Description("Deleted")][EnumMember]Deleted = 3,
        
    }    
}
