﻿namespace PS.Mothership.Core.Common.Dto.ScheduledCallBack
 {
     public class AutoRescheduleResultDto
     {
         public int ItemRescheduleCount { get; set; }

         public bool CallbackPushedBackOver30Minutes { get; set; }
     }
 }
