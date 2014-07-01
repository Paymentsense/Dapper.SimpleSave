using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.QuartzManagement
{
    [DataContract]
    public enum AvailableJobGroupsEnum
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Default = 1,
        [EnumMember]
        HR = 2,
        [EnumMember]
        Ecom = 3,
        [EnumMember]
        Finance = 4,
        [EnumMember]
        Dialler = 5,
        [EnumMember]
        CustomerService = 6,
        [EnumMember]
        Marketing = 7,
        [EnumMember]
        ProSupport = 8,
        [EnumMember]
        EchoSign = 9,
        [EnumMember]
        Iridium = 10
    }
}