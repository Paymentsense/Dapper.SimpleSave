using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Opp
{
    
    [DataContract]
    public enum OppAddonServiceTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("DropDown")][EnumMember]DropDown = 1,
       [Description("TextBox")][EnumMember]TextBox = 2,
        
    }    
    
    public class OppAddonServiceType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int AddOnServiceTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class OppAddonServiceTypeCollection
    {
        private static List<OppAddonServiceType> _list; 
        public static List<OppAddonServiceType> OppAddonServiceTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<OppAddonServiceType>
                        {
                            new OppAddonServiceType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AddOnServiceTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new OppAddonServiceType
							{
								EnumValue = 1,
								EnumName = "DropDown",
								EnumDescription = "DropDown",
								AddOnServiceTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new OppAddonServiceType
							{
								EnumValue = 2,
								EnumName = "TextBox",
								EnumDescription = "TextBox",
								AddOnServiceTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
