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

    /// <summary>
    ///     Manage Region
    /// </summary>
    public enum RegionAction
    {
        None,
        DoCreateIfNotExists,
        Clear,
        //Remove // for now lets disable this function, as the developer would be bit confused between clear and remove
    }
}
