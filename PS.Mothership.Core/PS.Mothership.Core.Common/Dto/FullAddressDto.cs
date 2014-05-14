using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class FullAddressDto
    {
        [DataMember] 
        public string BuildingNumber { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string BuildingName { get; set; }       
        [DataMember]
        public string County { get; set; }
        [DataMember]
        public string SubBuilding { get; set; }
    }
}