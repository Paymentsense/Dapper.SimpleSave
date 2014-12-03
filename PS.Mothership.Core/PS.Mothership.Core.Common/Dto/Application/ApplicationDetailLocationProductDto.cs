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
        public Guid MerchantGuid { get; set; }

        [DataMember]
        public OfferDto CurrentOffer { get; set; }

        //Contact info section
        [DataMember]
        public ContactDto Contact { get; set; }

        //Business Info section
        [DataMember]
        public string TradingName { get; set; }
        [DataMember]
        public string EcommWebUrl { get; set; }
        [DataMember]
        public int StatementDeliveryKey { get; set; }
        [DataMember]
        public int BusinessCategoryKey { get; set; }
        [DataMember]
        public int MccKey { get; set; }
        [DataMember]
        public string ProductsServicesSold { get; set; }

        //TODO: Where is this filed usd?
        [DataMember]
        public int LocationNumber { get; set; }
        [DataMember]
        public FullAddressDto BillToAddress { get; set; }
        [DataMember]
        public FullAddressDto ShippingAddress { get; set; }
        //TODO: do we need this parameter?
        [DataMember]
        public DateTime PremisesOpenDate { get; set; }

        //Transaction Details section
        [DataMember]
        public double TotalAnnualSales { get; set; }
        [DataMember]
        public float MinimumCardTransactionValue { get; set; }
        [DataMember]
        public float MaximumCardTransactionValue { get; set; }
        [DataMember]
        public bool AutomaticRenewalsPerformed { get; set; }
        [DataMember]
        public int CurrencyCodeKey { get; set; }

        //Bank Info section
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string BacsName { get; set; }
        [DataMember]
        public string AccountHeldFor { get; set; }
        [DataMember]
        public string IBAN { get; set; }
        [DataMember]
        public int SettlementCurrencyKey { get; set; }
        [DataMember]
        public string DeposityAccount { get; set; }
        [DataMember]
        public string DeposityAccountSortCode { get; set; }
        [DataMember]
        public string FeesAccount { get; set; }
        [DataMember]
        public string FeesAccountSortCode { get; set; }

        //Method of Sales section
        [DataMember]
        public int SalesMethodKey { get; set; }
        [DataMember]
        public int SalesCardPresentPercent { get; set; } //Chip & Pin
        [DataMember]
        public int SalesMailOrderPercent { get; set; }//CNP = Card Not Present
        [DataMember]
        public int SalesInternetPercent { get; set; }
        [DataMember]
        public int B2BPaymentsPercent { get; set; }


        //Refunds section
        [DataMember]
        public int RefundDaysKey { get; set; }


        //Delivery section
        [DataMember]
        public bool AdvancePaymentsTaken { get; set; }
        [DataMember]
        public int AdvancePaymentPercentOfSales { get; set; }
        [DataMember]
        public int AdvancePaymentDaysToDelivery { get; set; }
        [DataMember]
        public int Delivery0To7DaysPercent { get; set; }
        [DataMember]
        public int Delivery8To14DaysPercent { get; set; }
        [DataMember]
        public int Delivery15To30DaysPercent { get; set; }
        [DataMember]
        public int Delivery30PlusDaysPercent { get; set; }
        [DataMember]
        public int DeliveryWeeks { get; set; }

        //Deposits section 
        [DataMember]
        public bool DepositRequired { get; set; }
        [DataMember]
        public int DepositRequiredPercent { get; set; }
        [DataMember]
        public int DepositPercentOfTransaction { get; set; }
        [DataMember]
        public int DepositDaysToDelivery { get; set; }


        //membership/Subscription section
        [DataMember]
        public bool MembershipTaken { get; set; }
        [DataMember]
        public int MembershipCtoPercent { get; set; }
        [DataMember]
        public int MembershipsAverageLengthMonths { get; set; }

        //Guarentees/extended warranties section
        [DataMember]
        public bool WarrantyTaken { get; set; }
        [DataMember]
        public int WarrantyCtoPercent { get; set; }
        [DataMember]
        public int WarrantyAverageLength { get; set; }


        [DataMember]
        public int SwitcherCurrentBankKey { get; set; }



        [DataMember]
        public double SatementDeliveryFeeMonthly { get; set; }

        [DataMember]
        public string AcquirerLocationMID { get; set; }



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




    }
}
