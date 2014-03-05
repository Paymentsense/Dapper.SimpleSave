using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum FirstDataApplicationStatusEnum : long
    {
       [Description("")][EnumMember]Unknown = 0,
       [Description("")][EnumMember]FailedXsdValidation = 1,
       [Description("")][EnumMember]WebServiceSubmissionError = 2,
       [Description("")][EnumMember]SubmittedToWebService = 3,
       [Description("")][EnumMember]OtherStatusReturnedByWebService = 4,
       [Description("")][EnumMember]FD_FailedValidationHandler = 30,
       [Description("")][EnumMember]FD_PendingInternalValidation = 31,
       [Description("")][EnumMember]FD_BoardingInProgress = 32,
        
    }

    public class FirstDataApplicationStatus
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ApplicationSubmissionStatusID {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class FirstDataApplicationStatusCollection
    {
        private static List<FirstDataApplicationStatus> _list; 
        public static List<FirstDataApplicationStatus> FirstDataApplicationStatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<FirstDataApplicationStatus>
                        {
                            new FirstDataApplicationStatus
							{
								EnumValue = 0,
								EnumName = "Unknown",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 0,
								RecStatusKey = (RecStatusEnum)0
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 1,
								EnumName = "FailedXsdValidation",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 2,
								EnumName = "WebServiceSubmissionError",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 2,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 3,
								EnumName = "SubmittedToWebService",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 3,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 4,
								EnumName = "OtherStatusReturnedByWebService",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 4,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 30,
								EnumName = "FD_FailedValidationHandler",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 30,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 31,
								EnumName = "FD_PendingInternalValidation",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 31,
								RecStatusKey = (RecStatusEnum)1
							},
							new FirstDataApplicationStatus
							{
								EnumValue = 32,
								EnumName = "FD_BoardingInProgress",
								EnumDescription = "",
								ApplicationSubmissionStatusID = 32,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
