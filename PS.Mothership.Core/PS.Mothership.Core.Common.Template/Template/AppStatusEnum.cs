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
       [Description("None")][EnumMember]None = 0,
       [Description("Data Entry")][EnumMember]DataEntry = 10,
       [Description("Docs Out")][EnumMember]DocsOut = 20,
       [Description("Docs In")][EnumMember]DocsIn = 30,
       [Description("In Review")][EnumMember]InReview = 40,
       [Description("Return To Seller")][EnumMember]ReturnToSeller = 50,
       [Description("To Acquirer")][EnumMember]ToAcquirer = 60,
       [Description("Credit Sent To Acquirer")][EnumMember]CreditSentToAcquirer = 70,
       [Description("Boarding Sent To Acquirer")][EnumMember]BoardingSentToAcquirer = 80,
       [Description("Acquirer Rejected")][EnumMember]AcquirerRejected = 90,
       [Description("Failed To Send")][EnumMember]FailedToSend = 100,
       [Description("Acquirer Abandoned")][EnumMember]AcquirerAbandoned = 110,
       [Description("In Credit Review")][EnumMember]InCreditReview = 120,
       [Description("Referred")][EnumMember]Referred = 130,
       [Description("Abandoned")][EnumMember]Abandoned = 140,
       [Description("Approved")][EnumMember]Approved = 150,
        
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
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ApplicationStatusKey = 0,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 10,
								EnumName = "DataEntry",
								EnumDescription = "Data Entry",
								ApplicationStatusKey = 10,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 20,
								EnumName = "DocsOut",
								EnumDescription = "Docs Out",
								ApplicationStatusKey = 20,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 30,
								EnumName = "DocsIn",
								EnumDescription = "Docs In",
								ApplicationStatusKey = 30,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 40,
								EnumName = "InReview",
								EnumDescription = "In Review",
								ApplicationStatusKey = 40,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 50,
								EnumName = "ReturnToSeller",
								EnumDescription = "Return To Seller",
								ApplicationStatusKey = 50,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 60,
								EnumName = "ToAcquirer",
								EnumDescription = "To Acquirer",
								ApplicationStatusKey = 60,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 70,
								EnumName = "CreditSentToAcquirer",
								EnumDescription = "Credit Sent To Acquirer",
								ApplicationStatusKey = 70,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 80,
								EnumName = "BoardingSentToAcquirer",
								EnumDescription = "Boarding Sent To Acquirer",
								ApplicationStatusKey = 80,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 90,
								EnumName = "AcquirerRejected",
								EnumDescription = "Acquirer Rejected",
								ApplicationStatusKey = 90,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 100,
								EnumName = "FailedToSend",
								EnumDescription = "Failed To Send",
								ApplicationStatusKey = 100,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 110,
								EnumName = "AcquirerAbandoned",
								EnumDescription = "Acquirer Abandoned",
								ApplicationStatusKey = 110,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 120,
								EnumName = "InCreditReview",
								EnumDescription = "In Credit Review",
								ApplicationStatusKey = 120,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 130,
								EnumName = "Referred",
								EnumDescription = "Referred",
								ApplicationStatusKey = 130,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 140,
								EnumName = "Abandoned",
								EnumDescription = "Abandoned",
								ApplicationStatusKey = 140,
								WobblyHours = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppStatus
							{
								EnumValue = 150,
								EnumName = "Approved",
								EnumDescription = "Approved",
								ApplicationStatusKey = 150,
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
