using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums
{
    [DataContract]
    public enum UserRoleType
    {
        [EnumMember]
        Anonymous,
        [EnumMember]
        Sales,
        [EnumMember]
        SalesSupport,
        [EnumMember]
        CustomerSupport,
        [EnumMember]
        SysAdmin
    }
}