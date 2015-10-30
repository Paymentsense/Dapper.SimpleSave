using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[FIELD_ITEM_LUT]")]
    [ReferenceData]
    public class FieldItemLutDao
    {
        [PrimaryKey]
        public int? FieldItemKey { get; set; }

        public string Name { get; set; }

        //  TODO: Bart - this isn't helping us get rid of the usr schema. Do we need it?
        public UsrResourceEnum OverrideResourceKey { get; set; }

        public string Description { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
