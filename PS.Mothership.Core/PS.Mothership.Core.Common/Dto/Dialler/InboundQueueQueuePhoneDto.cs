using PS.Mothership.Core.Common.Template.Gen;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class InboundQueueQueuePhoneDto
    {       
        [DataMember]
        public Guid InboundQueueGuid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid QueuePhoneGuid { get; set; }
        [DataMember]
        public Guid ServiceAgentPhoneGuid { get; set; }
        [DataMember]
        public int RingTimeout { get; set; }
        [DataMember]
        public int ConsultTimeout { get; set; }
        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }
    }
}