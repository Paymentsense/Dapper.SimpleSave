using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Reminder
{
    [DataContract]
    public class ReminderDto : TaskNotificationDto
    {
        [DataMember]
        public EventTypeEnum ReminderType { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public Guid PhoneGuid { get; set; }

        [DataMember]
        public bool IsEditableByThisUser { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string ContactName { get; set; }
    }
}
