using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class NewAgreementDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string RecipientsEmail { get; set; }

        [DataMember]
        public string RecipientsRole { get; set; }

        [DataMember]
        public List<MergeFieldInfoDto> MergefieldInfo { get; set; }
    }
}
