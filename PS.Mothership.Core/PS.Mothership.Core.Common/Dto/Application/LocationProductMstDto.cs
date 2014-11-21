using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Application
{
    [DataContract]
    public class LocationProductMstDto
    {
        [DataMember]
        public Guid LocationProductGuid { get; set; }

        [DataMember]
        public Guid LocationGuid { get; set; }

        [DataMember]
        public Guid OpportunityGuid { get; set; }

        [DataMember]
        public Guid ContactGuid { get; set; }

        [DataMember]
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public int MccKey { get; set; }

        [DataMember]
        public int LocationNumber { get; set; }

        [DataMember]
        public int PremisesOwnershipTypeKey { get; set; }

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
        public int DepositDaysOfDelivery { get; set; }

        [DataMember]
        public int AdvancedPaymentPercentOfSales { get; set; }

        [DataMember]
        public int AdvancedPaymentDaysToDelivery { get; set; }

        [DataMember]
        public int MembershipsPaymentPercentOfSales { get; set; }

        [DataMember]
        public int RefundDaysKey { get; set; }

        [DataMember]
        public int Delivery0To7Days { get; set; }

        [DataMember]
        public int Delivery8To14Days { get; set; }

        [DataMember]
        public int Delivery15To30Days { get; set; }

        [DataMember]
        public int Delivery30PlusDays { get; set; }

        [DataMember]
        public string EcommWebUrl { get; set; }

        [DataMember]
        public int CurencyCodeKey { get; set; }

        [DataMember]
        public int StatementDeleiveryKey { get; set; }

        [DataMember]
        public int SwitcherCurrentBankKey { get; set; }

        [DataMember]
        public string DeposityAccount { get; set; }

        [DataMember]
        public string DeposityAccountSortCode { get; set; }

        [DataMember]
        public string FessAccount { get; set; }

        [DataMember]
        public string FessAccountSortCode { get; set; }

        [DataMember]
        public double SatementDeliveryKeyMonthly { get; set; }

        [DataMember]
        public string AcquireLocationMID { get; set; }

        [DataMember]
        public bool AreWarrantPaymentsTaken { get; set; }

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

        [DataMember]
        public DateTimeOffset UpdateDate { get; set; }

        [DataMember]
        public Guid UpdateSessionGuid { get; set; }

    }
}
