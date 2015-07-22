using System;

namespace Dapper.SimpleSave.Tests.GuidDtos {
    public abstract class GuidBaseChildDto {
        protected GuidBaseChildDto()
        {
            Name = "Kiddie";
        }

        [PrimaryKey]
        public Guid? ChildKey { get; set; }

        public string Name { get; set; }
    }
}
