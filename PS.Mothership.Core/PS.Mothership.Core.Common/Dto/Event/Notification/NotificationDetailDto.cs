using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Event.Notification
{
    [DataContract]
    public class NotificationDetailDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}