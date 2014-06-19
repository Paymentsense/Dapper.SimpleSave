namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class FilingHistoryRequestDto
    {
        public string CompanyNumber { get; set; }
        public bool CapitalDocInd { get; set; }
        public bool CapitalDocIndSpecified { get; set; }
        public string ContinuationKey { get; set; }
    }
}
