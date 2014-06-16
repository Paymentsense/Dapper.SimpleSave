namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NameSearchDto
    {
        public string ContinuationKey { get; set; }
        public string RegressionKey { get; set; }
        public int SearchRows { get; set; }
        public CoSearchItemDto CoSearchItem { get; set; }
    }
}
