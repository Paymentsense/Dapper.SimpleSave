using System.ComponentModel;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[PHONE_NUMBER_TYPE_ENUM]")]
    public enum PhoneNumberTypeEnum
    {
        [Description("None")]
        None,
        [Description("Main Line")]
        MainLine,
        [Description("Mobile")]
        Mobile,
        [Description("Fax")]
        Fax,
        [Description("Do Not Call")]
        DoNotCall,
        [Description("Office Number")]
        OfficeNumber,
        [Description("Freephone")]
        Freephone
    }
}
