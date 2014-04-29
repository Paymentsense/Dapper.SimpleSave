using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class DocumentsInfoDto
    {
        [DataMember]
        public string DocumentId { get; set; }
        [DataMember]
        public string MimeType { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
