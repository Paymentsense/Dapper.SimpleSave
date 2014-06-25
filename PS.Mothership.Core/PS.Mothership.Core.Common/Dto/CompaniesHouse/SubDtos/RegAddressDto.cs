using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class RegAddressDto
    {
        public string Careof { get; set; }
        public string PoBox { get; set; }
        public List<string> AddressLine { get; set; }

    }
}
