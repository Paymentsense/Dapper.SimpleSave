using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class PhoneNumberDto
    {
        [DataMember]
        public Guid PhoneGuid { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public int BadNumberCount { get; set; }

        [DataMember]
        public bool IsDoNotCall { get; set; }
    }
}