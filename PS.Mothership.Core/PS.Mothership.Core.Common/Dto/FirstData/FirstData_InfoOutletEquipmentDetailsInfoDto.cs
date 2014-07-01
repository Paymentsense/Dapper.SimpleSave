using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_Application_InfoOutletOutlet_EquipmentEquipment_Details_Info
    {
        public string Terminal_Type { get; set; }
        public Application_InfoOutletOutlet_EquipmentEquipment_Details_InfoBill_Method Bill_Method { get; set; }
        public string Price { get; set; }
        public string Serial_Number { get; set; }
        public string Equipment_Quantity { get; set; }
        public FirstData_InfoOutletEquipmentDetailsInfoEquipmentFeatureInfoDto[] Equipment_Feature_Info { get; set; }

    }
}
