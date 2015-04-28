using PS.Mothership.Core.Common.Dto.Notification;
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.NotificationPanel
{
    [DataContract]
    public class NotificationPanelTask : TaskNotificationDto
    {
        [DataMember]
        public string NotificationTitle { get; set; }
        [DataMember]
        public bool IsNotificationSeen { get; set; }
        [DataMember]
        public DateTimeOffset NotificationTime { get; set; }
        [DataMember]
        public Guid MerchantGuid { get; set; }
        [DataMember]
        public string Type { get; set; }

    }
}
