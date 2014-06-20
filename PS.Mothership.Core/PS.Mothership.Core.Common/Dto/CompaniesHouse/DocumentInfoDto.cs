using System;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentInfoDto
    {
        public string CompanyNumber { get; set; }
        public string FormType { get; set; }
        public string NumPages { get; set; }
        public DateTime? MadeUpDate { get; set; }
        public Media Media { get; set; }
        public string DocRequestKey { get; set; }
    }
}