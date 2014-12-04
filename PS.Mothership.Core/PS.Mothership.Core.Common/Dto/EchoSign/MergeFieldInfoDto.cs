using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class MergeFieldInfoDto
    {
        [DataMember]
        public string DefaultValue { get; set; }
        
        [DataMember]
        public string FieldName { get; set; }
    }
}
