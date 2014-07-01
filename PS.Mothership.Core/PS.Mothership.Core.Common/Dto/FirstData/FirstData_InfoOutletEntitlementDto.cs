using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_InfoOutletEntitlementDto
    {
        public Application_InfoOutletEntitlementCard_Type Card_Type { get; set; }
        public Application_InfoOutletEntitlementRequest_Type Request_Type { get; set; }
        public string SE_Number { get; set; }
        public string Floor_Limit { get; set; }

    }

}
