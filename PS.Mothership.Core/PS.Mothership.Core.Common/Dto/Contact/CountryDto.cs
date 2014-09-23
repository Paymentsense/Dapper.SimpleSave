using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public string TelephoneCountryCode { get; set; }

        [DataMember]
        public string DisplayName { get; set; }
    }
}
