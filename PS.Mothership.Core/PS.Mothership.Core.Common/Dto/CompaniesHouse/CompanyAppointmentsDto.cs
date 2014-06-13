using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string HasInconsistencies { get; set; }
        public decimal NumCurrentAppt { get; set; }
        public decimal NumResignedAppt { get; set; }
        public decimal SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public IList<CoApptDto> CoAppt { get; set; }
    }
}
