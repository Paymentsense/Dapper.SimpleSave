using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
