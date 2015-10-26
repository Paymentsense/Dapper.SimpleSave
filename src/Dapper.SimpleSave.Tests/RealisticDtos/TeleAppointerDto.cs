using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[user].[USER_MST]")]
    public class TeleAppointerDto
    {
        [PrimaryKey]
        public int? UserKey { get; set; }

        [ManyToMany("tele.TELE_APPOINTER_CAMPAIGN_LNK")]
        public IList<CampaignDto> Campaigns { get; set; }
    }
}
