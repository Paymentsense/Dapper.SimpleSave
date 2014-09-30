using System;
using System.Collections.Generic;
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
        public int EquipmentModelKey { get; set; }

        [DataMember]
        public Guid EquipmentPriceTrnGuid { get; set; }

        [DataMember]
        public int EquipmentVendorKey { get; set; }
        
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public IList<EquipmentOptionDto> EquipmentOptions { get; set; }

        [DataMember]
        public int EquipmentCategoryKey { get; set; }
    }
}
