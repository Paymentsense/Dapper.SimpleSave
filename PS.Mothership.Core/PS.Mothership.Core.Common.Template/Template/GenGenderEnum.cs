using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenderEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }

    public class Gender
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long GenderKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenderCollection
    {
        private static List<Gender> _list; 
        public static List<Gender> GenderList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Gender>
                        {
                            new Gender
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
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
