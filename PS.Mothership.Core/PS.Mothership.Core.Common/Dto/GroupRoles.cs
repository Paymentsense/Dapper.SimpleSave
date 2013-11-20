using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class GroupRoles
    {
        private List<Group> _groups = new List<Group>();

        [DataMember]
        public List<Group> Groups { 
            get{
                return _groups;
            }
            set
            {
                _groups = value;
            }
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }
    }
}
