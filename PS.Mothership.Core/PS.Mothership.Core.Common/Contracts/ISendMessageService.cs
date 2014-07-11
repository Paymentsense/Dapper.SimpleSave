using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(ISendMessageServiceCallback))]
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
        void SMSMessageReceived(string xmlString);

        [OperationContract]
        string SendSMSMessageFrom(Guid userGuid);

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

        [OperationContract]
        List<SendMessageServiceStatusDto> GetMessageServiceStatus();
    }
}
