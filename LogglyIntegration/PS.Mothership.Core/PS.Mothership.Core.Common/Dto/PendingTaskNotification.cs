using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class PendingTaskNotification
    {
        [DataMember]
        public long PendingTaskID { get; set; }
        [DataMember]
        public string TriggeredDate { get; set; }
        [DataMember]
        public bool IsAcknowledged { get; set; }
        [DataMember]
        public bool IsRescheduled { get; set; }
        [DataMember]
        public string TaskDescription { get; set; }
        [DataMember]
        public string NewTriggerStartDate { get; set; }
    }
}