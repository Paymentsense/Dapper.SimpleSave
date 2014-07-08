using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);
        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);
    }
}
