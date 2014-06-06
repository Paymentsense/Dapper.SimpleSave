using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Task
{
    [DataContract]
    public class TaskNotificationDto
    {
        [DataMember]
        public long TaskNotificationID { get; set; }
        [DataMember]
        public string TaskDescription { get; set; }
        [DataMember]
        public int TaskPriority { get; set; }
        [DataMember]
        public string TaskUserName { get; set; }
        [DataMember]
        public string TaskGroup { get; set; }
        [DataMember]
        public bool TriggerRecurring { get; set; }
        [DataMember]
        public DateTime TriggerStartDateTime { get; set; }
        [DataMember]
        public bool TaskByEmail { get; set; }
    }
}