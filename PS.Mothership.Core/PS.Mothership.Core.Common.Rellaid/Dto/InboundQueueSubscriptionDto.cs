using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class InboundQueueSubscriptionDto
    {
        [DataMember]
        public long QueueId { get; set; }
        [DataMember]
        public string QueueName { get; set; }
        [DataMember]
        public string QueuePhoneNumber { get; set; }
        [DataMember]
        public string QueueServiceAgent { get; set; }
        [DataMember]
        public List<InboundQueueDistributorDto> QueueDistributors { get; set; }
    }
}
