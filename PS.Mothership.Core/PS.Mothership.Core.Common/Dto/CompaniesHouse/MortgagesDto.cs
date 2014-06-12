using PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class MortgagesDto
    {
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string NumMortCharges { get; set; }
        public string NumMortOutstanding { get; set; }
        public string NumMortPartSatisfied { get; set; }
        public string NumMortSatisfied { get; set; }
        public string SearchRows { get; set; }
        public string ContinuationKey { get; set; }
        public ChargeDto Charge { get; set; }
    }
}
