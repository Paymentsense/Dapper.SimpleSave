using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class AgreementInfoDto
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<DocSecurityOptionEnum> SecurityOptions { get; set; }
        [DataMember]
        public DateTime Expiration { get; set; }
        [DataMember]
        public AgreementStatusEnum Status { get; set; }
        [DataMember]
        public List<DocumentHistoryEventDto> Events { get; set; }
        [DataMember]
        public string Locale { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<NextParticipantInfosDto> NextParticipantsInfo { get; set; }
        [DataMember]
        public string AgreementId { get; set; }
        [DataMember]
        public List<ParticipantInfoDto> Participants { get; set; }
        [DataMember]
        public string LatestVersionId { get; set; }
    }
}
