using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum DocSecurityOptionEnum
    {
        [EnumMember]
        OTHER,
        [EnumMember]
        OPEN_PROTECTED
    }
}
