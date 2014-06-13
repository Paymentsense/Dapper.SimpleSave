using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class CoApptDto
    {
        public PersonAppointmentDto Person { get; set; }
        public decimal NumAppointments { get; set; }
        public string NumAppInd { get; set; }
        public string AppointmentStatus { get; set; }
        public string ApptDatePrefix { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
