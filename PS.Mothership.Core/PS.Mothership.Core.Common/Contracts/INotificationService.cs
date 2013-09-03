using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(INotificationCallback))]
    public interface INotificationService : IJob
    {
        [OperationContract(IsOneWay = false)]
        void Subscribe(string applicationName);
        [OperationContract(IsOneWay = true)]
        void EndSubscribe(string applicationName);
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
        public List<NotificationDetail> NotificationDetails  { get; set; }
    }

    [DataContract]
    public class NotificationDetail
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
