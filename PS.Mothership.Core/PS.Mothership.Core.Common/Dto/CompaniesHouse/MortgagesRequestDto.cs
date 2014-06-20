using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class MortgagesRequestDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string UserReference { get; set; }
        public bool? SatisfiedChargesInd { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContinuationKey { get; set; }
    }
}
