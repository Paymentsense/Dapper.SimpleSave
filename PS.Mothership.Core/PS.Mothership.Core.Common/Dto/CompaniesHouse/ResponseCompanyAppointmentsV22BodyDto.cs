using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "Body", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseCompanyAppointmentsV22BodyDto
    {
        public ResponseCompanyAppointmentsV22BodyDto() { }

        [DataMember(Name = "CompanyAppointments", IsRequired = true, Order = 1)]
        public ResponseCompanyAppointmentsDto CompanyAppointments { get; set; }
    }

}
