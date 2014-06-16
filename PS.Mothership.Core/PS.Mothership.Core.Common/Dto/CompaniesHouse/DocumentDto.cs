using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class DocumentDto
    {
        public int CompanyNumber { get; set; }
        public FormTypeDto FormType { get; set; }
        public int NumberOfPages { get; set; }
    }
}
