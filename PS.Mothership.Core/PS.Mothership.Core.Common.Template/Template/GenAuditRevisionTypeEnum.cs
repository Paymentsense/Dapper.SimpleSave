using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenAuditRevisionTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Added")][EnumMember]Added = 1,
       [Description("Modified")][EnumMember]Modified = 2,
       [Description("Deleted")][EnumMember]Deleted = 3,
       [Description("Unchanged")][EnumMember]Unchanged = 4,
        
    }    
    
    public class GenAuditRevisionType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int AuditRevisionTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenAuditRevisionTypeCollection
    {
        private static List<GenAuditRevisionType> _list; 
        public static List<GenAuditRevisionType> GenAuditRevisionTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenAuditRevisionType>
                        {
                            new GenAuditRevisionType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								AuditRevisionTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenAuditRevisionType
							{
								EnumValue = 1,
								EnumName = "Added",
								EnumDescription = "Added",
								AuditRevisionTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenAuditRevisionType
							{
								EnumValue = 2,
								EnumName = "Modified",
								EnumDescription = "Modified",
								AuditRevisionTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenAuditRevisionType
							{
								EnumValue = 3,
								EnumName = "Deleted",
								EnumDescription = "Deleted",
								AuditRevisionTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new GenAuditRevisionType
							{
								EnumValue = 4,
								EnumName = "Unchanged",
								EnumDescription = "Unchanged",
								AuditRevisionTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
