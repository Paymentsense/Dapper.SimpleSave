using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerSearchItemBaseDto
    {
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public DateTime Dob { get; set; }
        public string PostTown { get; set; }
        public string Postcode { get; set; }
        public string CountryOfResidence { get; set; }
    }
}
