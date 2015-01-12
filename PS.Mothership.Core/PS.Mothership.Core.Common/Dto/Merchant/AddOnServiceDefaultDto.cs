using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AddOnServiceDefaultDto
    {
        [DataMember]
        public Guid AddonServiceDefaultTrnGuid { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public int TypeOfTransactionKey { get; set; }

        [DataMember]
        public int CustomerTypeKey { get; set; }

        [DataMember]
        public int CalculatorVersionKey { get; set; }

        [DataMember]
        public Guid AddOnServicePriceGuid { get; set; }
    }
}
