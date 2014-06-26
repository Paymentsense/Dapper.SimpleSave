using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Event.Notification;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface ITaskNotificationCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(NotificationDto taskDto);
    }
}