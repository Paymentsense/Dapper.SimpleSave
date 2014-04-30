using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum ReminderFrequencyEnum
    {
        [EnumMember]
        DAILY_UNTIL_SIGNED,
        [EnumMember]
        WEEKLY_UNTIL_SIGNED
    }
}
