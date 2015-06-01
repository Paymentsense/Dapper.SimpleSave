namespace Dapper.SimpleSave.Tests.Dto {
    [Table("dbo.[Parent]")]
    public class ParentDto : BaseParentDto {
        [OneToOne]
        public OneToOneChildDtoNoFk OneToOneChildDtoNoFk { get; set; }

        [OneToOne]
        public OneToOneReferenceChildDtoNoFk OneToOneReferenceChildDtoNoFk { get; set; }

        [OneToOne]
        public OneToOneSpecialChildDtoNoFk OneToOneSpecialChildDtoNoFk { get; set; }

        [OneToOne("ChildKey")]
        public OneToOneChildDtoWithFk OneToOneChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]
        public OneToOneReferenceChildDtoWithFk OneToOneReferenceChildDtoWithFk { get; set; }

        [OneToOne("ChildKey")]
        public OneToOneSpecialChildDtoWithFk OneToOneSpecialChildDtoWithFk { get; set; }

        [OneToMany]
        public OneToManyChildDto OneToManyChildDto { get; set; }

        [OneToMany]
        public OneToManyReferenceChildDto OneToManyReferenceChildDto { get; set; }

        [OneToMany]
        public OneToManySpecialChildDto OneToManySpecialChildDto { get; set; }

        [ManyToOne]
        public ManyToOneChildDto ManyToOneChildDto { get; set; }

        [ManyToOne]
        public ManyToOneReferenceChildDto ManyToOneReferenceChildDto { get; set; }

        [ManyToOne]
        public ManyToOneSpecialChildDto ManyToOneSpecialChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyChild_Lnk")]
        public ManyToManyChildDto ManyToManyChildDto { get; set; }

        [ManyToMany("dbo.ManyToManyReferenceChild_Lnk")]
        public ManyToManyReferenceChildDto ManyToManyReferenceChildDto { get; set; }

        [ManyToMany("dbo.ManyToManySpecialChild_Lnk")]
        public ManyToManySpecialChildDto ManyToManySpecialChildDto { get; set; }
    }
}
