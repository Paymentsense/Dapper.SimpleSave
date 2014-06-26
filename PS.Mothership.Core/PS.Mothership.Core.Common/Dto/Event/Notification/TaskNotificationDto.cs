using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Event.Notification
{
    [DataContract]
    public class TaskNotificationDto
    {
        [DataMember]
        public Guid NotificationGuid { get; set; }
        [DataMember]
        public DateTime ScheduledDate { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}