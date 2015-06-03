using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialCallResolutionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Bad Number")][EnumMember]BadNumber = 1,
       [Description("Live or Sale")][EnumMember]LiveOrSale = 2,
       [Description("Unable to Reach or Voicemail")][EnumMember]UnableToReach = 3,
       [Description("Transferred")][EnumMember]Transferred = 4,
       [Description("Internal Business")][EnumMember]InternalBusiness = 5,
       [Description("No Interest or No Sale")][EnumMember]NoInterestOrNoSale = 6,
       [Description("Callback or Reminder")][EnumMember]CallbackOrReminder = 7,
       [Description("Conference Call")][EnumMember]Conference = 8,
        
    }    
    
    public class DialCallResolution
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CallResolutionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialCallResolutionCollection
    {
        private static List<DialCallResolution> _list; 
        public static List<DialCallResolution> DialCallResolutionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialCallResolution>
                        {
                            new DialCallResolution
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CallResolutionKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new DialCallResolution
							{
								EnumValue = 1,
								EnumName = "BadNumber",
								EnumDescription = "Bad Number",
								CallResolutionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 2,
								EnumName = "LiveOrSale",
								EnumDescription = "Live or Sale",
								CallResolutionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 3,
								EnumName = "UnableToReach",
								EnumDescription = "Unable to Reach or Voicemail",
								CallResolutionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 4,
								EnumName = "Transferred",
								EnumDescription = "Transferred",
								CallResolutionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 5,
								EnumName = "InternalBusiness",
								EnumDescription = "Internal Business",
								CallResolutionKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 6,
								EnumName = "NoInterestOrNoSale",
								EnumDescription = "No Interest or No Sale",
								CallResolutionKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 7,
								EnumName = "CallbackOrReminder",
								EnumDescription = "Callback or Reminder",
								CallResolutionKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallResolution
							{
								EnumValue = 8,
								EnumName = "Conference",
								EnumDescription = "Conference Call",
								CallResolutionKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
