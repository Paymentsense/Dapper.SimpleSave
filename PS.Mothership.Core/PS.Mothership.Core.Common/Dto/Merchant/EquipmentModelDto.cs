using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class EquipmentModelDto
    {
        [DataMember]
        public long EquipmentlModelKey { get; set; }

        [DataMember]
        public long EquipmentVendorKey { get; set; }

        [DataMember]
        public OppEquipmentCategoryEnum EquipmentCategoryKey { get; set; }

        [DataMember]
        public string ModelNumber { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }
        
    }
}
