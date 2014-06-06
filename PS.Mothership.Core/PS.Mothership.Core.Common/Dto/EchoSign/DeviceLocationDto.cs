using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.EchoSign
{
    [DataContract]
    public class DeviceLocationDto
    {
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
    }
}
