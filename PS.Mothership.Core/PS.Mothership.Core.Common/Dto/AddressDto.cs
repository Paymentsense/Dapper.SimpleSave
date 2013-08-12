namespace PS.Mothership.Core.Common.Dto
{
    public class AddressDto : IDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}