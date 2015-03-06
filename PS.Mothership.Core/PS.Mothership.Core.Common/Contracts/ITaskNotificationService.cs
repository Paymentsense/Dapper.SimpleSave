using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(ITaskNotificationCallback))]
    public interface ITaskNotificationService
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);
        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);
        [OperationContract]
        TaskNotificationDto AddNewTask(TaskNotificationDto taskNotificationDto, EventNotificationTypeEnum notificationType);
        [OperationContract]
        IList<TaskNotificationDto> RetrieveUserTasks(Guid userGuid);
        [OperationContract]
        TaskNotificationDto UpdateTask(TaskNotificationDto taskNotificationDto, EventNotificationTypeEnum notificationType);
        [OperationContract]
        void CloseTask(TaskNotificationDto taskNotificationDto);
        [OperationContract]
        void CancelTask(TaskNotificationDto taskNotificationDto);
    }
}
