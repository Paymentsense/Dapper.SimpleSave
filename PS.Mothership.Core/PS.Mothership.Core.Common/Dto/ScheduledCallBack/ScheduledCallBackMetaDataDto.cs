using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.ScheduledCallBack
{
    [DataContract]
    public class ScheduledCallBackMetaDataDto
    {
        [DataMember]
        public IList<EventType> EventTypes { get; set; }

        [DataMember]
        public IList<ScheduledCallBackContactMetaDataDto> MerchantContacts { get; set; }
    }
}
