using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerDisqDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string DisqReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<ExemptionDto> Exemption { get; set; }
    }
}
