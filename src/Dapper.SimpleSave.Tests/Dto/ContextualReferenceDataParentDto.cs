using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.Dto
{
    [Table("dbo.[ContextualReferenceDataParent]")]
    public class ContextualReferenceDataParentDto : BaseParentDto
    {
        [OneToOne]
        [ForeignKeyReference(typeof(OneToOneChildDtoNoFk))]
        [ReferenceData]
        public OneToOneChildDtoNoFk OneToOneChildDtoNoFk { get; set; }

        [OneToOne("ChildKey")]  //  TODO: don't think column name is necessary
        [ReferenceData(true)]
        public OneToOneChildDtoWithFk OneToOneChildDtoWithFk { get; set; }

        [ManyToOne]
        [ReferenceData]
        public ManyToOneChildDto ManyToOneChildDto { get; set; }
    }
}
