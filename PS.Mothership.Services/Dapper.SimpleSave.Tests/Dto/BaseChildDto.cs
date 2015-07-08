namespace Dapper.SimpleSave.Tests.Dto {
    public abstract class BaseChildDto {
        protected BaseChildDto()
        {
            Name = "Kiddie";
        }

        [PrimaryKey]
        public int? ChildKey { get; set; }

        public string Name { get; set; }
    }
}
