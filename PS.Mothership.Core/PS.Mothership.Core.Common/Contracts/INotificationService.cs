using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(INotificationCallback))]
    public interface INotificationService
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(Guid subscriptionId, string userName, string[] eventNames);
        [OperationContract(IsOneWay = true)]
        void EndSubscribe(Guid subscriptionId);
    }

    [ServiceContract]
    public interface INotificationCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(NotificationResultDto notificationResult);
    }

    [DataContract]
    public class NotificationResultDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string NotificationMessage { get; set; }
    }
}
