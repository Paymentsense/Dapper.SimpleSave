using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.QuartzManagement;

namespace PS.Mothership.Core.Common.Dto.QuartzManagement
{
    public class JobProfileDto
    {
        public string Name { get; set; }
        public AvailableJobGroupsEnum Group { get; set; }
        public IList<TriggerProfileDto> Triggers { get; set; }
    }
}
