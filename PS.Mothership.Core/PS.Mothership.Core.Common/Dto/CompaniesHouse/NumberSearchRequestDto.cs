using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NumberSearchRequestDto
    {
        public string PartialCompanyNumber { get; set; }
        public IList<string> DataSet { get; set; }
        public decimal SearchRows { get; set; }
    }
}
