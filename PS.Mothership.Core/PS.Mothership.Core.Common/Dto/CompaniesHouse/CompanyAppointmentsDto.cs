using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public bool? HasInconsistencies { get; set; }
        public int NumCurrentAppt { get; set; }
        public int NumResignedAppt { get; set; }
        public int SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public IList<CoApptDto> CoAppt { get; set; }
    }
}
