using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.NotificationPanel;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;
using PS.Mothership.Core.Common.Dto.Reminder;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name="DiallerTaskNotificationService")]
    public interface IDiallerTaskNotificationService
    {
        [OperationContract]
        ScheduledCallbackDto AddOrUpdateTask(ScheduledCallbackDto scheduledCallBackDto, EventNotificationTypeEnum notificationType);


        [OperationContract]
        ReminderDto AddOrUpdateReminderTask(ReminderDto reminderDto);


        [OperationContract]
        void CancelTask(ScheduledCallbackDto scheduledCallBackDto);

        [OperationContract]
        void CancelTaskById(Guid id, Guid eventId);

        [OperationContract]
        IList<ScheduledCallbackDto> GetPendingTasksById(Guid merchantGuid);

        [OperationContract]
        ScheduledCallbackDto GetTask(Guid eventId);

        [OperationContract]
        ScheduledCallbackMetaDataDto GetScheduledCallBackMetaData(Guid merchantGuid);

        [OperationContract]
        void PushbackCallback(ScheduledCallbackDto scheduledCallBackDto);

        [OperationContract]
        void ScheduledCallbackCallMade(ScheduledCallbackDto scheduledCallbackDto);

        [OperationContract]
        void AcknowledgeReminderFromUser(ReminderDto reminderDto);

        [OperationContract]
        IList<NotificationPanelTask> FetchAllUnacknowledgedNotifications(Guid userGuid);

        [OperationContract]
        void CloseEventFromNotificationCentre(Guid eventguid, Guid userGuid);
    }
}
