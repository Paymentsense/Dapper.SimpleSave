using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferFieldItemLutDto
    {
        [DataMember]
        public int FieldItemKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public int? DisplayOrder { get; set; }
    }
}