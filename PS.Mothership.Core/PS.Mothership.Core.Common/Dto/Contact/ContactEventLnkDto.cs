﻿using System;

namespace PS.Mothership.Core.Common.Dto.Contact
{
    public class ContactEventLnkDto
    {
        public Guid ContactEventsLnkGuid { get; set; }

        public Guid EventGuid { get; set; }

        public Guid ContactGuid { get; set; }

        public Guid PhoneGuid { get; set; }
    }
}
