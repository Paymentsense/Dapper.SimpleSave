using System.Collections.Generic;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[user].POSITION_MST")]
    [ReferenceData]
    public class PositionDto
    {
        public PositionDto()
        {
            Groups = new List<GroupDto>();
        }

        [PrimaryKey]
        public int? PositionKey { get; set; }

        public string Name { get; set; }

        [OneToMany]
        public IList<GroupDto> Groups { get; set; } 

    }
}
