using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenGatewayEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("")][EnumMember]IridiumUK = 1,
       [Description("")][EnumMember]IridiumROI = 2,
        
    }    
    
    public class GenGateway
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int GatewayKey {get;set;}
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
								EnumName = "None",
								EnumDescription = "",
								GatewayKey = 0,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new GenGateway
							{
								EnumValue = 1,
								EnumName = "IridiumUK",
								EnumDescription = "",
								GatewayKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenGateway
							{
								EnumValue = 2,
								EnumName = "IridiumROI",
								EnumDescription = "",
								GatewayKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
