namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyAppointmentsRequestDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        //TODO Enum
        public string IncludeResignedInd { get; set; }
        public string UserRefernce { get; set; }
        public string ContinuationKey { get; set; }
    }
}
