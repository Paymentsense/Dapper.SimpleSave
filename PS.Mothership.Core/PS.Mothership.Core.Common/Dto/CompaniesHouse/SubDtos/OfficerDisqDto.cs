namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerDisqDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string DisqReason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ExceptionDto Exemption { get; set; }
        public string ContinuationKey { get; set; }
    }
}
