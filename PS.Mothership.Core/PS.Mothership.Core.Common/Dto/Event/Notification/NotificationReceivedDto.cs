using PS.Mothership.Core.Common.Template.Event;

namespace PS.Mothership.Core.Common.Dto.Event.Notification
{
    public class NotificationReceivedDto
    {
        EventTypeEnum EventType { get; set; }
        int NotificationAmount { get; set; }
    }
}
