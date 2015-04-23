using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Reminder;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name="DiallerTaskNotificationCallback")]
    public interface IDiallerTaskWebNotificationService
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(ScheduledCallbackDto taskDto);

        [OperationContract(IsOneWay = true)]
        void ReceiveReminderNotification(ReminderDto taskDto);
    }
}
