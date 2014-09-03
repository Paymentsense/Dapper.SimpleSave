using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    /// <summary>
    ///     Prospsect customer response dto
    /// </summary>
    [DataContract]
    public class ProspectResponseDto 
    {        
        [DataMember]
        public ProspectDto Prospect { get; set; }

        [DataMember]
        public StatusType StatusType { get; set; }        

        [DataMember]
        public string Message { get; set; }        
    }
}
