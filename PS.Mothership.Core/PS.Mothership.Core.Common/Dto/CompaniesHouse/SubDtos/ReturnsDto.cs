using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class ReturnsDto
    {
        public DateTime NextDueDate { get; set; }
        public string Overdue { get; set; }
        public DateTime LastMadeUpDate { get; set; }
        public bool DocumentAvailable { get; set; }
    }
}
