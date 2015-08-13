using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.Dto
{
    public class BaseContextualOneToOneChildDtoWithFk : BaseChildDto
    {
        [ForeignKeyReference(typeof(ContextualReferenceDataParentDto))]
        public int? ParentKey { get; set; }
    }
}
