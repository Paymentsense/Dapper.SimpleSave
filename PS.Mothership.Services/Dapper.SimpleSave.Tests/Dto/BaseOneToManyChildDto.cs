using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.Dto {
    public abstract class BaseOneToManyChildDto : BaseChildDto {

        [ForeignKeyReference(typeof(ParentDto))]
        public int? ParentDtoKey { get; set; }

        [ForeignKeyReference(typeof(ParentReferenceDto))]
        public int? ParentReferenceDtoKey { get; set; }

        [ForeignKeyReference(typeof(ParentSpecialDto))]
        public int? ParentSpecialDtoKey { get; set; }
    }
}
