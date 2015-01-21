using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class GatewayTariffDto
    {
        [DataMember]
        public Guid GatewayTariffGuid { get; set; }

        [DataMember]
        public GenGatewayEnum GatewayKey { get; set; }

        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsBilledYearly { get; set; }

        [DataMember]
        public double PeriodicCharge { get; set; }

        [DataMember]
        public int FreeTransactionCount { get; set; }

        [DataMember]
        public double OveragePerTransactionCharge { get; set; }

        [DataMember]
        public double FreeProcessingValue { get; set; }

        [DataMember]
        public double OverageProcessingPercent { get; set; }

        [DataMember]
        public double TransactionChargeCap { get; set; }

        [DataMember]
        public string Benefit1 { get; set; }

        [DataMember]
        public string Benefit2 { get; set; }

        [DataMember]
        public string Benefit3 { get; set; }

        [DataMember]
        public string Benefit4 { get; set; }

        [DataMember]
        public string Benefit5 { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public int? V1EcomTariffId { get; set; }

        [DataMember]
        public int CountryKey { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
