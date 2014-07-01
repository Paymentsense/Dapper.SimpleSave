using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_ApplicationInfoOutletDto
    {
        public string Outlet_Number { get; set; }
        public FirstData_ApplicationInfoOutletAddressDto Outlet_Address { get; set; }
        public FirstData_InfoOutletBusinessInfoBusinessDto Outlet_Business_Info { get; set; }
        public FirstData_InfoOutletOutletTradingInfoDto Outlet_Trading_Info { get; set; }
        public List<FirstData_InfoOutletEntitlementDto> Outlet_Entitlement { get; set; }
        public FirstData_InfoOutlet_EquipmentDto Outlet_EquipmentField { get; set; }
        public List<FirstData_InfoOutletFeeDto> Outlet_Fees { get; set; }

    }
}
