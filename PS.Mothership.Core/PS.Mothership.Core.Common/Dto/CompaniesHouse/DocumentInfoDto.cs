using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentInfoDto
    {
        public string CompanyNumber { get; set; }
        public FormTypeDto FormType { get; set; }
        public string NumPages { get; set; }
        public string MadeUpDate { get; set; }
        //TODO Enum
        public string Media { get; set; }
        public string DocRequestKey { get; set; }
    }
}
