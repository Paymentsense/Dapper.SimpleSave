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

        public ManyToOneChildDto ManyToOneChildDto { get; set; }
    }
}
