using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "PreviousNames", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponsePreviousNamesDto
    {
        public ResponsePreviousNamesDto() { }

        [DataMember(Name = "CONDate", IsRequired = true, Order = 1)]
        public string CONDate { get; set; }

        [DataMember(Name = "CompanyName", IsRequired = true, Order = 2)]
        public string CompanyName { get; set; }
    }
}
