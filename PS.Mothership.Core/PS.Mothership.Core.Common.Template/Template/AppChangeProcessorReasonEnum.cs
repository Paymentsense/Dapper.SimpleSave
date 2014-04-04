using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppChangeProcessorReasonEnum : long
    {
       [Description("Blank")][EnumMember]Blank = 0,
        
    }    
    
    public class AppChangeProcessorReason
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ChangeProcessorReasonKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppChangeProcessorReasonCollection
    {
        private static List<AppChangeProcessorReason> _list; 
        public static List<AppChangeProcessorReason> AppChangeProcessorReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppChangeProcessorReason>
                        {
                            new AppChangeProcessorReason
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "Blank",
								ChangeProcessorReasonKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
