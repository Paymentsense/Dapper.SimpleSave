using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SmsNotificationDto
    {
        [DataMember]
        public bool IsDelivered { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string MessageId { get; set; }
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public DateTime OccurredAt { get; set; }
    }
}
