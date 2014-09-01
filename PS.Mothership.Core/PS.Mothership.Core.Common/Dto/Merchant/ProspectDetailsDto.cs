using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    public class ProspectDetailsDto
    {
        public Guid MerchantGuid { get; set; }

        public PS.Mothership.Core.Common.Template.Cust.CustNumberEmployeesEnum NumberEmployeesKey { get; set; }

        public PS.Mothership.Core.Common.Template.Gen.GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

        public long AnnualTurnover { get; set; }

        public long CallRestrictedReasonKey { get; set; }
    }
}
