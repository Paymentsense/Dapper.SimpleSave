using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Dto.SendMessage;
using PS.Mothership.Core.Common.Template.Comm;
using Quartz;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(ISendMessageStatusServiceCallback))]
    public interface ISendMessageService : IQuartzJobBase
    {
        [OperationContract]
        void QueueSMSMessage(SendSmsRequestDto insertSmsMessageDto);

        [OperationContract]
        void QueueEmailMessage(SendEmailRequestDto insertSmsMessageDto);

        [OperationContract]
        void SMSMessageDeliveryFailed(string xmlString);

        [OperationContract]
        void SMSMessageDeliverySuccess(string xmlString);

        [OperationContract]
        void SMSMessageRecieved(string xmlString);

        [OperationContract]
        string SendSMSMessageFrom(Guid userGuid);

        [OperationContract]
        void PushSMSServiceStatus(MessageServiceStatusEnum serviceStatus);

        [OperationContract]
        void PushEmailServiceStatus(MessageServiceStatusEnum serviceStatus);

        [OperationContract(IsOneWay = false)]
        void SendSMSServiceSubscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void SendSMSServiceEndSubscribe(string applicationName);

        [OperationContract(IsOneWay = false)]
        void SendEmailServiceSubscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void SendEmailServiceEndSubscribe(string applicationName);

        [OperationContract]
        void StartMessageListener();
    }
}
