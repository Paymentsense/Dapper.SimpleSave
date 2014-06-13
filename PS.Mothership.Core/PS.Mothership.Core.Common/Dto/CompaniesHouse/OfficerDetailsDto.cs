using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerDetailsDto
    {
        public PersonDto Person { get; set; }
        public ApptCountDto ApptCount { get; set; } 
        public decimal NumDisqualOrders { get; set; }
        public IList<OfficerApptDto> OfficerAppt { get; set; }
        public IList<OfficerDisqDto> OfficerDisq { get; set; }
    }
}
