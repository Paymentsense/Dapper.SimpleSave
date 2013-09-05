using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Contracts;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class NotificationResultDto
    {
        [DataMember]
        public List<NotificationDetail> NotificationDetails  { get; set; }
    }
}