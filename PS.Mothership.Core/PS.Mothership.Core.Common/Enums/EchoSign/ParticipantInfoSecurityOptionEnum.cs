using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum ParticipantInfoSecurityOptionEnum
    {
        [EnumMember]
        OTHER,
        [EnumMember]
        KBA,
        [EnumMember]
        WEB_IDENTITY,
        [EnumMember]
        PASSWORD
    }
}
