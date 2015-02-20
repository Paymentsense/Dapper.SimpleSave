using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(IDiallerTaskServiceCallback))]
    public interface IDiallerTaskService
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);
    }
}
