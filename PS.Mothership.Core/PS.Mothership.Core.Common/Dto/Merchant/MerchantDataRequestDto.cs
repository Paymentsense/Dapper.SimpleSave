using PS.Mothership.Core.Common.Dto.DynamicRequest;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract(Name = "merchantDataRequest")]
    public class MerchantDataRequestDto
    {
        [DataMember(Name = "advancedSearch")]
        public AdvancedSearchDto AdvancedSearch { get; set; }

        [DataMember(Name = "textSearch")]
        public string TextSearch { get; set; }

        [DataMember(Name = "isAdvancedSearch")]
        public bool IsAdvancedSearch { get; set; }

        [DataMember(Name = "dataRequest")]
        public DataRequestDto DataRequest { get; set; }
    }
}
