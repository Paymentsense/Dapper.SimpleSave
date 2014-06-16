using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class ExceptionDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
