using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.QuartzManagement
{
    [DataContract]
    public enum AvailableJobGroupsEnum
    {
        [EnumMember]
        Default = 0,
        [EnumMember]
        JobGroup1 = 1,
        [EnumMember]
        JobGroup2 = 2,
        [EnumMember]
        JobGroup3 = 3,
        [EnumMember]
        JobGroup4 = 4,
        [EnumMember]
        JobGroup5 = 5
    }
}