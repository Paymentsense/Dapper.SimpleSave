using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[tele].CAMPAIGN_MST")]
    public class CampaignDto
    {
        [PrimaryKey]
        public int? CampaignKey { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? DaysSinceMerchantLastUpdated { get; set; }

        [ManyToMany("[tele].TELE_APPOINTER_CAMPAIGN_LNK")]
        public IList<UserDto> CurrentlyAssignedTeleAppointers { get; set; }

    }
}
