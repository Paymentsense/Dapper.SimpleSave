using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class ProspectListWithAddressDto
    {
        [DataMember]
        public string BusinessName { get; set; }

        [DataMember]
        public FullAddressDto Address { get; set; }

    }
}
