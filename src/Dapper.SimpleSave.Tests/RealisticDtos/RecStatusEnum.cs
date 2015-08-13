using System.ComponentModel;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[REC_STATUS_ENUM]")]
    public enum RecStatusEnum
    {
        [Description("Unknown")]
        Unknown,
        [Description("Active - Show In Lists")]
        ActiveShowInLists,
        [Description("Active - Do Not Show In Lists")]
        ActiveDoNotShowInLists,
        [Description("In-Active")]
        InActive
    }
}
