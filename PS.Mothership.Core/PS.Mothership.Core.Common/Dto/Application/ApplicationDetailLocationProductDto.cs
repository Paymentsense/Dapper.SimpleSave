using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class ApplicationDetailLocationProductDto
    {
        [DataMember]
        public Guid LocationProductGuid { get; set; }

        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public OfferDto CurrentOffer { get; set; }

        [DataMember]
        public ContactDto Contact { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public int MccKey { get; set; }

        [DataMember]
        public int LocationNumber { get; set; }

        [DataMember]
        public FullAddressDto BillToAddress { get; set; }

        [DataMember]
        public FullAddressDto ShippingAddress { get; set; }

        //[DataMember]
        //public int PremisesOwnershipTypeKey { get; set; }

        //TODO: do we need this parameter?
        [DataMember]
        public DateTime PremisesOpenDate { get; set; }

        [DataMember]
        public double TotalAnnualSales { get; set; }

        [DataMember]
        public int SalesCardPresentPercent { get; set; }

        [DataMember]
        public int SalesInternetPercent { get; set; }

        [DataMember]
        public int SalesMailOrderPercent { get; set; }

        [DataMember]
        public int B2BPaymentsPercent { get; set; }

        [DataMember]
        public int DepositRequiredPercent { get; set; }

        [DataMember]
        public int DepositPercentOfTransaction { get; set; }

        [DataMember]
        public int DepositDaysToDelivery { get; set; }

        [DataMember]
        public int AdvancedPaymentPercentOfSales { get; set; }

        [DataMember]
        public int AdvancedPaymentDaysToDelivery { get; set; }

        [DataMember]
        public int MembershipsPaymentPercentOfSales { get; set; }

        [DataMember]
        public int MembershipsAverageLengthMonths { get; set; }

        [DataMember]
        public int RefundDaysKey { get; set; }

        [DataMember]
        public int Delivery0To7DaysPercent { get; set; }

        [DataMember]
        public int Delivery8To14DaysPercent { get; set; }

        [DataMember]
        public int Delivery15To30DaysPercent { get; set; }

        [DataMember]
        public int Delivery30PlusDaysPercent { get; set; }

        [DataMember]
        public string EcommWebUrl { get; set; }

        [DataMember]
        public int CurrencyCodeKey { get; set; }

        [DataMember]
        public int StatementDeliveryKey { get; set; }

        [DataMember]
        public int SwitcherCurrentBankKey { get; set; }

        [DataMember]
        public string DeposityAccount { get; set; }

        [DataMember]
        public string DeposityAccountSortCode { get; set; }

        [DataMember]
        public string FeesAccount { get; set; }

        [DataMember]
        public string FeesAccountSortCode { get; set; }

        [DataMember]
        public double SatementDeliveryFeeMonthly { get; set; }

        [DataMember]
        public string AcquirerLocationMID { get; set; }

        [DataMember]
        public bool AreWarrantyPaymentsTaken { get; set; }

        [DataMember]
        public bool AreAutomaticRenewelsPerformed { get; set; }

        [DataMember]
        public double AverageGoodsReturnedPercent { get; set; }

        [DataMember]
        public int LocationTurnoverMonthly { get; set; }

        [DataMember]
        public float PremiumCardRate { get; set; }

        [DataMember]
        public float CommercialCardRate { get; set; }

        [DataMember]
        public string AmexAccountNumber { get; set; }

        [DataMember]
        public float MinimumCardTransactionValue { get; set; }

        [DataMember]
        public float MaximumCardTransactionValue { get; set; }


    }
}
