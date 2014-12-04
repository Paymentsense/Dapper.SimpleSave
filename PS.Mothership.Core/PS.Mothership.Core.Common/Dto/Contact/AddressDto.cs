using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class AddressDto
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
        public string TownName { get; set; }

        [DataMember]
        public int PostCodeKey { get; set; }
        
        [DataMember]
        public int CountyKey { get; set; }

        [DataMember]
        public int AddressTypeKey { get; set; }

        [DataMember]
        public DateTime? AddressConfirmedDate { get; set; }
        
    }
}