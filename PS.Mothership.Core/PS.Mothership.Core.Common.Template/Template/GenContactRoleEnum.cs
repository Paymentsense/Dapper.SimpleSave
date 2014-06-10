using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenContactRoleEnum : long
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class GenContactRole
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ContactRoleKey {get;set;}
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
								EnumDescription = "None",
								ContactRoleKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
