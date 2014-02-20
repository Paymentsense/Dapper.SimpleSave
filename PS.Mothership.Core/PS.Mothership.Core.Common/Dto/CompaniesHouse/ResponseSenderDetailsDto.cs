using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "SenderDetails", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseSenderDetailsDto
    {
        public ResponseSenderDetailsDto() { }

        [DataMember(Name = "IDAuthentication", IsRequired = true, Order = 1)]
        public ResponseIDAuthenticationDto IDAuthentication { get; set; }
    }

}
