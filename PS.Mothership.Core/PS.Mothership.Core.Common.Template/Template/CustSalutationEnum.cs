using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Cust
{
    
    [DataContract]
    public enum SalutationEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class Salutation
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long SalutationKey {get;set;}
		public long GenderKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class SalutationCollection
    {
        private static List<Salutation> _list; 
        public static List<Salutation> SalutationList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Salutation>
                        {
                            new Salutation
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								SalutationKey = 0,
								GenderKey = 0,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
