using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class ClientModeChangeDto
    {
        [DataMember]
        public Guid DiallerSessionGuid { get; set; }
        [DataMember]
        public DateTime StartDateTime { get; set; }
        [DataMember]
        public int ClientMode { get; set; }
    }
}
