using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Rellaid.Dto
{
    [DataContract]
    public class CallRecordingEventDto
    {
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public Guid? ProspectionCallGuid { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public Guid? MerchantGuid { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
    }
}
