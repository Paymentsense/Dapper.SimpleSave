using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "GovTalkErrors", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseGovTalkErrorsDto
    {
        public ResponseGovTalkErrorsDto() { }

        [DataMember(Name = "Error", IsRequired = false, Order = 1)]
        public ResponseErrorDto Error { get; set; }
    }

}
