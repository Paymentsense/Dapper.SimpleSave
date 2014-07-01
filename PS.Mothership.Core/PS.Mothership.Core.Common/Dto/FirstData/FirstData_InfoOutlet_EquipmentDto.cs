using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_InfoOutlet_EquipmentDto
    {
        public string Receipt_Name { get; set; }
        public string Receipt_Address_One { get; set; }
        public string Receipt_Address_Two { get; set; }
        public Application_InfoOutletOutlet_EquipmentOperating_Method Operating_Method { get; set; }
        public string Payment_Service_Provider { get; set; }
        public Application_InfoOutletOutlet_EquipmentBanking_Window_From Banking_Window_From { get; set; }
        public Application_InfoOutletOutlet_EquipmentBanking_Window_To Banking_Window_To { get; set; }
        public string Ship_To_Arrive_Date { get; set; }
        public string Receipt_Message { get; set; }
        public Application_InfoOutletOutlet_EquipmentBilling_Method Billing_Method { get; set; }
        public string Card_Holder_Statement_Narrative { get; set; }
        public List<FirstData_Application_InfoOutletOutlet_EquipmentEquipment_Details_Info> Equipment_Details_Info { get; set; }

    }
}
