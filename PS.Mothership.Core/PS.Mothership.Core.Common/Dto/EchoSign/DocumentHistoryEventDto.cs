using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Quartz.Util;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class DocumentHistoryEventDto
    {
        [DataMember]
        public string SynchronizationKey { get; set; }
        [DataMember]
        public string ParticipantEmail { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string VersionId { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string ActingUserIpAddress { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DeviceLocationDto DeviceLocation { get; set; }
        [DataMember]
        public string ActingUserEmail { get; set; }
    }
}
