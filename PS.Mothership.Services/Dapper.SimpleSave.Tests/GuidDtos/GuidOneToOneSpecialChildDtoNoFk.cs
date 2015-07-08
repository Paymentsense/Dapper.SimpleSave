namespace Dapper.SimpleSave.Tests.GuidDtos {
    [Table("dbo.GuidOneToOneSpecialChildNoFk")]
    [ReferenceData(true)]
    public class GuidOneToOneSpecialChildDtoNoFk : GuidBaseChildDto {
    }
}
