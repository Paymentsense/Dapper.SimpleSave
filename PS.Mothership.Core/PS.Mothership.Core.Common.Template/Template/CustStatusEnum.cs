using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum StatusEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class Status
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long CustomerStatusKey {get;set;}
		public long CustStatusGroupKey {get;set;}
		public bool IsArchived {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class StatusCollection
    {
        private static List<Status> _list; 
        public static List<Status> StatusList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Status>
                        {
                            new Status
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CustomerStatusKey = 0,
								CustStatusGroupKey = 0,
								IsArchived = false,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
