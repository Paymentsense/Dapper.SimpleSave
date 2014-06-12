using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NameSearchRequestDto
    {
        public string CompanyName { get; set; }
        public string DataSet { get; set; }
        public int SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public string RegressionKey { get; set; }
    }
}
