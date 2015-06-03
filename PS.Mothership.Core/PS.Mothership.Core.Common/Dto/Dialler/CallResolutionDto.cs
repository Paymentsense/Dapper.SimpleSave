using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;
using PS.Mothership.Core.Common.Template.Dial;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallResolutionDto
    {
        [DataMember]
        public Guid SipCallGuid { get; set; }

        //TODO: add enum for non campaign resolutions and squash from core
        [DataMember]
        public DialCallResolutionEnum CallResolutionKey { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public ScheduledCallbackDto MerchantTask { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public DialCallTypeEnum CallType { get; set; }
    }
}
