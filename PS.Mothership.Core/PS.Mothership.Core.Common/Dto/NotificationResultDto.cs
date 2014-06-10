using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Dto
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