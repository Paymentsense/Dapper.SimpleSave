using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenBusinessAffiliateEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenBusinessAffiliate
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int BusinessAffiliateKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenBusinessAffiliateCollection
    {
        private static List<GenBusinessAffiliate> _list; 
        public static List<GenBusinessAffiliate> GenBusinessAffiliateList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenBusinessAffiliate>
                        {
                            new GenBusinessAffiliate
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								BusinessAffiliateKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
