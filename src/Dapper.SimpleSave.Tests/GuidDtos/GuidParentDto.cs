using System.Collections.Generic;

namespace Dapper.SimpleSave.Tests.GuidDtos {
    [Table("dbo.[GuidParent]")]
    public class GuidParentDto : GuidBaseParentDto {
        [OneToOne]
        [ForeignKeyReference(typeof(GuidOneToOneChildDtoNoFk))]
        public GuidOneToOneChildDtoNoFk OneToOneChildDtoNoFk { get; set; }

        [OneToOne]
        [ForeignKeyReference(typeof(GuidOneToOneReferenceChildDtoNoFk))]
        public GuidOneToOneReferenceChildDtoNoFk OneToOneReferenceChildDtoNoFk { get; set; }

        [OneToOne]
        [ForeignKeyReference(typeof(GuidOneToOneSpecialChildDtoNoFk))]
        public GuidOneToOneSpecialChildDtoNoFk OneToOneSpecialChildDtoNoFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public GuidOneToOneChildDtoWithFk OneToOneChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public GuidOneToOneReferenceChildDtoWithFk OneToOneReferenceChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public GuidOneToOneSpecialChildDtoWithFk OneToOneSpecialChildDtoWithFk { get; set; }

        [OneToMany]
        public IList<GuidOneToManyChildDto> OneToManyChildDto { get; set; }

        [OneToMany]
        public IList<GuidOneToManyReferenceChildDto> OneToManyReferenceChildDto { get; set; }

        [OneToMany]
        public IList<GuidOneToManySpecialChildDto> OneToManySpecialChildDto { get; set; }

        [ManyToOne]
        public GuidManyToOneChildDto ManyToOneChildDto { get; set; }

        [ManyToOne]
        public GuidManyToOneReferenceChildDto ManyToOneReferenceChildDto { get; set; }

        [ManyToOne]

        public GuidManyToOneSpecialChildDto ManyToOneSpecialChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyChild_Lnk")]
        public IList<GuidManyToManyChildDto> ManyToManyChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyReferenceChild_Lnk")]
        public IList<GuidManyToManyReferenceChildDto> ManyToManyReferenceChildDto { get; set; }

        [ManyToMany("dbo.ManyToManySpecialChild_Lnk")]
        public IList<GuidManyToManySpecialChildDto> ManyToManySpecialChildDto { get; set; }
    }
}
