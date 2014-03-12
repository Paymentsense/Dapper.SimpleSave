using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Template.Comm;
using Quartz;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISendMessageStatusServiceCallback
    {

        [OperationContract(IsOneWay = true)]
        void PushSMSServiceStatus(MessageServiceStatusEnum serviceStatus);

        [OperationContract(IsOneWay = true)]
        void PushEmailServiceStatus(MessageServiceStatusEnum serviceStatus);
        
    }
}
