using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event
{
    [DataContract]
    public class NotificationTransactionDto
    {
        [DataMember]
        public Guid NotificationGuid { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public Guid UpdatedSessionGuid { get; set; }
        [DataMember]
        public EventNotificationMethodEnum NotificationMethodKey { get; set; }
        [DataMember]
        public DateTime ScheduledDate { get; set; }
        [DataMember]
        public DateTime UpdateDate { get; set; }
    }
}