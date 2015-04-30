using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenNoContactReasonEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenNoContactReason
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ReasonKey {get;set;}
		public bool IsForEmail {get;set;}
		public bool IsForPhone {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenNoContactReasonCollection
    {
        private static List<GenNoContactReason> _list; 
        public static List<GenNoContactReason> GenNoContactReasonList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenNoContactReason>
                        {
                            new GenNoContactReason
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ReasonKey = 0,
								IsForEmail = false,
								IsForPhone = false,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
