using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
