using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Notification
{
    [DataContract]
    public class TaskNotificationDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }

        [DataMember]
        public DateTimeOffset ScheduledDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}