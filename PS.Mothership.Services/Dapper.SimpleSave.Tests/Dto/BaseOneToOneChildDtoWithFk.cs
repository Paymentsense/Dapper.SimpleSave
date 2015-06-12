using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.Dto
{
    public class BaseOneToOneChildDtoWithFk : BaseChildDto
    {
        [ForeignKeyReference(typeof(ParentDto))]
        public int? ParentKey { get; set; }

        [ForeignKeyReference(typeof(ParentReferenceDto))]
        public int? ParentReferenceKey { get; set; }

        [ForeignKeyReference(typeof(ParentSpecialDto))]
        public int? ParentSpecialKey { get; set; }
    }
}
