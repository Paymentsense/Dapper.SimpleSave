using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "LimitedPartnerships", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseLimitedPartnershipsDto
    {
        public ResponseLimitedPartnershipsDto() { }

        [DataMember(Name = "NumGenPartners", IsRequired = true, Order = 1)]
        public string NumGenPartners { get; set; }

        [DataMember(Name = "NumLimPartners", IsRequired = true, Order = 2)]
        public string NumLimPartners { get; set; }
    }
}
