using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class SipAccountNumberDto
    {
        [DataMember]
        public Guid SipAccountGuid { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
