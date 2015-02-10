using System;
using System.Collections.Generic;
using System.ServiceModel;
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
        ScheduledCallbackDto AddNewTask(ScheduledCallbackDto scheduledCallBackDto);

        [OperationContract]
        void UpdateTask(ScheduledCallbackDto scheduledCallBackDto);

        [OperationContract]
        void CancelTask(ScheduledCallbackDto scheduledCallBackDto);

        [OperationContract]
        IList<ScheduledCallbackDto> GetPendingTasksById(Guid userGuid, Guid merchantGuid);

        [OperationContract]
        ScheduledCallbackMetaDataDto GetScheduledCallBackMetaData(Guid merchantGuid);
    }
}
