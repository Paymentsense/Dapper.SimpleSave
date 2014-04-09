using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SendMessageRequestSmsDTO : SendMessageRequestDto
    {
        [DataMember]
        public List<SendMessageSmsToDTO> To { get; set; }
        [DataMember]
        public string From { get; set; }
        //[DataMember]
        //public string MessageBody { get; set; }
        //[DataMember]
        //public Guid SessionGuid { get; set; }
        //[DataMember]
        //public DateTimeOffset TimeToSend { get; set; }
        //[DataMember]
        //public Guid CustomerGUID { get; set; }
        //[DataMember]
        //public CommMessageTypeEnum MessageType { get; set; }
        //[DataMember]
        //public MessageDirectionEnum MessageDirection { get; set; }
    }

    [DataContract]
    public class SendMessageSmsToDTO
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string ServiceResponseID { get; set; }
    }


    [DataContract]
    public class SmsNotificationDto
    {
        [DataMember]
        public bool IsDelivered { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string MessageId { get; set; }
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public DateTime OccurredAt { get; set; }
    }

    [DataContract]
    public class SMSMessageRecievedDto
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string MessageId { get; set; }
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string MessageText { get; set; }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public string To { get; set; }
    }
}
