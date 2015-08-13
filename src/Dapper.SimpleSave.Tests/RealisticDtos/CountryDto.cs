using System;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[gen].[COUNTRY_ENUM]")]
    [ReferenceData]
    public class CountryDto
    {
        [PrimaryKey]
        public int? CountryKey { get; set; }
        public string Alpha3CountryCode { get; set; }
        public string NumericCountryCode { get; set; }
        public string Name { get; set; }
        public string TelephoneCountryCode { get; set; }
        public bool IsFraudWatch { get; set; }
        [SimpleSaveIgnore]
        public Guid RowGUID { get; set; }
        [Column("RecStatusKey")]
        [ManyToOne]
        public RecStatusEnum RecStatus { get; set; }
        [Column("CurrencyCodeKey")]
        [ManyToOne]
        public CurrencyCodeDto CurrencyCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string TelephoneValidationRegex { get; set; }
        public string TelephoneValidationMessage { get; set; }
        public string Alpha2CountryCode { get; set; }
    }
}
