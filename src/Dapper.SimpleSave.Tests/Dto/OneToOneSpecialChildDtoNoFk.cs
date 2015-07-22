namespace Dapper.SimpleSave.Tests.Dto {
    [Table("dbo.OneToOneSpecialChildNoFk")]
    [ReferenceData(true)]
    public class OneToOneSpecialChildDtoNoFk : BaseChildDto {
    }
}
