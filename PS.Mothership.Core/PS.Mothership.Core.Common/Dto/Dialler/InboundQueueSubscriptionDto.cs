using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class InboundQueueSubscriptionDto
    {
        [DataMember]
        public Guid InboundQueueGuid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string ServiceAgent { get; set; }

        [DataMember]
        public List<InboundQueueDistributorDto> QueueDistributors { get; set; }
    }
}
