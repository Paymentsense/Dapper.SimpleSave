using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums
{
    [DataContract]
    public enum State
    {
        [EnumMember]
        New,
        [EnumMember]
        Open,
        [EnumMember]
        Closed
    }
}