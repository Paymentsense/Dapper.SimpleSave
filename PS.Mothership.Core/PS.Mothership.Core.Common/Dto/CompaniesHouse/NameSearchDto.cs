using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NameSearchDto
    {
        public string ContinuationKey { get; set; }
        public string RegressionKey { get; set; }
        public string SearchRows { get; set; }
        public IList<CoSearchItemDto> CoSearchItem { get; set; }
    }
}
