using PS.Mothership.Core.Common.Dto.Contact;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class FullAddressDto : AddressDto
    {
        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public CountyDto County { get; set; }

    }
}