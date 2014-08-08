using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISendMessageServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void PushServiceStatus(SendMessageServiceStatusDto serviceStatus);

        [OperationContract(IsOneWay = true)]
        void PushSmsNotificationReceived(NotificationReceivedDto notificationReceived, int totalUserNotifications);

        [OperationContract(IsOneWay = true)]
        void PushEmailNotificationReceived(NotificationReceivedDto notificationReceived, int totalUserNotifications); 
    }
}
