using System;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[CURRENCY_CODE_ENUM]")]
    [ReferenceData]
    public class CurrencyCodeDto
    {
        [PrimaryKey]
        public int? CurrencyCodeKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IWSLCurrencyCode { get; set; }
        public int CurrencyBaseFraction { get; set; }
        [SimpleSaveIgnore]
        public Guid RowGUID { get; set; }
        [Column("RecStatusKey")]
        [ManyToOne]
        public RecStatusEnum RecStatus { get; set; }
        public string Unit { get; set; }
        public string SubUnit { get; set; }
    }
}
