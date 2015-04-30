using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppPremisesOwnershipTypeEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("")][EnumMember]Owned = 1,
       [Description("")][EnumMember]Rented = 2,
       [Description("")][EnumMember]LivedWithParents = 3,
        
    }    
    
    public class AppPremisesOwnershipType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int PremisesOwnershipTypeKey {get;set;}
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
								EnumName = "None",
								EnumDescription = "",
								PremisesOwnershipTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new AppPremisesOwnershipType
							{
								EnumValue = 1,
								EnumName = "Owned",
								EnumDescription = "",
								PremisesOwnershipTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppPremisesOwnershipType
							{
								EnumValue = 2,
								EnumName = "Rented",
								EnumDescription = "",
								PremisesOwnershipTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new AppPremisesOwnershipType
							{
								EnumValue = 3,
								EnumName = "LivedWithParents",
								EnumDescription = "",
								PremisesOwnershipTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
