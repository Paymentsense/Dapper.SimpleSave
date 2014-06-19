using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerDetailsDto
    {
        public PersonDto Person {get; set;}

        public OfficerDetailsApptCount ApptCount { get; set; }

        public string NumDisqualOrders {get; set;}

        public string ContinuationKey {get; set;}
        
        public List<OfficerApptDto> OfficerAppt { get; set; }
        
        public List<OfficerDisqDto> OfficerDisq { get; set; }
    }
}
