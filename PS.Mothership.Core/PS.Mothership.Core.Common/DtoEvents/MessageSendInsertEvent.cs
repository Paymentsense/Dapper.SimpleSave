using System;
using System.Collections.Generic;
using System.ServiceModel;
using Microsoft.Practices.ServiceLocation;
using PS.Mothership.Core.Common.Config;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Contracts
{
    public class MessageSendInsertEvent : IDtoEvent
    {
       public Guid MessageGuid { get; set; }
       public CommMessageStatusEnum CommMessageStatusEnum { get; set; }
    }
}