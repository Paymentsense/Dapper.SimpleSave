using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenGatewayEnum : long
    {
       [Description("")][EnumMember]Undefined = 0,
        
    }    
    
    public class GenGateway
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long GatewayKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenGatewayCollection
    {
        private static List<GenGateway> _list; 
        public static List<GenGateway> GenGatewayList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenGateway>
                        {
                            new GenGateway
							{
								EnumValue = 0,
								EnumName = "Undefined",
								EnumDescription = "",
								GatewayKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
