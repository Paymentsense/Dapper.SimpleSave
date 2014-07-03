using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class RegAddressDto
    {
        public string CareOfName { get; set; }
        public string PoBox { get; set; }
        public List<string> AddressLine { get; set; }

    }
}
