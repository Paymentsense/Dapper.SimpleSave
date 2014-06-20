using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class FhistItemDto
    {
        public DateTime? DocumentDate { get; set; }
        public string FormType { get; set; }
        public bool? DocBeingScanned { get; set; }
        public string ImageKey { get; set; }
        public List<string> DocumentDesc { get; set; }
        public List<FhistChildDocDto> ChildDocument { get; set; }
    }
}
