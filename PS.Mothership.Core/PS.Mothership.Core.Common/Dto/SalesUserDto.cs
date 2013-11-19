using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class SalesUserDto
    {
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public string SalesUserName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public int SelectedTimeToday { get; set; }
        [DataMember]
        public string UserImageFileName { get; set; }
        [DataMember]
        public int AppointmentsToday { get; set; }
        [DataMember]
        public int AppointmentsWeek { get; set; }
        [DataMember]
        public int AppointmentsMonth { get; set; }
        [DataMember]
        public List<CallQueueDto> Campaigns { get; set; }
    }
}
