using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SmsMessageReceivedDto
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
