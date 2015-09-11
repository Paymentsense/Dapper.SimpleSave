namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[AUTHORISATION_FEE_LUT]")]
    public class AuthorisationFee
    {
        [PrimaryKey(true)]
        public int? FieldItemKey { get; set; }

        public decimal Value { get; set; }

        public decimal Revenue { get; set; }

        public decimal Cost { get; set; }

        public int CalculatorVersionKey { get; set; }

        [SimpleSaveIgnore]
        public string Name { get; set; }
    }
}
