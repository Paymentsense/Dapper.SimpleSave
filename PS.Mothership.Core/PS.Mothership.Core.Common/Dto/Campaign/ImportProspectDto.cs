namespace PS.Mothership.Core.Common.Dto.Campaign
{
    /// <summary>
    /// Represents a lead coming in from a website and its associated information
    /// </summary>
    public class ImportProspectDto
    {
        public int VCOL { get; set; }
        public int Submitted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string CID { get; set; }
        public string MatchType { get; set; }
        public string Network { get; set; }
        public string Creative { get; set; }
        public string Keyword { get; set; }
        public string Placement { get; set; }
        public string Target { get; set; }
        public string Referrer { get; set; }
        public string Notes { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
    }
}
