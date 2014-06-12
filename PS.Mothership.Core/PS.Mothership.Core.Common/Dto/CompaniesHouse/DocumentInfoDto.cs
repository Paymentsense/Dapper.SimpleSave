using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentInfoDto
    {
        public int CompanyNumber { get; set; }
        public FormTypeDto FormType { get; set; }
        public int NumPages { get; set; }
        public string MadeUpDate { get; set; }
        public Media Media { get; set; }
        public string DocRequestKey { get; set; }
    }
}
