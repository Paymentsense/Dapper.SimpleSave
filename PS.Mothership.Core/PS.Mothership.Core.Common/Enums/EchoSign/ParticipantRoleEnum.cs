using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum ParticipantRoleEnum
    {
        [EnumMember]
        SENDER,
        [EnumMember]
        SHARE,
        [EnumMember]
        OTHER,
        [EnumMember]
        CC,
        [EnumMember]
        SIGNER,
        [EnumMember]
        APPROVER,
        [EnumMember]
        DELEGATE
    }
}
