using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Authentication", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseAuthenticationDto
    {
        public ResponseAuthenticationDto() { }

        [DataMember(Name = "Method", IsRequired = true, Order = 1)]
        public string Method { get; set; }

        [DataMember(Name = "Value", IsRequired = false, Order = 2)]
        public string Value { get; set; }
    }
}
