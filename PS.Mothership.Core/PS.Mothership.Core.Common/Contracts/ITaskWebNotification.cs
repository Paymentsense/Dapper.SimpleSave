using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Notification;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface ITaskWebNotification
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(TaskNotificationDto taskNotificationDto);
    }
}