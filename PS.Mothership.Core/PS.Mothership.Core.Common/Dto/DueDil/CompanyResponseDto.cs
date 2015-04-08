using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class CompanyResponseDto
    {
        public string Id { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime? IncorporationDate { get; set; }

        public DateTime? LatestAnnualReturnDate { get; set; }

        public DateTime? LatestAccountsDate { get; set; }

        public string CompanyType { get; set; }

        public string AccountsType { get; set; }

        public int? SicCode { get; set; }

        public string PreviousCompanyNamesUrl { get; set; }

        public string BankAccountsUrl { get; set; }

        public string ShareholdingsUrl { get; set; }

        public int? AccountsAccountStatus { get; set; }

        public int? AccountsAccountsFormat { get; set; }

        public decimal? AccountsAssetsCurrent { get; set; }

        public decimal? AccountsAssetsIntangible { get; set; }

        public decimal? AccountsAssetsNet { get; set; }

        public decimal? AccountsAssetsOtherCurrent { get; set; }

        public decimal? AccountsAssetsTangible { get; set; }

        public string AccountsUrl { get; set; }

        public decimal? AccountsAssetsTotalCurrent { get; set; }

        public decimal? AccountsAssetsTotalFix { get; set; }

        public decimal? AccountsAuditFees { get; set; }

        public decimal? AccountsBankOverdraft { get; set; }

        public decimal? AccountsBankOverdraftLtLoans { get; set; }

        public decimal? AccountsCapitalEmployed { get; set; }

        public decimal? AccountsCash { get; set; }

        public string AccountsConsolidated { get; set; }

        public decimal? AccountsCostOfSales { get; set; }

        public string AccountsCurrency { get; set; }

        public DateTime? AccountsDate { get; set; }

        public decimal? AccountsDepreciation { get; set; }

        public decimal? AccountsDirectorsEmoluments { get; set; }

        public decimal? AccountsDividendsPayable { get; set; }

        public decimal? AccountsGrossProfit { get; set; }

        public decimal? AccountsIncreaseInCash { get; set; }

        public decimal? AccountsInterestPayments { get; set; }

        public decimal? AccountsLiabilitiesCurrent { get; set; }

        public decimal? AccountsLiabilitiesLt { get; set; }

        public decimal? AccountsLiabilitiesMiscCurrent { get; set; }

        public decimal? AccountsLiabilitiesTotal { get; set; }

        public decimal? AccountsLtLoans { get; set; }

        public int? AccountsMonths { get; set; }

        public decimal? AccountsNetCashflowBeforeFinancing { get; set; }

        public decimal? AccountsNetCashflowFromFinancing { get; set; }

        public decimal? AccountsNetWorth { get; set; }

        public int? AccountsNoOfEmployees { get; set; }

        public decimal? AccountsOperatingProfits { get; set; }

        public decimal? AccountsOperationsNetCashflow { get; set; }

        public decimal? AccountsPaidUpEquity { get; set; }

        public decimal? AccountsPandlAccountReserve { get; set; }

        public decimal? AccountsPreTaxProfit { get; set; }

        public decimal? AccountsProfitAfterTax { get; set; }

        public decimal? AccountsRetainedProfit { get; set; }

        public decimal? AccountsRevaluationReserve { get; set; }

        public decimal? AccountsShareholderFunds { get; set; }

        public decimal? AccountsShortTermLoans { get; set; }

        public decimal? AccountsStock { get; set; }

        public decimal? AccountsSundryReserves { get; set; }

        public decimal? AccountsTaxation { get; set; }

        public decimal? AccountsTradeCreditors { get; set; }

        public decimal? AccountsTradeDebtors { get; set; }

        public decimal? AccountsTurnover { get; set; }

        public decimal? AccountsWages { get; set; }

        public decimal? AccountsWorkingCapital { get; set; }

        public string DirectorsUrl { get; set; }

        public string DirectorshipsUrl { get; set; }

        public int? DirectorshipsOpen { get; set; }

        public int? DirectorshipsOpenSecretary { get; set; }

        public int? DirectorshipsOpenDirector { get; set; }

        public int? DirectorshipsRetired { get; set; }

        public int? DirectorshipsRetiredSecretary { get; set; }

        public int? DirectorshipsRetiredDirector { get; set; }

        public string SubsidiariesUrl { get; set; }

        public string DocumentsUrl { get; set; }

        public DateTime? AccountsFilingDate { get; set; }

        public int? FtseA { get; set; }

        public int? MortgagePartialOutstandingCount { get; set; }

        public int? MortgagePartialPropertySatisfiedCount { get; set; }

        public int? MortgagePartialPropertyCount { get; set; }

        public string MortgagesUrl { get; set; }

        public int? MortgagesOutstandingCount { get; set; }

        public int? MortgagesSatisfiedCount { get; set; }

        public int? PreferenceShareholdingsCount { get; set; }

        public decimal? PreferenceSharesIssued { get; set; }

        public string RegAddress1 { get; set; }

        public string RegAddress2 { get; set; }

        public string RegAddress3 { get; set; }

        public string RegAddress4 { get; set; }

        public string RegAddressPostcode { get; set; }

        public string RegAreaCode { get; set; }

        public string RegPhone { get; set; }

        public string RegTps { get; set; }

        public string RegWeb { get; set; }

        public int? Sic2007Code { get; set; }

        public string TradingAddress1 { get; set; }

        public string TradingAddress2 { get; set; }

        public string TradingAddress3 { get; set; }

        public string TradingAddressPostcode { get; set; }

    }
}
