namespace PS.Mothership.Core.Common.Dto
{
    public class CaseSummaryDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public bool CanEdit { get; set; }
    }
}