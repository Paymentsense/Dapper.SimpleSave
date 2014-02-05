using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum CallDispositionEnum : long
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

    public class CallDisposition
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CallDispositionKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CallDispositionCollection
    {
        private static List<CallDisposition> _list; 
        public static List<CallDisposition> CallDispositionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CallDisposition>
                        {
                            new CallDisposition
							{
								EnumValue = 0,
								EnumName = "NotDisposed",
								EnumDescription = "Not Disposed",
								CallDispositionKey = 0
							},
							new CallDisposition
							{
								EnumValue = 1,
								EnumName = "BadNumber",
								EnumDescription = "Bad Number",
								CallDispositionKey = 1
							},
							new CallDisposition
							{
								EnumValue = 2,
								EnumName = "Skipped",
								EnumDescription = "Skipped",
								CallDispositionKey = 2
							},
							new CallDisposition
							{
								EnumValue = 3,
								EnumName = "Unanswered",
								EnumDescription = "Unanswered",
								CallDispositionKey = 3
							},
							new CallDisposition
							{
								EnumValue = 4,
								EnumName = "Answered",
								EnumDescription = "Answered",
								CallDispositionKey = 4
							},
							new CallDisposition
							{
								EnumValue = 5,
								EnumName = "Transferred",
								EnumDescription = "Transferred",
								CallDispositionKey = 5
							},
							new CallDisposition
							{
								EnumValue = 6,
								EnumName = "Conferenced",
								EnumDescription = "Conferenced",
								CallDispositionKey = 6
							},
							new CallDisposition
							{
								EnumValue = 7,
								EnumName = "Rejected",
								EnumDescription = "Rejected",
								CallDispositionKey = 7
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
