using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "CoSearchItem", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    [Serializable]
    public class CoSearchItemDto
    {
        public CoSearchItemDto() { }

        [DataMember(Name = "CompanyName", IsRequired = true, Order = 1)]
        public string CompanyName { get; set; }

        [DataMember(Name = "CompanyNumber", IsRequired = true, Order = 2)]
        public string CompanyNumber { get; set; }

        [DataMember(Name = "DataSet", IsRequired = true, Order = 3)]
        public string DataSet { get; set; }
        //public ServiceDataSet DataSet { get; set; }

        [DataMember(Name = "CompanyIndexStatus", IsRequired = true, Order = 4)]
        public string CompanyIndexStatus { get; set; }
        //public ServiceCompanyIndexStatus CompanyIndexStatus { get; set; }

        [DataMember(Name = "CompanyDate", IsRequired = true, Order = 5)]
        public string CompanyDate { get; set; }

        [DataMember(Name = "SearchMatch", IsRequired = false, Order = 6)]
        public string SearchMatch { get; set; }
    }
}
