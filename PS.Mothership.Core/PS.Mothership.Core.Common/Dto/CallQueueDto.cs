using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class CallQueueDto
    {
        [DataMember]
        public string QueueName { get; set; }
        [DataMember]
        public int Records { get; set; }
        [DataMember]
        public long CampaignId { get; set; }
    }
}
