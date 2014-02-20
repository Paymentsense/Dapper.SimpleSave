using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "CompanyAppointments", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseCompanyAppointmentsDto
    {
        public ResponseCompanyAppointmentsDto() { }

        [DataMember(Name = "CompanyName", IsRequired = true, Order = 1)]
        public string CompanyName { get; set; }

        [DataMember(Name = "CompanyNumber", IsRequired = true, Order = 2)]
        public string CompanyNumber { get; set; }

        [DataMember(Name = "HasInconsistencies", IsRequired = false, Order = 3)]
        public bool HasInconsistencies { get; set; }

        [DataMember(Name = "NumCurrentAppt", IsRequired = true, Order = 4)]
        public string NumCurrentAppt { get; set; }

        [DataMember(Name = "NumResignedAppt", IsRequired = true, Order = 5)]
        public string NumResignedAppt { get; set; }

        [DataMember(Name = "SearchRows", IsRequired = true, Order = 6)]
        public string SearchRows { get; set; }

        [DataMember(Name = "ContinuationKey", IsRequired = false, Order = 7)]
        public string ContinuationKey { get; set; }

        [DataMember(Name = "CoAppts", IsRequired = false, Order = 8)]
        public ResponseCoApptsListDto CoAppts { get; set; }
    }

}
