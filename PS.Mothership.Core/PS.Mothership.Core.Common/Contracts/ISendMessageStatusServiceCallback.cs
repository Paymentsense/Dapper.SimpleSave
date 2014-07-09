using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISendMessageStatusServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void PushServiceStatus(SendMessageServiceStatusDto serviceStatus); 
    }
}
