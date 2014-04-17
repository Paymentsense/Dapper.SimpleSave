using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.SendMessage
{
    [DataContract]
    public class SendMessageSmsToDto
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string ServiceResponseID { get; set; }
    }
}
