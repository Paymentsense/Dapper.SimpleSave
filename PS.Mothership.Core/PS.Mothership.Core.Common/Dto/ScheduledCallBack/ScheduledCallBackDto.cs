using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.ScheduledCallBack
{
    [DataContract]
    public class ScheduledCallBackDto : TaskNotificationDto
    {
        [DataMember]
        public EventTypeEnum CallBackType { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }
    }
}
