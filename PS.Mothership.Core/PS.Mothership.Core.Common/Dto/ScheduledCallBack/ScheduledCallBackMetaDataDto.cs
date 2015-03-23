using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.ScheduledCallBack
{
    [DataContract]
    public class ScheduledCallbackMetaDataDto
    {
        [DataMember]
        public IList<EventType> EventTypes { get; set; }

        [DataMember]
        public IList<EventNotificationMethod> NotificationTypes { get; set; }

        [DataMember]
        public IList<ScheduledCallbackContactMetaDataDto> MerchantContacts { get; set; }
    }
}
