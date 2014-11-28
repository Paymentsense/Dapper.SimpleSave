using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferAuthorizationFeeDto
    {
        [DataMember]
        public int AuthorisationFeeKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }
    }
}