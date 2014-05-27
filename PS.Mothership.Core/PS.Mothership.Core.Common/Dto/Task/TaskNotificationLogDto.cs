using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Task
{
    [DataContract]
    public class TaskNotificationLogDto
    {
        [DataMember]
        public long TaskNotificationLogID { get; set; }
        [DataMember]
        public long TaskNotificationID { get; set; }
        [DataMember]
        public DateTime TriggeredDate { get; set; }
        [DataMember]
        public bool? IsAcknowledged { get; set; }
        [DataMember]
        public bool? IsRescheduled { get; set; }
    }
}