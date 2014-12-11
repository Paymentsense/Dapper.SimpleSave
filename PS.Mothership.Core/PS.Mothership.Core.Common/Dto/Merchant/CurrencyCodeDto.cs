using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class CurrencyCodeDto
    {
        [DataMember]
        public int CurrencyCodeKey { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public string SubUnit { get; set; }
    }
}
