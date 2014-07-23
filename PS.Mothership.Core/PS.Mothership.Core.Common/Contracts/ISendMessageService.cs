using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Event.Notification;
using PS.Mothership.Core.Common.Dto.Message;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof(ISendMessageServiceCallback))]
    public interface ISendMessageService
    {
        [OperationContract]
        void QueueSMSMessage(SendSmsRequestDto insertSmsMessageDto);

        [OperationContract]
        void QueueEmailMessage(SendEmailRequestDto insertEmailMessageDto);

        [OperationContract]
        void SMSMessageDeliveryFailed(string xmlString);

        [OperationContract]
        void SMSMessageDeliverySuccess(string xmlString);

        [OperationContract]
        void SmsMessageReceived(InboundMessage inboundMessage);

        [OperationContract]
        string SendSMSMessageFrom(Guid userGuid);

        [OperationContract(IsOneWay = false)]
        void MessageServiceStatusSubscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void MessageServiceStatusEndSubscribe(string applicationName);

        [OperationContract(IsOneWay = false)]
        void EmailNotificationSubscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void EmailNotificationEndSubscribe(string applicationName);

        [OperationContract(IsOneWay = false)]
        void SmsNotificationSubscribe(string applicationName);

        [OperationContract(IsOneWay = true)]
        void SmsNotificationEndSubscribe(string applicationName);

        [OperationContract]
        void StartMessageListener();

        [OperationContract]
        IList<SendMessageServiceStatusDto> GetMessageServiceStatus();

        [OperationContract]
        IList<NotificationReceivedDto> GetEventNotications(Guid userGuid);
    }
}
