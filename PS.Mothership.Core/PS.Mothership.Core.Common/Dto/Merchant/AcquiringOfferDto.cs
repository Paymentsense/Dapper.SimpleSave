using System;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;
using PS.Mothership.Core.Common.Template.Opp;
using PS.Mothership.Core.Common.Template.Prod;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class AcquiringOfferDto
    {
        [DataMember]
        public Guid OfferGuid { get; set; }

        [DataMember]
        public int CardTransactionPerAnnum { get; set; }

        [DataMember]
        public int DebitCardTransactionPercentage { get; set; }

        [DataMember]
        public int CreditCardTurnoverMonthly { get; set; }

        [DataMember]
        public int DebitCardTransactionMonthly { get; set; }

        [DataMember]
        public double CreditCardRate { get; set; }

        [DataMember]
        public double DebitCardRate { get; set; }

        [DataMember]
        public double NTCJoiningFee { get; set; }

        [DataMember]
        public double AverageCardTransactionValue { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public ProdAcquirerEnum AcquirerKey { get; set; }

        [DataMember]
        public OppTypeOfTransactionEnum TypeOfTransactionKey { get; set; }

        [DataMember]
        public int CustomerTypeKey { get; set; }

        [DataMember]
        public int ContractLengthKey { get; set; }

        [DataMember]
        public string ContractLengthDescription { get; set; }

        [DataMember]
        public int MinimumMonthlyServiceChargeKey { get; set; }

        [DataMember]
        public int AuthorisationFeeKey { get; set; }

        [DataMember]
        public decimal DiscountPlan { get; set; }
    }
}
