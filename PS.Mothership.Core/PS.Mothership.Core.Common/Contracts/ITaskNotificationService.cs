using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Event.Notification;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(ITaskNotificationCallback))]
    public interface ITaskNotificationService : IQuartzJobBase
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);
        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);
        [OperationContract]
        TaskNotificationDto AddNewTask(TaskNotificationDto taskNotificationDto);
        [OperationContract]
        IList<TaskNotificationDto> RetreiveUserTasks(Guid userGuid);
        [OperationContract]
        TaskNotificationDto UpdateTask(TaskNotificationDto taskNotificationDto);
        [OperationContract]
        void CloseTask(TaskNotificationDto taskNotificationDto);
        [OperationContract]
        void CancelTask(TaskNotificationDto taskNotificationDto);
    }
}
