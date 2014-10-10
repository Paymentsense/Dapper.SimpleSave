using PS.Mothership.Core.Common.Dto.SendMessage;

namespace PS.Mothership.Core.Common.Dto.Notification
{
    public class NotificationStatusDto
    {
        public NotificationReceivedDto NotificationDto { get; set; }
        public SendMessageServiceStatusDto StatusDto { get; set; }
    }
}
