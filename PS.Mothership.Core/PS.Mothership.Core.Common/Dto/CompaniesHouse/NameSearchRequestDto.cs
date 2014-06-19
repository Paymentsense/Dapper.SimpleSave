using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NameSearchRequestDto
    {
        public string CompanyName { get; set; }
        public DataSet DataSet { get; set; }
        public bool? SameAs { get; set; }
        public bool SameAsSpecified { get; set; }
        public string SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public string RegressionKey { get; set; }
    }
}
