using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
    [DataContract]
    public class IdentityResultBlockDto
    {
        [DataMember]
        public string AuthenticationIndex { get; set; }
        [DataMember]
        public string AuthenticationDecision { get; set; }
        [DataMember]
        public string AuthIndexText { get; set; }
        [DataMember]
        public int IDandLocDataAtCLPrimDataItems { get; set; }
        [DataMember]
        public int IDandLocDataAtCLPrimDataSources { get; set; }
        [DataMember]
        public string IDandLocDataAtCLStartDateOldestPrim { get; set; }
        [DataMember]
        public int IDandLocDataAtCLNumSecDataItems { get; set; }
        [DataMember]
        public int IDandLocDataAtCLNumSecDataSources { get; set; }
        [DataMember]
        public int LocDataOnlyAtCLocPrimDataItems { get; set; }
        [DataMember]
        public int LocDataOnlyAtCLocPrimDataSources { get; set; }
        [DataMember]
        public string LocDataOnlyAtCLocStartDateOldestPrim { get; set; }
        [DataMember]
        public int LocDataOnlyAtCLocNumSecDataItems { get; set; }
        [DataMember]
        public int LocDataOnlyAtCLocSecDataSources { get; set; }
        [DataMember]
        public string LocDataOnlyAtCLocStartDateOldestSec { get; set; }
        [DataMember]
        public int IDandLocDataAtPLPrimDataItems { get; set; }
        [DataMember]
        public int IDandLocDataAtPLPrimDataSources { get; set; }
        [DataMember]
        public int IDandLocDataAtPLSecDataItems { get; set; }
        [DataMember]
        public int IDandLocDataAtPLSecDataSources { get; set; }
        [DataMember]
        public int LocDataOnlyAtPLocPrimDataItems { get; set; }
        [DataMember]
        public int LocDataOnlyAtPLocPrimDataSources { get; set; }
        [DataMember]
        public int LocDataOnlyAtPLocSecDataItems { get; set; }
        [DataMember]
        public int LocDataOnlyAtPLocSecDataSources { get; set; }
        [DataMember]
        public int DataMatchCountsAgeMatchesToPrimSource { get; set; }
        [DataMember]
        public int DataMatchCountsAgeMatchToSecSource { get; set; }
        [DataMember]
        public int DataMatchCountsTimeAtCLMtchPrimSource { get; set; }
        [DataMember]
        public int ReturnedHRPCount { get; set; }
    }
}
