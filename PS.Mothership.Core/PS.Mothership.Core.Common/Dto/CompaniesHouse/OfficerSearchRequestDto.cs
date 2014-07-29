using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerSearchRequestDto
    {
        public string Surname {get; set;}
        public string PostTown {get; set;}
        public OfficerType OfficerType {get; set;}
        public string CountryOfResidence {get; set;}
        public bool? IncludeResignedInd {get; set;}
        public string ContinuationKey {get; set;}
        public List<string> Forename { get; set; }
    }
}
