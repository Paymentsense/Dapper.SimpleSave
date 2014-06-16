using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class FhistItemDto
    {
        public string DocumentDescription { get; set; }
        public DateTime DocumentDate { get; set; }
        public FormTypeDto FormType { get; set; }
        public string DocBeingScanned { get; set; }
        public string ImageKey { get; set; }
    }
}
