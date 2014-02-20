using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "IDAuthentication", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseIDAuthenticationDto
    {
        public ResponseIDAuthenticationDto() { }

        [DataMember(Name = "SenderID", IsRequired = true, Order = 1)]
        public string SenderID { get; set; }

        [DataMember(Name = "Authentication", IsRequired = true, Order = 2)]
        public ResponseAuthenticationDto Authentication { get; set; }

    }

}
