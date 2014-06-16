using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerDetailsDto
    {
        public PersonDto Person { get; set; }
        public ApptCountDto ApptCount { get; set; } 
        public string NumDisqualOrders { get; set; }
        public OfficerApptDto OfficerAppt { get; set; }
        public OfficerDisqDto OfficerDisq { get; set; }
    }
}
