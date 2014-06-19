using System;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyDetailsDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public bool HasInconsistencies { get; set; }
        public bool HasInconsistenciesSpecified { get; set; }
        public RegAddressDto RegAddress { get; set; }
        public string CompanyCategory { get; set; }
        public string CompanyStatus { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool RegistrationDateSpecified { get; set; }
        public object RegDateType { get; set; }
        public DateTime DissolutionDate { get; set; }
        public bool DissolutionDateSpecified { get; set; }
        public DateTime IncorporationDate { get; set; }
        public bool IncorporationDateSpecified { get; set; }
        public DateTime ClosureDate { get; set; }
        public bool ClosureDateSpecified { get; set; }
        public AccountsDto Accounts { get; set; }
        public ReturnsDto Returns { get; set; }
        public MortgagesDto Mortgages { get; set; }
        public SicCodesDto SicCodes { get; set; }
        public DateTime LastFullMemDate { get; set; }
        public bool LastFullMemDateSpecified { get; set; }
        public DateTime LastBulkShareDate { get; set; }
        public bool LastBulkShareDateSpecified { get; set; }
        public DateTime WeededDate { get; set; }
        public bool WeededDateSpecified { get; set; }
        public bool HasUKestablishment { get; set; }
        public bool HasAppointments { get; set; }
        public bool InLiquidation { get; set; }
        public LimitedPartnershipsDto LimitedPartnerships { get; set; }
        public List<PreviousNameDto> PreviousNames { get; set; }
    }
}
