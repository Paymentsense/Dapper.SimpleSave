using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Template.App;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationStatusDto
    {
        [DataMember]
        public Guid ApplicationGuid { get; set; }

        [DataMember]
        public AppStatusEnum StatusKey { get; set; }

        //ToDo: This will change in the future to include a complete event itself including the time rather than just eventType
        [DataMember]
        public IList<EventTypeEnum> EventTypeKey { get; set; }
    }
}
