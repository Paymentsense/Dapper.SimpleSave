namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class MortgagesRequestDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string UserReference { get; set; }
        //TODO Enum
        public string SatisfiedChargesInd { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ContinuationKey { get; set; }
    }
}
