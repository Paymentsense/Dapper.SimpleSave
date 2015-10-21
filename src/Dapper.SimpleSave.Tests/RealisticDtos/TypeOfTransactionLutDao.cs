using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[TYPE_OF_TRANSACTION_LUT]")]
    [ReferenceData]
    public class TypeOfTransactionLutDao
    {
        [PrimaryKey]
        public int? FieldItemKey { get; set; }

        [ManyToOne]
        [Column("FieldItemKey")]
        public FieldItemLutDao FieldItem { get; set; }

        public OppTypeOfTransactionEnum TypeOfTransactionEnumKey { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
