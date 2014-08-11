using System.ComponentModel.DataAnnotations;

namespace PS.Mothership.Core.Common.Enums
{
    public enum NotificationIcon
    {
        [Display(Name = "notification-tab-message")]
        EmailReceived = 1,
        [Display(Name = "notification-tab-chat")]
        SMSReceived = 2,
    }
}
