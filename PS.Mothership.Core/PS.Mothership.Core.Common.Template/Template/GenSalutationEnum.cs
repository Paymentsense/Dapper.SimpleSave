using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenSalutationEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("Mr")][EnumMember]Mr = 1,
       [Description("Mrs")][EnumMember]Mrs = 2,
       [Description("Miss")][EnumMember]Miss = 3,
       [Description("Ms")][EnumMember]Ms = 4,
       [Description("Dr")][EnumMember]Dr = 5,
        
    }    
    
    public class GenSalutation
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int SalutationKey {get;set;}
		public int GenderKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenSalutationCollection
    {
        private static List<GenSalutation> _list; 
        public static List<GenSalutation> GenSalutationList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenSalutation>
                        {
                            new GenSalutation
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								SalutationKey = 0,
								GenderKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenSalutation
							{
								EnumValue = 1,
								EnumName = "Mr",
								EnumDescription = "Mr",
								SalutationKey = 1,
								GenderKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSalutation
							{
								EnumValue = 2,
								EnumName = "Mrs",
								EnumDescription = "Mrs",
								SalutationKey = 2,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSalutation
							{
								EnumValue = 3,
								EnumName = "Miss",
								EnumDescription = "Miss",
								SalutationKey = 3,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSalutation
							{
								EnumValue = 4,
								EnumName = "Ms",
								EnumDescription = "Ms",
								SalutationKey = 4,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSalutation
							{
								EnumValue = 5,
								EnumName = "Dr",
								EnumDescription = "Dr",
								SalutationKey = 5,
								GenderKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
