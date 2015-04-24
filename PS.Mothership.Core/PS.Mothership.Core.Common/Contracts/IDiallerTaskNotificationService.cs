using System;
using System.Collections.Generic;
using System.ServiceModel;
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
        ScheduledCallbackDto AddOrUpdateReminderTask(ScheduledCallbackDto reminderDto);


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
        void UnacknowledgedReminderFromUser(ReminderDto reminderDto);
    }
}
