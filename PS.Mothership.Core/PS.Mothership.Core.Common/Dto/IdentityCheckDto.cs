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
        public PrivateInformationType PersonalInformation { get; set; }
        [DataMember]
        public CurrentAddressType CurrentAddress { get; set; }
        [DataMember]
        public PreviousAddressType PreviousAddress { get; set; }
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
    }

    [DataContract]
    public class PrivateInformationType
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
    public class CurrentAddressType
    {
        [DataMember]
        public string HouseNumber { get; set; }
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
    public class PreviousAddressType
    {
        [DataMember]
        public string HouseNumber { get; set; }
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
}
