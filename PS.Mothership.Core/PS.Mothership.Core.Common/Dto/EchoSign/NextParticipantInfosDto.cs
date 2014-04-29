using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class NextParticipantInfosDto
    {
        [DataMember]
        public DateTime WaitingSince { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
