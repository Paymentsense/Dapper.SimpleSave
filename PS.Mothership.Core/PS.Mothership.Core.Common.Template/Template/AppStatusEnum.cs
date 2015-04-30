using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppStatusEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Offer Made")][EnumMember]OfferMade = 10,
       [Description("On Application")][EnumMember]OnApp = 20,
       [Description("Docs Out")][EnumMember]DocsOut = 30,
       [Description("Docs In")][EnumMember]DocsIn = 40,
       [Description("To Bank")][EnumMember]ToBank = 50,
       [Description("Abandoned")][EnumMember]Abandoned = 60,
       [Description("Live")][EnumMember]Live = 70,
        
    }    
    
    public class AppStatus
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int StatusKey {get;set;}
		public int WobblyHours {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppStatusCollection
    {
        private static List<AppStatus> _list; 
        public static List<AppStatus> AppStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppStatus>
                        {
                            new AppStatus
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								StatusKey = 0,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 10,
								EnumName = "OfferMade",
								EnumDescription = "Offer Made",
								StatusKey = 10,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 20,
								EnumName = "OnApp",
								EnumDescription = "On Application",
								StatusKey = 20,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 30,
								EnumName = "DocsOut",
								EnumDescription = "Docs Out",
								StatusKey = 30,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 40,
								EnumName = "DocsIn",
								EnumDescription = "Docs In",
								StatusKey = 40,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 50,
								EnumName = "ToBank",
								EnumDescription = "To Bank",
								StatusKey = 50,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 60,
								EnumName = "Abandoned",
								EnumDescription = "Abandoned",
								StatusKey = 60,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 70,
								EnumName = "Live",
								EnumDescription = "Live",
								StatusKey = 70,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
