using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name="DiallerTaskNotificationService", CallbackContract = typeof (IDiallerTaskNotificationCallback))]
    public interface IDiallerTaskNotificationService
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);

        [OperationContract]
        ScheduledCallbackDto AddOrUpdateTask(ScheduledCallbackDto scheduledCallBackDto, EventNotificationTypeEnum notificationType);

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
    }
}
