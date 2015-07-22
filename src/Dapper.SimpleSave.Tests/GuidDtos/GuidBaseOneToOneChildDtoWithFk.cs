using System;

namespace Dapper.SimpleSave.Tests.GuidDtos
{
    public class GuidBaseOneToOneChildDtoWithFk : GuidBaseChildDto
    {
        [ForeignKeyReference(typeof(GuidParentDto))]
        public Guid? ParentKey { get; set; }

        [ForeignKeyReference(typeof(GuidParentReferenceDto))]
        public Guid? ParentReferenceKey { get; set; }

        [ForeignKeyReference(typeof(GuidParentSpecialDto))]
        public Guid? ParentSpecialKey { get; set; }
    }
}
