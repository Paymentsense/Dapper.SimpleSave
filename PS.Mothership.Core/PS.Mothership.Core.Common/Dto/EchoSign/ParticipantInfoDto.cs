using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class ParticipantInfoDto
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public List<ParticipantInfoSecurityOptionEnum> SecurityOptions { get; set; }
        [DataMember]
        public AgreementStatusEnum Status { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public List<ParticipantRoleEnum> Roles { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<ParticipantInfoDto> AlternateParticipants { get; set; }
    }
}
