using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class FilingHistoryDto
    {
        public int CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public int SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public FhistItemDto FhistItem { get; set; }
    }
}
