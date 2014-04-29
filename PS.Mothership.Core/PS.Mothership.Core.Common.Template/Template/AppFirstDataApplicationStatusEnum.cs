using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppFirstDataApplicationStatusEnum : long
    {
       [Description("")][EnumMember]Unknown = 0,
       [Description("")][EnumMember]FailedXsdValidation = 1,
       [Description("")][EnumMember]WebServiceSubmissionError = 2,
       [Description("")][EnumMember]SubmittedToWebService = 3,
       [Description("")][EnumMember]OtherStatusReturnedByWebService = 4,
       [Description("")][EnumMember]FDFailedValidationHandler = 30,
       [Description("")][EnumMember]FDPendingInternalValidation = 31,
       [Description("")][EnumMember]FDBoardingInProgress = 32,
        
    }    
    
    public class AppFirstDataApplicationStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ApplicationSubmissionStatusID {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppFirstDataApplicationStatusCollection
    {
        private static List<AppFirstDataApplicationStatus> _list; 
        public static List<AppFirstDataApplicationStatus> AppFirstDataApplicationStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppFirstDataApplicationStatus>
                        {
                            new AppFirstDataApplicationStatus
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 1,
								EnumName = "FailedXsdValidation",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 2,
								EnumName = "WebServiceSubmissionError",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 3,
								EnumName = "SubmittedToWebService",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 4,
								EnumName = "OtherStatusReturnedByWebService",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 30,
								EnumName = "FDFailedValidationHandler",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 30,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 31,
								EnumName = "FDPendingInternalValidation",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 31,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new AppFirstDataApplicationStatus
							{
								EnumValue = 32,
								EnumName = "FDBoardingInProgress",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 32,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
