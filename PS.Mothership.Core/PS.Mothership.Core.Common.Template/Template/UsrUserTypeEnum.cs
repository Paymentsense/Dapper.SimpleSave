using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UsrUserTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Employee")][EnumMember]Employee = 1,
       [Description("Contractor")][EnumMember]Contractor = 2,
       [Description("Third Party")][EnumMember]ThirdParty = 3,
        
    }    
    
    public class UsrUserType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int UserTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UsrUserTypeCollection
    {
        private static List<UsrUserType> _list; 
        public static List<UsrUserType> UsrUserTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UsrUserType>
                        {
                            new UsrUserType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								UserTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserType
							{
								EnumValue = 1,
								EnumName = "Employee",
								EnumDescription = "Employee",
								UserTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserType
							{
								EnumValue = 2,
								EnumName = "Contractor",
								EnumDescription = "Contractor",
								UserTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new UsrUserType
							{
								EnumValue = 3,
								EnumName = "ThirdParty",
								EnumDescription = "Third Party",
								UserTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
