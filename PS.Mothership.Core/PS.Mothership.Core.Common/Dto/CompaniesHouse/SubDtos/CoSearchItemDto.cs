using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CoSearchItemDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public string DataSet { get; set; }
        public CompanyIndexStatus CompanyIndexStatus { get; set; }
        public DateTime CompanyDate { get; set; }
        public string Searchmatch { get; set; }
    }
}
