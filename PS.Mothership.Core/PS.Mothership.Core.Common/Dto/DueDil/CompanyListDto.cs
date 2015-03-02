using System;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.DueDil;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class CompanyListDto : ProcessResponseDto
    {
        public IList<CompanyListResponseDto> CompanyList { get; set; }
        public int TotalCount { get; set; }
    }
}
