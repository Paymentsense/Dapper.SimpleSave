using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppChangeProcessorReasonEnum : int
    {
       [Description("Blank")][EnumMember]Blank = 0,
       [Description("Rate")][EnumMember]Rate = 1,
       [Description("Service")][EnumMember]Service = 2,
       [Description("Terminated By Bank")][EnumMember]TerminatedByBank = 3,
       [Description("Other")][EnumMember]Other = 4,
        
    }    
    
    public class AppChangeProcessorReason
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ChangeProcessorReasonKey {get;set;}
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
							new AppChangeProcessorReason
							{
								EnumValue = 1,
								EnumName = "Rate",
								EnumDescription = "Rate",
								ChangeProcessorReasonKey = 1,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppChangeProcessorReason
							{
								EnumValue = 2,
								EnumName = "Service",
								EnumDescription = "Service",
								ChangeProcessorReasonKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppChangeProcessorReason
							{
								EnumValue = 3,
								EnumName = "TerminatedByBank",
								EnumDescription = "Terminated By Bank",
								ChangeProcessorReasonKey = 3,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppChangeProcessorReason
							{
								EnumValue = 4,
								EnumName = "Other",
								EnumDescription = "Other",
								ChangeProcessorReasonKey = 4,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
