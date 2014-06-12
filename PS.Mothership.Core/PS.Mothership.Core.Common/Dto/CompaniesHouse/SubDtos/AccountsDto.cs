using System;

namespace PS.Mothership.Core.Common.Dto.CompaniesHouse.SubDtos
{
    public class AccountsDto
    {
        public DateTime AccountRefDate { get; set; }
        public DateTime AccountRefDay { get; set; }
        public DateTime AccountRefMonth { get; set; }
        public DateTime NextDueDate { get; set; }
        public string Overdue { get; set; }
        public DateTime LastMadeUpDate { get; set; }
        public string AccountCategory { get; set; }
        public string DocumentAvailable { get; set; }
    }
}
