using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Body", Namespace = "http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader")]
    public class ResponseCompanyDetailsV21Body
    {
        public ResponseCompanyDetailsV21Body() { }

        [DataMember(Name = "CompanyDetails", IsRequired = true, Order = 1)]
        public ResponseCompanyDetailsV21Dto CompanyDetails { get; set; }
    }
}
