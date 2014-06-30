using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.QuartzManagement
{
    [DataContract]
    public enum SchedulerStatusEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Running = 1,
        [EnumMember]
        Shutdown = 2,
        [EnumMember]
        Standby = 3
    }
}