namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerSearchRequestDto
    {
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Town { get; set; }
        public string OfficerType { get; set; }
        public string IncludeResignedInd { get; set; }
        public string ContinuationKey { get; set; }
    }
}
