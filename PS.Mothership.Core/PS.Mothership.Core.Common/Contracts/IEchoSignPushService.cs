using System.ServiceModel;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "EchoSignPushService")]
    public interface IEchoSignPushService
    {
        [OperationContract]
        void DocumentNotification(string agreementId, AgreementStatusEnum status, EchoSignEventTypeEnum eventType);
    }
}
