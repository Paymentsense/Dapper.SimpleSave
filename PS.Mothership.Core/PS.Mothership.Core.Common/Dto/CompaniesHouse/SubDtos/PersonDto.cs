namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class PersonDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Honours { get; set; }
        public string Dob { get; set; }
        public string Nationality { get; set; }
        public string CountryOfResidence { get; set; }
        public PersonAddressDto PersonAddress { get; set; }
        public string PersonId { get; set; }
    }
}
