using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class SpeedDialNumberDto
    {
        [DataMember]
        public Guid SpeedDialNumberGuid { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
