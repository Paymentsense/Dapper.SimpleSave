using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Campaign
{
    /// <summary>
    /// Represents a lead coming in from a website and its associated information
    /// </summary>
    [DataContract]
    public class ImportProspectDto
    {
        [DataMember]
        public int VCOL { get; set; }
        
        [DataMember]
        public int Submitted { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string LocatorID { get; set; }

        [DataMember]
        public string CID { get; set; }

        [DataMember]
        public string cPage { get; set; }

        [DataMember]
        public string MSAction { get; set; }

        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public string MatchType { get; set; }

        [DataMember]
        public string Network { get; set; }

        [DataMember]
        public string Creative { get; set; }

        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public string Placement { get; set; }

        [DataMember]
        public string Target { get; set; }

        [DataMember]
        public string Referrer { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public string Key1 { get; set; }

        [DataMember]
        public string Key2 { get; set; }

        [DataMember]
        public GenCountryEnum CountryKey { get; set; }
    }
}
