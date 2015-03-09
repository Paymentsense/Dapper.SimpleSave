using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;

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
        ScheduledCallbackDto AddOrUpdateTask(ScheduledCallbackDto scheduledCallBackDto);

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
        MerchantReminderTypeMetadataDto GetReminderMetaData();
    }
}
