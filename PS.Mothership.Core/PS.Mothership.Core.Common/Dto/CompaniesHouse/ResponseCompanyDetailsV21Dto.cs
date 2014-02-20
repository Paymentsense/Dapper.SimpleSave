using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    [DataContract(Name = "CompanyDetails", Namespace = "http://xmlgw.companieshouse.gov.uk/v1-0")]
    public class ResponseCompanyDetailsV21Dto
    {
        public ResponseCompanyDetailsV21Dto() { }

        [DataMember(Name = "CompanyName", IsRequired = true, Order = 1)]
        public string CompanyName { get; set; }

        [DataMember(Name = "CompanyNumber", IsRequired = true, Order = 2)]
        public string CompanyNumber { get; set; }

        [DataMember(Name = "HasInconsistencies", IsRequired = false, Order = 3)]
        public string HasInconsistencies { get; set; }

        [DataMember(Name = "RegAddress", IsRequired = true, Order = 4)]
        public ResponseRegAddressDto RegAddress { get; set; }

        [DataMember(Name = "CompanyCategory", IsRequired = true, Order = 5)]
        public string CompanyCategory { get; set; }

        [DataMember(Name = "CompanyStatus", IsRequired = true, Order = 6)]
        public string CompanyStatus { get; set; }

        [DataMember(Name = "CountryOfOrigin", IsRequired = true, Order = 7)]
        public string CountryOfOrigin { get; set; }

        [DataMember(Name = "RegistrationDate", IsRequired = false, Order = 8)]
        public string RegistrationDate { get; set; }

        [DataMember(Name = "RegDateType", IsRequired = true, Order = 9)]
        public string RegDateType { get; set; }

        [DataMember(Name = "DissolutionDate", IsRequired = false, Order = 10)]
        public string DissolutionDate { get; set; }

        [DataMember(Name = "IncorporationDate", IsRequired = false, Order = 11)]
        public string IncorporationDate { get; set; }

        [DataMember(Name = "ClosureDate", IsRequired = false, Order = 12)]
        public string ClosureDate { get; set; }

        [DataMember(Name = "PreviousNames", IsRequired = false, Order = 13)]
        public ResponsePreviousNamesDto PreviousNames { get; set; }

        [DataMember(Name = "Accounts", IsRequired = true, Order = 14)]
        public ResponseAccountsDto Accounts { get; set; }

        [DataMember(Name = "Returns", IsRequired = true, Order = 15)]
        public ResponseReturnsDto Returns { get; set; }

        [DataMember(Name = "Mortgages", IsRequired = false, Order = 16)]
        public ResponseMortgagesDto Mortgages { get; set; }

        [DataMember(Name = "SICCodes", IsRequired = true, Order = 17)]
        public ResponseSICCodesDto SICCodes { get; set; }

        [DataMember(Name = "LastFullMemDate", IsRequired = false, Order = 18)]
        public string LastFullMemDate { get; set; }

        [DataMember(Name = "LastBulkShareDate", IsRequired = false, Order = 19)]
        public string LastBulkShareDate { get; set; }

        [DataMember(Name = "WeededDate", IsRequired = false, Order = 20)]
        public string WeededDate { get; set; }

        [DataMember(Name = "HasUKestablishment", IsRequired = true, Order = 21)]
        public string HasUKestablishment { get; set; }

        [DataMember(Name = "HasAppointments", IsRequired = true, Order = 22)]
        public string HasAppointments { get; set; }

        [DataMember(Name = "InLiquidation", IsRequired = true, Order = 23)]
        public string InLiquidation { get; set; }

        [DataMember(Name = "LimitedPartnerships", IsRequired = false, Order = 24)]
        public ResponseLimitedPartnershipsDto LimitedPartnerships { get; set; }
    }
}
