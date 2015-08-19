namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].SALUTATION_ENUM")]
    [ReferenceData]
    public class SalutationDto
    {
        [PrimaryKey]
        public int? SalutationKey { get; set; }

        public string Description { get; set; }
    }
}
