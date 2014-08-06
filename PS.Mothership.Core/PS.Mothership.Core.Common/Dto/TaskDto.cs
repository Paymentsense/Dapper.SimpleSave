using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Notification;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class TaskDto
    {
        [DataMember]
        public DateTime TaskStartDateTime { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsRecurring { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public List<PendingTaskNotificationDto> PendingTaskNotifications { get; set; }
    }
}