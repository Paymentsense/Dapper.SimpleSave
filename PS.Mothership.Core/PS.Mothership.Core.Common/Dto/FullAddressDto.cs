using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class FullAddressDto
    {
        [DataMember]
        public Guid AddressGuid { get; set; }

        [DataMember] 
        public string HouseNumber { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string HouseName { get; set; }
        [DataMember]
        public string FlatAptSuite { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        
        [DataMember]
        public string PostCode { get; set; }
        
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string County { get; set; }
        
    }
}