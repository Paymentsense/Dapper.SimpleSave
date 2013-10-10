using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;
using Quartz;

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
        void AddNewTask(TaskDto taskDto);
        [OperationContract]
        void UpdateTask(TaskDto taskDto);
        [OperationContract]
        void CompleteTask(long pendingNotificationID);
        [OperationContract]
        List<PendingTaskNotification> GetPendingTaskNotifications(string userName);
    }
}
