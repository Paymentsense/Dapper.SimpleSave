using System.Collections.Generic;
using PS.Mothership.Core.Common.Dto.Merchant;

namespace PS.Mothership.Core.Common.Dto.Event
{
    public class TouchEventTrnFullDto : EventTrnFullDto
    {
        public IList<MerchantDto> Merchants { get; set; }
    }
}
