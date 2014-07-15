using PS.Mothership.Core.Common.Template.Gen;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.SchedulerManagement
{
    public class JobProfileDto
    {
        public string Name { get; set; }
        public GenSchedulerJobGroupEnum Group { get; set; }
        public IList<TriggerProfileDto> Triggers { get; set; }
        public bool Active { get; set; }
    }
}
