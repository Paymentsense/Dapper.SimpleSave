using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class RatesRangeDto
    {
        [DataMember]
        public int FieldKey { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public double FloorPrice { get; set; }

        [DataMember]
        public double? CeilingPrice { get; set; }
    }
}