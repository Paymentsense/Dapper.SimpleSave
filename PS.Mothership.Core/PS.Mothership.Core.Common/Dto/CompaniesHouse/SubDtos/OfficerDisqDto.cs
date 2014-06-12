using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerDisqDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public string DisqReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ExceptionDto Exemption { get; set; }
        public string ContinuationKey { get; set; }
    }
}
