using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[opp].[EQUIPMENT_OPTION_TRN]")]
    public class EquipmentOptionTrnDao
    {
        [PrimaryKey]
        public Guid? EquipmentOptionTrnGuid { get; set; }

        [ForeignKeyReference(typeof(EquipmentOfferTrnDao))]
        public Guid? EquipmentOfferGuid { get; set; }

        public int Quantity { get; set; }
    }
}
