using System;

namespace Dapper.SimpleSave.Tests.GuidDtos {
    public abstract class GuidBaseParentDto {

        protected GuidBaseParentDto()
        {
            ParentName = "Parent";
        }

        [PrimaryKey]
        public Guid? ParentKey { get; set; }

        public string ParentName { get; set; }
    }
}
