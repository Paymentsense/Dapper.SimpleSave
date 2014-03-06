using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum ModeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Admin Mode")][EnumMember]Admin = 1,
       [Description("Dialler Mode")][EnumMember]Dialler = 2,
       [Description("Dialler Inbound Mode")][EnumMember]DiallerInbound = 3,
       [Description("Dialler Outbound Mode")][EnumMember]DiallerOutbound = 4,
       [Description("Dialler Inbound and Outbound Mode")][EnumMember]DiallerCombined = 5,
        
    }

    public class Mode
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long ModeKey {get;set;}
		public RecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class ModeCollection
    {
        private static List<Mode> _list; 
        public static List<Mode> ModeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<Mode>
                        {
                            new Mode
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								ModeKey = 0,
								RecStatusKey = (RecStatusEnum)1
							},
							new Mode
							{
								EnumValue = 1,
								EnumName = "Admin",
								EnumDescription = "Admin Mode",
								ModeKey = 1,
								RecStatusKey = (RecStatusEnum)1
							},
							new Mode
							{
								EnumValue = 2,
								EnumName = "Dialler",
								EnumDescription = "Dialler Mode",
								ModeKey = 2,
								RecStatusKey = (RecStatusEnum)1
							},
							new Mode
							{
								EnumValue = 3,
								EnumName = "DiallerInbound",
								EnumDescription = "Dialler Inbound Mode",
								ModeKey = 3,
								RecStatusKey = (RecStatusEnum)1
							},
							new Mode
							{
								EnumValue = 4,
								EnumName = "DiallerOutbound",
								EnumDescription = "Dialler Outbound Mode",
								ModeKey = 4,
								RecStatusKey = (RecStatusEnum)1
							},
							new Mode
							{
								EnumValue = 5,
								EnumName = "DiallerCombined",
								EnumDescription = "Dialler Inbound and Outbound Mode",
								ModeKey = 5,
								RecStatusKey = (RecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
