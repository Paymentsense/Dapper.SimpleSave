using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppRefundDaysEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("")][EnumMember]ZeroToThreeDays = 1,
       [Description("")][EnumMember]FourToSevenDays = 2,
       [Description("")][EnumMember]EightToFourteenDays = 3,
       [Description("")][EnumMember]FourteenPlusDays = 4,
        
    }    
    
    public class AppRefundDays
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int RefundDaysKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppRefundDaysCollection
    {
        private static List<AppRefundDays> _list; 
        public static List<AppRefundDays> AppRefundDaysList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppRefundDays>
                        {
                            new AppRefundDays
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								RefundDaysKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppRefundDays
							{
								EnumValue = 1,
								EnumName = "ZeroToThreeDays",
								EnumDescription = "",
								RefundDaysKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppRefundDays
							{
								EnumValue = 2,
								EnumName = "FourToSevenDays",
								EnumDescription = "",
								RefundDaysKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppRefundDays
							{
								EnumValue = 3,
								EnumName = "EightToFourteenDays",
								EnumDescription = "",
								RefundDaysKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppRefundDays
							{
								EnumValue = 4,
								EnumName = "FourteenPlusDays",
								EnumDescription = "",
								RefundDaysKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
