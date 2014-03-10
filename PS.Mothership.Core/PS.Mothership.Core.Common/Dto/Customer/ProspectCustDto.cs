using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Template.Cust;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    [DataContract]
    public class ProspectCustDto
    {
        [DataMember]
        public Guid ProspectGuid { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public BusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

        [DataMember]
        public AnnualTurnoverEnum AnnualTurnoverKey { get; set; }

        [DataMember]
        public NumberEmployeesEnum NumberEmployeesKey { get; set; }

        [DataMember]
        public NoContactReasonEnum CallRestrictedReasonKey { get; set; }
    }
}
