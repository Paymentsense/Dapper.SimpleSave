using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenGenderEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Male")][EnumMember]Male = 1,
       [Description("Female")][EnumMember]Female = 2,
       [Description("Unspecified")][EnumMember]Unspecified = 3,
        
    }    
    
    public class GenGender
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int GenderKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenGenderCollection
    {
        private static List<GenGender> _list; 
        public static List<GenGender> GenGenderList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenGender>
                        {
                            new GenGender
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								GenderKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenGender
							{
								EnumValue = 1,
								EnumName = "Male",
								EnumDescription = "Male",
								GenderKey = 1,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenGender
							{
								EnumValue = 2,
								EnumName = "Female",
								EnumDescription = "Female",
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenGender
							{
								EnumValue = 3,
								EnumName = "Unspecified",
								EnumDescription = "Unspecified",
								GenderKey = 3,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
