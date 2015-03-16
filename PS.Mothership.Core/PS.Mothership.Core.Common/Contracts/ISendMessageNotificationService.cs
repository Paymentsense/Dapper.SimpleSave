using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISendMessageNotificationService
    {
        [OperationContract(IsOneWay = true)]
        void PushServiceStatus(SendMessageServiceStatusDto serviceStatus);

        [OperationContract(IsOneWay = true)]
        void PushNotificationReceived(NotificationReceivedDto notificationReceived, int totalUserNotifications);
    }
}
