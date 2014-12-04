using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppSalesMethodEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class AppSalesMethod
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int SalesMethodKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppSalesMethodCollection
    {
        private static List<AppSalesMethod> _list; 
        public static List<AppSalesMethod> AppSalesMethodList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppSalesMethod>
                        {
                            new AppSalesMethod
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								SalesMethodKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
