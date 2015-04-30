using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenContactRoleEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("Director")][EnumMember]Director = 1,
       [Description("Owner")][EnumMember]Owner = 2,
       [Description("Partner")][EnumMember]Partner = 3,
       [Description("Sole Proprietor")][EnumMember]SoleProprietor = 4,
       [Description("Secretary")][EnumMember]Secretary = 5,
       [Description("Employee")][EnumMember]Employee = 6,
        
    }    
    
    public class GenContactRole
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ContactRoleKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenContactRoleCollection
    {
        private static List<GenContactRole> _list; 
        public static List<GenContactRole> GenContactRoleList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenContactRole>
                        {
                            new GenContactRole
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								ContactRoleKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenContactRole
							{
								EnumValue = 1,
								EnumName = "Director",
								EnumDescription = "Director",
								ContactRoleKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenContactRole
							{
								EnumValue = 2,
								EnumName = "Owner",
								EnumDescription = "Owner",
								ContactRoleKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenContactRole
							{
								EnumValue = 3,
								EnumName = "Partner",
								EnumDescription = "Partner",
								ContactRoleKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenContactRole
							{
								EnumValue = 4,
								EnumName = "SoleProprietor",
								EnumDescription = "Sole Proprietor",
								ContactRoleKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenContactRole
							{
								EnumValue = 5,
								EnumName = "Secretary",
								EnumDescription = "Secretary",
								ContactRoleKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenContactRole
							{
								EnumValue = 6,
								EnumName = "Employee",
								EnumDescription = "Employee",
								ContactRoleKey = 6,
								RecStatusKey = (GenRecStatusEnum)2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
