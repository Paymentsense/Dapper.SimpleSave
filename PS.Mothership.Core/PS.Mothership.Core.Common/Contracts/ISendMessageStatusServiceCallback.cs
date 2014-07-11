using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Event.Notification;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISendMessageStatusServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void PushServiceStatus(SendMessageServiceStatusDto serviceStatus);

        [OperationContract(IsOneWay = true)]
        void PushSmsNotificationReceived(NotificationReceivedDto notificationReceived);

        [OperationContract(IsOneWay = true)]
        void PushEmailNotificationReceived(NotificationReceivedDto notificationReceived); 
    }
}
