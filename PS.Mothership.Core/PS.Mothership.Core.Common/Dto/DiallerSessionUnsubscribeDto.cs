using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class DiallerSessionUnsubscribeDto
    {
        [DataMember]
        public Guid DiallerSessionGuid { get; set; }
        [DataMember]
        public DateTime EndDateTime { get; set; }
        [DataMember]
        public bool WasForcedLogout { get; set; }
        [DataMember]
        public int LogoutReason { get; set; }
    }
}
