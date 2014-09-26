using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class EquipmentPriceTrnDto
    {
        [DataMember]
        public Guid EquipPriceTrnGuid { get; set; }

        [DataMember]
        public int EquipmentModelKey { get; set; }
        
        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public int CustomerTypeKey { get; set; }

        [DataMember]
        public double WholesaleCost { get; set; }
       
    }
}
