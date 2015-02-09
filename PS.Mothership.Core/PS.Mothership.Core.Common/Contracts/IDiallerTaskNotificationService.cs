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
        ScheduledCallBackDto AddNewTask(ScheduledCallBackDto scheduledCallBackDto);

        [OperationContract]
        void UpdateTask(ScheduledCallBackDto scheduledCallBackDto);

        [OperationContract]
        void CancelTask(ScheduledCallBackDto scheduledCallBackDto);

        [OperationContract]
        IList<ScheduledCallBackDto> GetPendingTasksById(Guid userGuid, Guid merchantGuid);
    }
}
