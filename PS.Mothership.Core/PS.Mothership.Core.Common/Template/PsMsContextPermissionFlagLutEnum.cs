using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Template.PsMsContext
{
    [Flags]
    [DataContract]
    public enum PermissionFlagLutEnum : long
    {
       [EnumMember]Add = 1,
       [EnumMember]Read = 2,
       [EnumMember]Delete = 4,
        
    }
}
