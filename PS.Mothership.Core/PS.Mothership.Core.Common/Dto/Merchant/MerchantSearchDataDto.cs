using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract(Name = "merchantSearchData")]
    public class MerchantSearchDataDto
    {
        [DataMember(Name = "advancedSearch")]
        public AdvancedSearchDto AdvancedSearch { get; set; }

        [DataMember(Name = "textSearch")]
        public string TextSearch { get; set; }

        [DataMember(Name = "isAdvancedSearch")]
        public bool IsAdvancedSearch { get; set; }

    }
}