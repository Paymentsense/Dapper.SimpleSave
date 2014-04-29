using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class AgreementCreationDto
    {
        [DataMember]
        public string AgreementId { get; set; }

        [DataMember]
        public DateTime Expiration { get; set; }

        [DataMember]
        public string EmbeddedCode { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}
