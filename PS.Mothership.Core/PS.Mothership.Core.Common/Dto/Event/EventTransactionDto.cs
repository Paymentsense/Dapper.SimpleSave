using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

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
        public EventTypeEnum EventTypeKey { get; set; }
        [DataMember]
        public Guid StatusOwnerGuid { get; set; }
        [DataMember]
        public Guid NotificationGuid { get; set; }
    }
}
