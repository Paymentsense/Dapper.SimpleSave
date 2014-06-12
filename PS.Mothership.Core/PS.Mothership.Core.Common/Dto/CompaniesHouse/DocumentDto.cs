using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentDto
    {
        public string CompanyNumber { get; set; }
        public FormTypeDto FormType { get; set; }
        public string NumberOfPages { get; set; }
    }
}
