using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Groups
{
    [DataContract]
    public class GroupRolesDto
    {
        //TODO: Refactor

        private List<GroupDto> _groups = new List<GroupDto>();

        [DataMember]
        public List<GroupDto> Groups { 
            get{
                return _groups;
            }
            set
            {
                _groups = value;
            }
        }

        public void AddGroup(GroupDto group)
        {
            _groups.Add(group);
        }
    }
}
