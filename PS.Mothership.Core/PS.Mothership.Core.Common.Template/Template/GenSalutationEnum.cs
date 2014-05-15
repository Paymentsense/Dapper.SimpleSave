using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenSalutationEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Mr")][EnumMember]Mr = 1,
       [Description("MRS")][EnumMember]MRS = 2,
       [Description("MISS")][EnumMember]MISS = 3,
       [Description("MS")][EnumMember]MS = 4,
        
    }    
    
    public class GenSalutation
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long SalutationKey {get;set;}
		public long GenderKey {get;set;}
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
								EnumDescription = "None",
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
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenSalutation
							{
								EnumValue = 2,
								EnumName = "MRS",
								EnumDescription = "MRS",
								SalutationKey = 2,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenSalutation
							{
								EnumValue = 3,
								EnumName = "MISS",
								EnumDescription = "MISS",
								SalutationKey = 3,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenSalutation
							{
								EnumValue = 4,
								EnumName = "MS",
								EnumDescription = "MS",
								SalutationKey = 4,
								GenderKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
