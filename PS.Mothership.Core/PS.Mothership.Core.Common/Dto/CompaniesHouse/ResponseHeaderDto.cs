using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
   [DataContract(Name = "Header", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseHeaderDto
    {
        public ResponseHeaderDto() { }

        [DataMember(Name = "MessageDetails", IsRequired = true, Order = 1)]
        public ResponseMessageDetailsDto MessageDetails { get; set; }

        [DataMember(Name = "SenderDetails", IsRequired = true, Order = 2)]
        public ResponseSenderDetailsDto SenderDetails { get; set; }
    }
}
