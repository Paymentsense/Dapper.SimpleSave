using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum DocumentLibraryItemScopeEnum
    {
        [EnumMember]
        SHARED,
        [EnumMember]
        GLOBAL,
        [EnumMember]
        PERSONAL
    }
}
