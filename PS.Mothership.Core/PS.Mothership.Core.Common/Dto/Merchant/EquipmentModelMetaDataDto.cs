using System;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class EquipmentModelMetadataDto
    {
        [DataMember]
        public int EquipmentModelKey { get; set; }

        [DataMember]
        public int EquipmentVendorKey { get; set; }

        [DataMember]
        public OppEquipmentCategoryEnum EquipmentCategoryKey { get; set; }

        [DataMember]
        public string ModelNumber { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Guid EquipPriceTrnGuid { get; set; }

        [DataMember]
        public double FloorPrice { get; set; }

        [DataMember]
        public double CeilingPrice { get; set; }

        [DataMember]
        public IList<EquipmentOptionLutDto> EquipmentOptions { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public int CustomerTypeKey { get; set; }

        [DataMember]
        public int TypeOfTransactionKey { get; set; }
    }
}
