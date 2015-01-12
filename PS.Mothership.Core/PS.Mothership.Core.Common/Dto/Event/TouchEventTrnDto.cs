using System;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Dto.Event
{
    public class TouchEventTrnDto : EventTrnDto
    {
        public IList<Guid> MerchantGuids { get; set; }
    }
}
