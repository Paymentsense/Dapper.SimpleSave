using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Experian
{
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
}
