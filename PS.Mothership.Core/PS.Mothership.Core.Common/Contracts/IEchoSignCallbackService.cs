using System.ServiceModel;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "EchoSignService")]
    public interface IEchoSignCallbackService
    {
        [OperationContract]
        void DocumentNotification(string agreementId, AgreementStatusEnum status, EventTypeEnum eventType);
    }
}
