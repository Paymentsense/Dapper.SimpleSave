using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class NotificationDetail
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}