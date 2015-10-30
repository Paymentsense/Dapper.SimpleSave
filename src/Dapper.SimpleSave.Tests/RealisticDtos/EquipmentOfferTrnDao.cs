using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[EQUIPMENT_OFFER_TRN]")]
    public class EquipmentOfferTrnDao
    {
        [PrimaryKey]
        public Guid? EquipmentOfferGuid { get; set; }

        [ForeignKeyReference(typeof(OfferDto))]
        public Guid? OfferGuid { get; set; }

        [OneToMany]
        public IList<EquipmentOptionTrnDao> EquipmentOptions { get; set; }
    }
}
