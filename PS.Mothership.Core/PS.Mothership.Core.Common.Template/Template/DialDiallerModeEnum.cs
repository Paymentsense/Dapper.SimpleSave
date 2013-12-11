using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace PS.Mothership.Core.Common.Template.Dial
{
    
    [DataContract]
    public enum DiallerModeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Accepting Calls")][EnumMember]AcceptingCalls = 1,
       [Description("Not Accepting Calls")][EnumMember]NotAcceptingCalls = 2,
        
    }

    public class DiallerMode
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long DiallerModeKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class DiallerModeCollection
    {
        private static List<DiallerMode> _list; 
        public static List<DiallerMode> DiallerModeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<DiallerMode>
                        {
                            							new DiallerMode
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								DiallerModeKey=0
							},
							new DiallerMode
							{
								EnumValue = 1,
								EnumName = "AcceptingCalls",
								EnumDescription = "Accepting Calls",
								DiallerModeKey=1
							},
							new DiallerMode
							{
								EnumValue = 2,
								EnumName = "NotAcceptingCalls",
								EnumDescription = "Not Accepting Calls",
								DiallerModeKey=2
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
