namespace Dapper.SimpleSave.Tests.Dto {
    public abstract class BaseParentDto {

        protected BaseParentDto()
        {
            ParentName = "Parent";
            IsActive = true;
        }

        [PrimaryKey]
        public int? ParentKey { get; set; }

        public string ParentName { get; set; }

        [SoftDeleteColumn]
        public bool IsActive { get; set; }
    }
}
