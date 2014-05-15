using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppStatusEnum : long
    {
       [Description("Not Submitted")][EnumMember]NotSubmitted = 1,
       [Description("Submitted")][EnumMember]Submitted = 2,
       [Description("Abandoned")][EnumMember]Abandoned = 3,
       [Description("Processing")][EnumMember]Processing = 4,
       [Description("Error")][EnumMember]Error = 5,
       [Description("Success")][EnumMember]Success = 6,
       [Description("Bank Recd")][EnumMember]BankRecd = 7,
       [Description("New")][EnumMember]New = 8,
       [Description("In-process")][EnumMember]InProcess = 9,
       [Description("Validated")][EnumMember]Validated = 10,
       [Description("Generated")][EnumMember]Generated = 11,
       [Description("Sent")][EnumMember]Sent = 12,
        
    }    
    
    public class AppStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ApplicationStatusKey {get;set;}
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
								EnumValue = 1,
								EnumName = "NotSubmitted",
								EnumDescription = "Not Submitted",
								ApplicationStatusKey = 1,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 2,
								EnumName = "Submitted",
								EnumDescription = "Submitted",
								ApplicationStatusKey = 2,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 3,
								EnumName = "Abandoned",
								EnumDescription = "Abandoned",
								ApplicationStatusKey = 3,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 4,
								EnumName = "Processing",
								EnumDescription = "Processing",
								ApplicationStatusKey = 4,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 5,
								EnumName = "Error",
								EnumDescription = "Error",
								ApplicationStatusKey = 5,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 6,
								EnumName = "Success",
								EnumDescription = "Success",
								ApplicationStatusKey = 6,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 7,
								EnumName = "BankRecd",
								EnumDescription = "Bank Recd",
								ApplicationStatusKey = 7,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 8,
								EnumName = "New",
								EnumDescription = "New",
								ApplicationStatusKey = 8,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 9,
								EnumName = "InProcess",
								EnumDescription = "In-process",
								ApplicationStatusKey = 9,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 10,
								EnumName = "Validated",
								EnumDescription = "Validated",
								ApplicationStatusKey = 10,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 11,
								EnumName = "Generated",
								EnumDescription = "Generated",
								ApplicationStatusKey = 11,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 12,
								EnumName = "Sent",
								EnumDescription = "Sent",
								ApplicationStatusKey = 12,
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
