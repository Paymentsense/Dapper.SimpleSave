using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Enums
{
    [DataContract]
    public enum LogCallType
    {
        [EnumMember] Unknown = 0,
        [EnumMember] Outbound = 1,
        [EnumMember] InboundMissed = 2,
        [EnumMember] InboundAnswered = 3
    }
}
