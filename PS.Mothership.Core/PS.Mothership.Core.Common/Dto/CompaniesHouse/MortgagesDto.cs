using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class MortgagesDto
    {
        public int CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public int NumMortCharges { get; set; }
        public int NumMortOutstanding { get; set; }
        public int NumMortPartSatisfied { get; set; }
        public int NumMortSatisfied { get; set; }
        public int SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public ChargeDto Charge { get; set; }
    }
}
