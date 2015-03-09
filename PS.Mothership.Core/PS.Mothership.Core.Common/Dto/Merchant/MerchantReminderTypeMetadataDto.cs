﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [Bindable(true)]
    public class MerchantReminderTypeMetadataDto
    {
        [Key, Required]
        public int ReminderValueKey { get; set; }

        public string ReminderText { get; set; }
    }
}
