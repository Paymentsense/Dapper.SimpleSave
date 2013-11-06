using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum ResourceEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Modules")][EnumMember]Module = 1,
       [Description("Pages")][EnumMember]Page = 2,
        
    }    
}
