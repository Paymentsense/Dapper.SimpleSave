using PS.Mothership.Core.Common.Template.Gen;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class EquipmentOptionLutDto
    {
        [DataMember]
        public int EquipmentOptionKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? PreReqEquipmentOptionKey { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }
    }
}
