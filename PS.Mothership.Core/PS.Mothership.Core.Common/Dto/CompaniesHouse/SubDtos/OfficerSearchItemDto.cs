using System.Collections.Generic;
using PS.Mothership.Core.Common.Enums.CompaniesHouse;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class OfficerSearchItemDto : OfficerSearchItemBaseDto
    {
        public string PersonId {get; set;}
        public SearchMatch SearchMatch {get; set;}
        public bool SearchMatchSpecified {get; set;}
        public List<OfficerSearchItemBaseDto> DuplicateOfficers { get; set; }
    }
}
