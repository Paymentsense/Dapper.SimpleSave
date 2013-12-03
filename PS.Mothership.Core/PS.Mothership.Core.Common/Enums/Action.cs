using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums
{
    [DataContract]
    public enum Action
    {
        [EnumMember]
        Add=0,
        [EnumMember]
        Delete,
        [EnumMember]
        Update
    }
}
