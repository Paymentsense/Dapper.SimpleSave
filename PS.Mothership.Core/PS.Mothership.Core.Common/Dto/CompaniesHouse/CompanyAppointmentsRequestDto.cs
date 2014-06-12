using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsRequestDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public IncludeResignedInd IncludeResignedInd { get; set; }
        public string UserRefernce { get; set; }
        public string ContinuationKey { get; set; }
    }
}
