using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ProspectMatchDto
    {
        [DataMember] 
        public bool IsSingularMatch { get; set; }
        
        [DataMember] 
        public bool IsMatch { get; set; }

        [DataMember]
        public bool IsLive { get; set; }

        [DataMember]
        public Guid OwnerGuid { get; set; }
    }
}
