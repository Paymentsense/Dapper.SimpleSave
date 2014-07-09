using PS.Mothership.Core.Common.Template.Comm;

namespace PS.Mothership.Core.Common.Dto.Message
{
    public class MessageServiceStatusDto
    {
        public CommMessageServiceStatusEnum MessageServiceStatus { get; set; }
        public CommMessageTypeEnum MessageTypeEnum { get; set; }
    }
}
