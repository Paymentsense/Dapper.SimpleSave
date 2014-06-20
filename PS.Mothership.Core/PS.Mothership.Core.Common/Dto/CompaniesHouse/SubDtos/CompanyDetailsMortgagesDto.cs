using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class CompanyDetailsMortgagesDto
    {
        public MortgageInd? MortgageInd { get; set; }
        public string NumMortCharges { get; set; }
        public string NumMortOutstanding { get; set; }
        public string NumMortPartSatisfied { get; set; }
        public string NumMortSatisfied { get; set; }
    }
}
