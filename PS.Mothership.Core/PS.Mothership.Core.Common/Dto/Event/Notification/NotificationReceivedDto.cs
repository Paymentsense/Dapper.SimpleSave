using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event.Notification
{
    public class NotificationReceivedDto
    {
        public EventTypeEnum EventType { get; set; }
        public int EventTypeTotalNotifications { get; set; }
        public string Username { get; set; }
    }
}
