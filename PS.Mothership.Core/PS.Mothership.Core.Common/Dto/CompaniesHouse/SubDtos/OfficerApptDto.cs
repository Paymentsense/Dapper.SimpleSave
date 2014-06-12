using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerApptDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public CompanyStatus CompanyStatus { get; set; }
        public string AppointmentStatus { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string AppointmentDatePrefix { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
