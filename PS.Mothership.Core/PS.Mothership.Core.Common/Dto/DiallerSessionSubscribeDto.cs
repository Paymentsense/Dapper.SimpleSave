using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class DiallerSessionSubscribeDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public DateTime StartDateTime { get; set; }
        [DataMember]
        public string ClientIp { get; set; }
    }
}
