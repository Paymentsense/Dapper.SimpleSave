namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsRequestDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public bool? IncludeResignedInd { get; set; }
        public string UserReference { get; set; }
        public string ContinuationKey { get; set; }
    }
}
