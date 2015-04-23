using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;

namespace PS.Mothership.Core.Common.Dto.Dialler
{
    [DataContract]
    public class CallResolutionDto
    {
        [DataMember]
        public Guid EventGuid { get; set; }

        //TODO: add enum for non campaign resolutions and squash from core
        [DataMember]
        public int CallResolutionKey { get; set; }

        [DataMember]
        public ScheduledCallbackDto MerchantTask { get; set; }
    }
}
