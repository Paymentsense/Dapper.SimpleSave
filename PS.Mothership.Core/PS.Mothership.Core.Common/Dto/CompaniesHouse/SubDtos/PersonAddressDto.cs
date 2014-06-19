using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class PersonAddressDto
    {
        public string Careof { get; set; }
        public string PoBox { get; set; }
        public IList<string> AddressLine { get; set; }
        public string Posttown { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}
