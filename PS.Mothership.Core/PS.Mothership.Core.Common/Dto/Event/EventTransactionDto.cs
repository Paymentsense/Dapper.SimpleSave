using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class EventTransactionDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public Guid ParentEventGuid { get; set; }
        [DataMember]
        public int EventTypeKey { get; set; }
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public Guid NotificationGuid { get; set; }
    }
}
