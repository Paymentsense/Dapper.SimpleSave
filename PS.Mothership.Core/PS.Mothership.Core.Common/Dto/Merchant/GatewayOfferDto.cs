using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class GatewayOfferDto
    {
        [DataMember]
        public Guid GatewayOfferGuid { get; set; }

        [DataMember]
        public bool IsBilledYearly { get; set; }

        [DataMember]
        public decimal PeriodicCharge { get; set; }

        [DataMember]
        public int FreeTransactionCount { get; set; }

        [DataMember]
        public decimal OveragePerTransactionCharge { get; set; }

        [DataMember]
        public decimal FreeProcessingValue { get; set; }

        [DataMember]
        public decimal OverageProcessingPercent { get; set; }

        [DataMember]
        public decimal TransactionChargeCap { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public GenGatewayEnum GatewayKey { get; set; }

        [DataMember]
        public Guid BasedOnGatewayTariffGuid { get; set; }

        [DataMember]
        public Guid GatewayAccountGuid { get; set; }

    }
}
