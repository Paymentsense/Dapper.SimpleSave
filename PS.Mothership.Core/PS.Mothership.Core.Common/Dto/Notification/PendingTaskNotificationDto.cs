using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Notification
{
    [DataContract]
    public class PendingTaskNotificationDto
    {
        [DataMember]
        public Guid NotificationId { get; set; }
        [DataMember]
        public DateTime ScheduledDate { get; set; }
        [DataMember]
        public EventNotificationMethodEnum NotificationMethodKey { get; set; }
        [DataMember]
        public string NotificationDescription { get; set; }
    }
}