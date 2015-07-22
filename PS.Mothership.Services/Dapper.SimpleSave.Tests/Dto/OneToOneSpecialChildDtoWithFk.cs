namespace Dapper.SimpleSave.Tests.Dto {
    [Table("dbo.OneToOneSpecialChildWithFk")]
    [ReferenceData(true)]
    public class OneToOneSpecialChildDtoWithFk : BaseOneToOneChildDtoWithFk
    {
    }
}
