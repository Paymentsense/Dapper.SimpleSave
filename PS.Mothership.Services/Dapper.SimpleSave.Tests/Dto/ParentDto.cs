using System.Collections.Generic;

namespace Dapper.SimpleSave.Tests.Dto {
    [Table("dbo.[Parent]")]
    public class ParentDto : BaseParentDto {
        [OneToOne]
        [ForeignKeyReference(typeof(OneToOneChildDtoNoFk))]
        public OneToOneChildDtoNoFk OneToOneChildDtoNoFk { get; set; }

        [OneToOne]
        [ForeignKeyReference(typeof(OneToOneReferenceChildDtoNoFk))]
        public OneToOneReferenceChildDtoNoFk OneToOneReferenceChildDtoNoFk { get; set; }

        [OneToOne]
        [ForeignKeyReference(typeof(OneToOneSpecialChildDtoNoFk))]
        public OneToOneSpecialChildDtoNoFk OneToOneSpecialChildDtoNoFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public OneToOneChildDtoWithFk OneToOneChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public OneToOneReferenceChildDtoWithFk OneToOneReferenceChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        public OneToOneSpecialChildDtoWithFk OneToOneSpecialChildDtoWithFk { get; set; }

        [OneToMany]
        public IList<OneToManyChildDto> OneToManyChildDto { get; set; }

        [OneToMany]
        public IList<OneToManyReferenceChildDto> OneToManyReferenceChildDto { get; set; }

        [OneToMany]
        public IList<OneToManySpecialChildDto> OneToManySpecialChildDto { get; set; }

        [ManyToOne]
        public ManyToOneChildDto ManyToOneChildDto { get; set; }

        [ManyToOne]
        public ManyToOneReferenceChildDto ManyToOneReferenceChildDto { get; set; }

        [ManyToOne]

        public ManyToOneSpecialChildDto ManyToOneSpecialChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyChild_Lnk")]
        public IList<ManyToManyChildDto> ManyToManyChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyReferenceChild_Lnk")]
        public IList<ManyToManyReferenceChildDto> ManyToManyReferenceChildDto { get; set; }

        [ManyToMany("dbo.ManyToManySpecialChild_Lnk")]
        public IList<ManyToManySpecialChildDto> ManyToManySpecialChildDto { get; set; }
    }
}
