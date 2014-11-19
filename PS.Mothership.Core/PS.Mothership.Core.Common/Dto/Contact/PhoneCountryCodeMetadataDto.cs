using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class PhoneCountryCodeMetadataDto
    {
        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public int CountryCode { get; set; }
    }
}
