using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum RecStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Active")][EnumMember]Active = 1,
       [Description("")][EnumMember]InActive = 2,
       [Description("")][EnumMember]Deleted = 3,
        
    }    
}
