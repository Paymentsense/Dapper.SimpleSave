using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.ScheduledCallBack;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name="DiallerTaskNotificationCallback")]
    public interface IDiallerTaskNotificationCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveNotification(ScheduledCallBackDto taskDto);
    }
}
