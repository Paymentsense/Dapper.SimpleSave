using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class CompanyDetailsDto
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string HasInconsistencies { get; set; }
        public RegAddressDtos RegAddress { get; set; }
        public string CompanyCategory { get; set; }
        public string CompanyStatus { get; set; }
        public string CountryofOrigin { get; set; }
        public string RegistrationDate { get; set; }
        //TODO Enum
        public string RegDateType { get; set; }
        public string DissolutionDate { get; set; }
        public string IncorporationDate { get; set; }
        public string ClosureDate { get; set; }
        public PreviousNameDto PreviousName { get; set; }
        public AccountsDto Accounts { get; set; }
        public ReturnsDto Returns { get; set; }
        public MortgagesDto Mortgages { get; set; }
        public SicCodesDto SicCodes { get; set; }
        public string LastFullMemDate { get; set; }
        public string LastBulkShareDate { get; set; }
        public string WeededDate { get; set; }
        //TODO Enum
        public string HasUkEstablishmentInfo { get; set; }
        //TODO Enum
        public string HasAppointments { get; set; }
        //TODO Enum
        public string InLiquidation { get; set; }
        public LimitedPartnershipsDto LimitedPartnerships { get; set; }
    }
}
