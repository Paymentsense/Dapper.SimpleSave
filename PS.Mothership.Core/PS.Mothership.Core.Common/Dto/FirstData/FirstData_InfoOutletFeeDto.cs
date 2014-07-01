using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_InfoOutletFeeDto
    {
        public Application_InfoOutletFeeCard_Type Card_Type { get; set; }
        public FirstData_InfoOutletFee_Detail[] Fee_Detail { get; set; }

    }
}
