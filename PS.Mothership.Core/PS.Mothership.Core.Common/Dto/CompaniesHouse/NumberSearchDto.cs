using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NumberSearchDto
    {
        public int SearchRows { get; set; }
        public IList<CoSearchItemDto> CoSearchItem { get; set; }
    }
}
