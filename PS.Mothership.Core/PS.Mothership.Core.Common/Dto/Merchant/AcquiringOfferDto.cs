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
        public OfferDto Offer { get; set; }

        [DataMember]
        public int SwitcherCurrentBankKey { get; set; }

        [DataMember]
        public int LocationTurnoverMonthly { get; set; }

        [DataMember]
        public int CredtCardTurnoverMonthly { get; set; }

        [DataMember]
        public int DebitCardTranxMonthly { get; set; }

        [DataMember]
        public decimal CreditCardRate { get; set; }

        [DataMember]
        public decimal DebitCardRate { get; set; }

        [DataMember]
        public decimal PremiumCardRate { get; set; }

        [DataMember]
        public decimal CommercialCardRate { get; set; }

        [DataMember]
        public decimal NTCJoiningFee { get; set; }

        [DataMember]
        public string AMEXAccountNumber { get; set; }

        [DataMember]
        public decimal MinimumCardTransactionValue { get; set; }

        [DataMember]
        public decimal MaximumCardTransactionValue { get; set; }

        [DataMember]
        public decimal AverageCardTransactionValue { get; set; }

        [DataMember]
        public bool AMEXNewAccount { get; set; }

        [DataMember]
        public int MCCKey { get; set; }

        [DataMember]
        public decimal PCIComplianceFee { get; set; }

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
        public GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

        [DataMember]
        public int MmscKey { get; set; }

        [DataMember]
        public int AuthorisationFeeKey { get; set; }
    }
}
