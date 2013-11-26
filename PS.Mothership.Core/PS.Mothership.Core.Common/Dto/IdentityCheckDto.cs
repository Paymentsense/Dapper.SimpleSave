using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    [DataContract]
    public class IdentityCheckRequestDto
    {
        [DataMember]
        public PrivateInformationTypeDto PersonalInformation { get; set; }
        [DataMember]
        public CurrentAddressTypeDto CurrentAddress { get; set; }
        [DataMember]
        public PreviousAddressTypeDto PreviousAddress { get; set; }
        [DataMember]
        public bool CreateDocument { get; set; }

    }

    [DataContract]
    public class IdentityCheckResponseDto
    {
        [DataMember]
        public string AuthenticationIndex { get; set; }
        [DataMember]
        public string ExperianReferenceNumber { get; set; }
        [DataMember]
        public bool DidVerificationErrorOccur { get; set; }
        [DataMember]
        public string CustomerNo { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public byte[] FileBytes { get; set; }
        [DataMember]
        public IdentityResultBlockDto ResultsBlock { get; set; }
    }


    [DataContract]
    public class PrivateInformationTypeDto
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ForeName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public int DateOfBirthDay { get; set; }
        [DataMember]
        public int DateOfBirthMonth { get; set; }
        [DataMember]
        public int DateOfBirthYear { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
    }

    [DataContract]
    public class CurrentAddressTypeDto
    {
        [DataMember]
        public string HouseNumber { get; set; }
        [DataMember]
        public string HouseName { get; set; }
        /// <summary>
        /// this is the street and must be supplied. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address1 { get; set; }
        /// <summary>
        /// this is the district. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address2 { get; set; }
        /// <summary>
        /// this is the post town and must be supplied. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address3 { get; set; }
        /// <summary>
        /// this is the county. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address4 { get; set; }
        [DataMember]
        public string PostCode { get; set; }

        /// <summary>
        /// first date of occupancy in CCYY-MM-DD format
        /// </summary>
        [DataMember]
        public DateTime ResidentFrom { get; set; }
        /// <summary>
        /// last date of occupancy in CCYY-MM-DD format.
        /// </summary>
        [DataMember]
        public DateTime ResidentTo { get; set; }
    }

    [DataContract]
        public class PreviousAddressTypeDto
    {
        [DataMember]
        public string HouseNumber { get; set; }
        [DataMember]
        public string HouseName { get; set; }
        /// <summary>
        /// this is the street and must be supplied. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address1 { get; set; }
        /// <summary>
        /// this is the district. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address2 { get; set; }
        /// <summary>
        /// this is the post town and must be supplied. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address3 { get; set; }
        /// <summary>
        /// this is the county. You can use any alphanumeric character
        /// </summary>
        [DataMember]
        public string Address4 { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public DateTime ResidentFrom { get; set; }
        [DataMember]
        public DateTime ResidentTo { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
    }

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
