namespace Dapper.SimpleSave.Tests.Dto {
    public abstract class BaseParentDto {

        protected BaseParentDto()
        {
            ParentName = "Parent";
        }

        [PrimaryKey]
        public int? ParentKey { get; set; }

        public string ParentName { get; set; }
    }
}
