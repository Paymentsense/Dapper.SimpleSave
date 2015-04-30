using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Mrkt
{
    
    [DataContract]
    public enum MrktProspectImportMsactionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class MrktProspectImportMsaction
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ProspectImportMsActionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MrktProspectImportMsactionCollection
    {
        private static List<MrktProspectImportMsaction> _list; 
        public static List<MrktProspectImportMsaction> MrktProspectImportMsactionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MrktProspectImportMsaction>
                        {
                            new MrktProspectImportMsaction
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ProspectImportMsActionKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
