using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public string TelephoneCountryCode { get; set; }

        [DataMember]
        public string DisplayName { get; set; }
    }
}
