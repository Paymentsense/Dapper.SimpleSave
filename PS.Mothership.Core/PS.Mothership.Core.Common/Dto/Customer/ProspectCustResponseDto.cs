using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Enums;

namespace PS.Mothership.Core.Common.Dto.Customer
{
    /// <summary>
    ///     Prospsect customer response dto
    /// </summary>
    [DataContract]
    public class ProspectCustResponseDto : IStatus
    {        

        [DataMember]
        public ProspectCustDto ProspectCust { get; set; }

        [DataMember]
        public StatusType StatusType { get; set; }        

        [DataMember]
        public string Message { get; set; }        
    }
}
