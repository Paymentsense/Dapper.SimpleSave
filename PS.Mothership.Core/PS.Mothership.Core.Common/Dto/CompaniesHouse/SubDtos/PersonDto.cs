using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class PersonDto
    {
        public bool? CorporateIndicator { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public DateTime? Dob { get; set; }
        public string Nationality { get; set; }
        public string CountryOfResidence { get; set; }
        public PersonAddressDto PersonAddress { get; set; }
        public List<string> Forename { get; set; }
     }
}
