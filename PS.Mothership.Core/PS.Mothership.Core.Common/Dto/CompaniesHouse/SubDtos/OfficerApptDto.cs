using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerApptDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyStatus { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public ApptDatePrefix ApptDatePrefix { get; set; }
        public bool ApptDatePrefixSpecified { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public string Occupation { get; set; }
    }
}
