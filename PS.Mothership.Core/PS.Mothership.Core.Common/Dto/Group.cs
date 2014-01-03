using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
