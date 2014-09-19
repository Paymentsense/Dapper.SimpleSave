using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class EquipmentOfferTrnDto
    {
        [DataMember]
        public Guid EquipmentOfferGuid { get; set; }

        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public int EquipmentlModelKey { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal SellPrice { get; set; }

        [DataMember]
        public decimal WholesaleCost { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public int EquipmentVendorKey { get; set; }

        [DataMember]
        public int LessorKey { get; set; }
    }
}
