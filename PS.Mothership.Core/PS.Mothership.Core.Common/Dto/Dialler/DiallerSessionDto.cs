using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class DiallerSessionDto
    {       
        [DataMember]
        public Guid DiallerSessionGuid { get; set; }
        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }
        [DataMember]
        public DateTimeOffset? EndDateTime { get; set; }
        [DataMember]
        public bool WasForcedLogout { get; set; }
        [DataMember]
        public bool SessionComplete { get; set; }
        [DataMember]
        public DialLogoutReasonEnum LogoutReasonKey { get; set; }
    }
}