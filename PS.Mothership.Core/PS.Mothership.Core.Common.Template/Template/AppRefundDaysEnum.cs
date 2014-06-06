using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppRefundDaysEnum : long
    {
       [Description("")][EnumMember]None = 0,
        
    }    
    
    public class AppRefundDays
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long RefundDaysKey {get;set;}
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
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
