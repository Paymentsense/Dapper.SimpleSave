using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.Message;
using PS.Mothership.Core.Common.Dto.Notification;
using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
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

        [OperationContract]
        IList<SendMessageServiceStatusDto> GetMessageServiceStatus();

        [OperationContract]
        IList<NotificationReceivedDto> GetEventNotications(Guid userGuid);

        [OperationContract]
        IList<NotificationStatusDto> GetNotificationsAndStatuses(Guid userGuid);
    }
}
