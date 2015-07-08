using System;

namespace Dapper.SimpleSave.Tests.GuidDtos {
    public abstract class GuidBaseOneToManyChildDto : GuidBaseChildDto {

        [ForeignKeyReference(typeof(GuidParentDto))]
        public Guid? ParentDtoKey { get; set; }

        [ForeignKeyReference(typeof(GuidParentReferenceDto))]
        public Guid? ParentReferenceDtoKey { get; set; }

        [ForeignKeyReference(typeof(GuidParentSpecialDto))]
        public Guid? ParentSpecialDtoKey { get; set; }
    }
}
