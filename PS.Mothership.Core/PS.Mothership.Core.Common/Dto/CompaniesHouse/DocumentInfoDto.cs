using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentInfoDto
    {
        public string CompanyNumber { get; set; }
        public string FormType { get; set; }
        public decimal NumPages { get; set; }
        public string MadeUpDate { get; set; }
        public Media Media { get; set; }
        public string DocRequestKey { get; set; }
    }
}
