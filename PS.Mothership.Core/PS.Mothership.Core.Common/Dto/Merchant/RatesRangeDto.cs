using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class RatesRangeDto
    {
        [DataMember]
        public int FieldKey { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }

        [DataMember]
        public int TypeOfTransactionKey { get; set; }

        [DataMember]
        public double FloorPrice { get; set; }

        [DataMember]
        public double? CeilingPrice { get; set; }
    }
}