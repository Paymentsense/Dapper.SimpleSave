using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialCallDispositionEnum : long
    {
       [Description("Not Disposed")][EnumMember]NotDisposed = 0,
       [Description("Bad Number")][EnumMember]BadNumber = 1,
       [Description("Skipped")][EnumMember]Skipped = 2,
       [Description("Unanswered")][EnumMember]Unanswered = 3,
       [Description("Answered")][EnumMember]Answered = 4,
       [Description("Transferred")][EnumMember]Transferred = 5,
       [Description("Conferenced")][EnumMember]Conferenced = 6,
       [Description("Rejected")][EnumMember]Rejected = 7,
        
    }    
    
    public class DialCallDisposition
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CallDispositionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialCallDispositionCollection
    {
        private static List<DialCallDisposition> _list; 
        public static List<DialCallDisposition> DialCallDispositionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialCallDisposition>
                        {
                            new DialCallDisposition
							{
								EnumValue = 0,
								EnumName = "NotDisposed",
								EnumDescription = "Not Disposed",
								CallDispositionKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 1,
								EnumName = "BadNumber",
								EnumDescription = "Bad Number",
								CallDispositionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 2,
								EnumName = "Skipped",
								EnumDescription = "Skipped",
								CallDispositionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 3,
								EnumName = "Unanswered",
								EnumDescription = "Unanswered",
								CallDispositionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 4,
								EnumName = "Answered",
								EnumDescription = "Answered",
								CallDispositionKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 5,
								EnumName = "Transferred",
								EnumDescription = "Transferred",
								CallDispositionKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 6,
								EnumName = "Conferenced",
								EnumDescription = "Conferenced",
								CallDispositionKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialCallDisposition
							{
								EnumValue = 7,
								EnumName = "Rejected",
								EnumDescription = "Rejected",
								CallDispositionKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
