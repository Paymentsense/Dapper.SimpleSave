using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse
{
    public class OfficerSearchRequestDto
    {
        public string Surname { get; set; }
        public IList<string> Forename { get; set; }
        public string PostTown { get; set; }
        public string OfficerType { get; set; }
        public bool IncludeResignedInd { get; set; }
        public string ContinuationKey { get; set; }
        public string CountryOfResidence { get; set; }
    }
}
