using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "NumberSearch", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseNumberSearchDto
    {
        public ResponseNumberSearchDto() { }

        //[DataMember(Name = "ContinuationKey", IsRequired = true, Order = 1)]
        //public string ContinuationKey { get; set; }

        //[DataMember(Name = "RegressionKey", IsRequired = true, Order = 2)]
        //public string RegressionKey { get; set; }

        [DataMember(Name = "SearchRows", IsRequired = true, Order = 1)]
        public string SearchRows { get; set; }

        [DataMember(Name = "CoSearchItems", IsRequired = false, Order = 2)]
        public CoSearchItemsListDto CoSearchItems { get; set; }
    }
}
