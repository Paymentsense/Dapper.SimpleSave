using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenBusinessDetailProviderEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("DueDil")][EnumMember]DueDil = 1,
        
    }    
    
    public class GenBusinessDetailProvider
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int BusinessDetailProviderKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenBusinessDetailProviderCollection
    {
        private static List<GenBusinessDetailProvider> _list; 
        public static List<GenBusinessDetailProvider> GenBusinessDetailProviderList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenBusinessDetailProvider>
                        {
                            new GenBusinessDetailProvider
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessDetailProviderKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenBusinessDetailProvider
							{
								EnumValue = 1,
								EnumName = "DueDil",
								EnumDescription = "DueDil",
								BusinessDetailProviderKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
