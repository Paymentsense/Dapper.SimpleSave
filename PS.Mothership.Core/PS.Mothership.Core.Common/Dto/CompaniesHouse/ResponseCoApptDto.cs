using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "CoAppt", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0/schema")]
    public class ResponseCoApptDto
    {
        public ResponseCoApptDto() { }

        [DataMember(Name = "Person", IsRequired = true, Order = 1)]
        public ResponsePersonDto Person { get; set; }

        [DataMember(Name = "NumAppointments", IsRequired = true, Order = 2)]
        public string NumAppointments { get; set; }

        [DataMember(Name = "AppointmentType", IsRequired = true, Order = 3)]
        public string AppointmentType { get; set; }

        [DataMember(Name = "AppointmentStatus", IsRequired = true, Order = 4)]
        public string AppointmentStatus { get; set; }

        [DataMember(Name = "AppointmentDate", IsRequired = true, Order = 5)]
        public string AppointmentDate { get; set; }

        [DataMember(Name = "Occupation", IsRequired = false, Order = 6)]
        public string Occupation { get; set; }
    }
}
