using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Notification
{
    [DataContract]
    public class NotificationResultDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<PendingTaskNotificationDto> PendingTaskNotifications { get; set; }
    }
}