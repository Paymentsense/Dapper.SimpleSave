using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "GovTalkDetails", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseGovTalkDetailsDto
    {
        public ResponseGovTalkDetailsDto() { }

        [DataMember(Name = "Keys", IsRequired = true, Order = 1)]
        public string Keys { get; set; }

        [DataMember(Name = "GovTalkErrors", IsRequired = false, Order = 2)]
        public ResponseGovTalkErrorsDto GovTalkErrors { get; set; }
    }
}
