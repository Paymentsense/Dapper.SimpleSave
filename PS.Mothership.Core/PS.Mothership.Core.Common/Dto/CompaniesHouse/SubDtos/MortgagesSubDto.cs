using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class MortgagesSubDto
    {
        public MortgageInd MortgageInd { get; set; }
        public int NumMortCharges { get; set; }
        public int NumMortOutstanding { get; set; }
        public int NumMortPartSatisfied { get; set; }
        public int NumMortSatisfied { get; set; }
    }
}
