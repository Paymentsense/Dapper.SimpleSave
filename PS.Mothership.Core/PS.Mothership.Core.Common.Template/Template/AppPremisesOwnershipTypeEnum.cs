using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppPremisesOwnershipTypeEnum : long
    {
       [Description("")][EnumMember]Blank = 0,
        
    }    
    
    public class AppPremisesOwnershipType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long PremisesOwnershipTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppPremisesOwnershipTypeCollection
    {
        private static List<AppPremisesOwnershipType> _list; 
        public static List<AppPremisesOwnershipType> AppPremisesOwnershipTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppPremisesOwnershipType>
                        {
                            new AppPremisesOwnershipType
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "",
								PremisesOwnershipTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
