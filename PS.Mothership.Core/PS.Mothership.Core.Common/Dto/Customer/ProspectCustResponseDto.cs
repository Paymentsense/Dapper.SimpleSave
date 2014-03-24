using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    /// <summary>
    ///     Prospsect customer response dto
    /// </summary>
    [DataContract]
    public class ProspectCustResponseDto
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public ProspectCustDto ProspectCust { get; set; }
    }
}
