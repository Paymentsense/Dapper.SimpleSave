using PS.Mothership.Core.Common.Dto;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name="DiallerTaskNotificationCallback")]
    public interface IDiallerTaskNotificationCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(TaskDto taskDto);
    }
}
