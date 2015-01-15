using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ProspectMatchDto
    {
        [DataMember] 
        public bool IsSingularMatch;
        
        [DataMember] 
        public bool IsMatch;

        [DataMember]
        public bool IsLive;

        [DataMember]
        public Guid OwnerGuid;
    }
}
