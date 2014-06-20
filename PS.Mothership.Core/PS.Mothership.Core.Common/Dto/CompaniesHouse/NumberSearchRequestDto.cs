using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class NumberSearchRequestDto
    {
        public string PartialCompanyNumber {get; set;}
        public string SearchRows {get; set;}
        public List<DataSet?> DataSet { get; set; }
    }
}
