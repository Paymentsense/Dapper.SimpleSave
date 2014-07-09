using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class FilingHistoryDto
    {
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public List<FhistItemDto> FHistItem { get; set; }
    }
}
