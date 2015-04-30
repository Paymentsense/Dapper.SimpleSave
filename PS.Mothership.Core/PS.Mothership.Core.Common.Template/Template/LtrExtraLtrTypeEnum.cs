using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Ltr
{
    
    [DataContract]
    public enum LtrExtraLtrTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class LtrExtraLtrType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ExtraLtrTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class LtrExtraLtrTypeCollection
    {
        private static List<LtrExtraLtrType> _list; 
        public static List<LtrExtraLtrType> LtrExtraLtrTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<LtrExtraLtrType>
                        {
                            new LtrExtraLtrType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ExtraLtrTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
