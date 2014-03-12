using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class GroupDescDto
    {
        [DataMember]
        public Guid GroupGuid { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string GroupDescription { get; set; }
    }
}
