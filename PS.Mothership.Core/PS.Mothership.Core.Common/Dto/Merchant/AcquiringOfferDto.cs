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
        public int SwitcherCurrentBankKey { get; set; }

        [DataMember]
        public int LocationTurnoverMonthly { get; set; }

        [DataMember]
        public int CredtCardTurnoverMonthly { get; set; }

        [DataMember]
        public int DebitCardTranxMonthly { get; set; }

        [DataMember]
        public double CreditCardRate { get; set; }

        [DataMember]
        public double DebitCardRate { get; set; }

        [DataMember]
        public double PremiumCardRate { get; set; }

        [DataMember]
        public double CommercialCardRate { get; set; }

        [DataMember]
        public double NTCJoiningFee { get; set; }

        [DataMember]
        public string AMEXAccountNumber { get; set; }

        [DataMember]
        public double MinimumCardTransactionValue { get; set; }

        [DataMember]
        public double MaximumCardTransactionValue { get; set; }

        [DataMember]
        public double AverageCardTransactionValue { get; set; }

        [DataMember]
        public bool AMEXNewAccount { get; set; }

        [DataMember]
        public int MCCKey { get; set; }

        [DataMember]
        public double PCIComplianceFee { get; set; }

        [DataMember]
        public GenRecStatusEnum RecStatusKey { get; set; }

        [DataMember]
        public ProdAcquirerEnum AcquirerKey { get; set; }

        [DataMember]
        public int TypeOfTransactionKey { get; set; }

        [DataMember]
        public Guid EquipmentOfferGuid { get; set; }

        [DataMember]
        public int CustomerTypeKey { get; set; }

        [DataMember]
        public int ContractLengthKey { get; set; }

        //[DataMember]
        //public GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

        [DataMember]
        public int MmscKey { get; set; }

        [DataMember]
        public int AuthorisationFeeKey { get; set; }
    }
}
