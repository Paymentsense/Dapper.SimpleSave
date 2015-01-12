using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class GatewayContractLnkDto
    {
        [DataMember]
        public Guid GatewayContractGuid { get; set; }

        [DataMember]
        public Guid GatewayAccountGuid { get; set; }

        [DataMember]
        public Guid GatewayTariffGuid { get; set; }

        [DataMember]
        public string TariffName { get; set; }

        [DataMember]
        public string TariffShortName { get; set; }

        [DataMember]
        public DateTime EffectiveDate { get; set; }

        [DataMember]
        public int TermMonths { get; set; }

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
        public DateTimeOffset? InactivateDate { get; set; }

        [DataMember]
        public Guid? InactivateSessionGuid { get; set; }

        [DataMember]
        public Guid BillingProfileGuid { get; set; }

        [DataMember]
        public int V1GatewayContId { get; set; }
    
    }
}
