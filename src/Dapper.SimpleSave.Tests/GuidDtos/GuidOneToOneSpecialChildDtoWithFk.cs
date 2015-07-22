namespace Dapper.SimpleSave.Tests.GuidDtos {
    [Table("dbo.GuidOneToOneSpecialChildWithFk")]
    [ReferenceData(true)]
    public class GuidOneToOneSpecialChildDtoWithFk : GuidBaseOneToOneChildDtoWithFk
    {
    }
}
