using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Usr
{
    
    [DataContract]
    public enum UserTypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Employee")][EnumMember]Employee = 1,
       [Description("Contractor")][EnumMember]Contractor = 2,
       [Description("Third Party")][EnumMember]ThirdParty = 3,
        
    }

    public class UserType
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long UserTypeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class UserTypeCollection
    {
        private static List<UserType> _list; 
        public static List<UserType> UserTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<UserType>
                        {
                            new UserType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								UserTypeKey = 0
							},
							new UserType
							{
								EnumValue = 1,
								EnumName = "Employee",
								EnumDescription = "Employee",
								UserTypeKey = 1
							},
							new UserType
							{
								EnumValue = 2,
								EnumName = "Contractor",
								EnumDescription = "Contractor",
								UserTypeKey = 2
							},
							new UserType
							{
								EnumValue = 3,
								EnumName = "ThirdParty",
								EnumDescription = "Third Party",
								UserTypeKey = 3
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
