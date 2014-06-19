using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerSearchDto
    {
        public string ContinuationKey {get; set;}
        public string SearchRows {get; set;}
        public List<OfficerSearchItemDto> OfficerSearchItem { get; set; }
    }
}
