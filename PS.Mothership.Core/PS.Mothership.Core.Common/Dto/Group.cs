using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public List<Role> Roles { get; set; }
    }
}
