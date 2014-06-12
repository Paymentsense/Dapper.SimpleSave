using System;
using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyDetailsDto
    {
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public string HasInconsistencies { get; set; }
        public RegAddressDtos RegAddress { get; set; }
        public string CompanyCategory { get; set; }
        public string CompanyStatus { get; set; }
        public string CountryofOrigin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public RegDateType RegDateType { get; set; }
        public DateTime DissolutionDate { get; set; }
        public DateTime IncorporationDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public PreviousNameDto PreviousName { get; set; }
        public AccountsDto Accounts { get; set; }
        public ReturnsDto Returns { get; set; }
        public MortgagesDto Mortgages { get; set; }
        public SicCodesDto SicCodes { get; set; }
        public DateTime LastFullMemDate { get; set; }
        public DateTime LastBulkShareDate { get; set; }
        public DateTime WeededDate { get; set; }
        public HasUkEstablishmentInfo HasUkEstablishmentInfo { get; set; }
        public HasAppointments HasAppointments { get; set; }
        public InLiquidation InLiquidation { get; set; }
        public LimitedPartnershipsDto LimitedPartnerships { get; set; }
    }
}
