using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DialModeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Admin Mode")][EnumMember]Admin = 1,
       [Description("Break Mode")][EnumMember]Break = 2,
       [Description("Dialler Mode")][EnumMember]Dialler = 3,
       [Description("Dialler Inbound Mode")][EnumMember]DiallerInbound = 4,
       [Description("Dialler Outbound Mode")][EnumMember]DiallerOutbound = 5,
       [Description("Dialler Inbound and Outbound Mode")][EnumMember]DiallerCombined = 6,
        
    }    
    
    public class DialMode
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int ModeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DialModeCollection
    {
        private static List<DialMode> _list; 
        public static List<DialMode> DialModeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DialMode>
                        {
                            new DialMode
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ModeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new DialMode
							{
								EnumValue = 1,
								EnumName = "Admin",
								EnumDescription = "Admin Mode",
								ModeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialMode
							{
								EnumValue = 2,
								EnumName = "Break",
								EnumDescription = "Break Mode",
								ModeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialMode
							{
								EnumValue = 3,
								EnumName = "Dialler",
								EnumDescription = "Dialler Mode",
								ModeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialMode
							{
								EnumValue = 4,
								EnumName = "DiallerInbound",
								EnumDescription = "Dialler Inbound Mode",
								ModeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialMode
							{
								EnumValue = 5,
								EnumName = "DiallerOutbound",
								EnumDescription = "Dialler Outbound Mode",
								ModeKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new DialMode
							{
								EnumValue = 6,
								EnumName = "DiallerCombined",
								EnumDescription = "Dialler Inbound and Outbound Mode",
								ModeKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
