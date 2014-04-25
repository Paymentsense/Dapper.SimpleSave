using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    [DataContract]
    public class PhoneNumberDto
    {
        [DataMember]
        public Guid PhoneNumberGuid { get; set; }

        [DataMember]
        public long CountryKey { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public int BadNumberCount { get; set; }

        [DataMember]
        public bool IsDoNotCall { get; set; }
    }
}