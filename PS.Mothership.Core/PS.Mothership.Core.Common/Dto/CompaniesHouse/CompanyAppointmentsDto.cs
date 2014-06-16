using System;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public string HasInconsistencies { get; set; }
        public int NumCurrentAppt { get; set; }
        public int NumResignedAppt { get; set; }
        public int SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public CoApptDto CoAppt { get; set; }
        public int NumAppointments { get; set; }
        public int NumAppInd { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string AppointmentStatus { get; set; }
        public string ApptDatePrefix { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
