using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.App
{
    
    [DataContract]
    public enum AppStatementDeliveryEnum : int
    {
       [Description("Blank")][EnumMember]Blank = 0,
        
    }    
    
    public class AppStatementDelivery
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int StatementDeliveryKey {get;set;}
		public int DefaultCharge {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class AppStatementDeliveryCollection
    {
        private static List<AppStatementDelivery> _list; 
        public static List<AppStatementDelivery> AppStatementDeliveryList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<AppStatementDelivery>
                        {
                            new AppStatementDelivery
							{
								EnumValue = 0,
								EnumName = "Blank",
								EnumDescription = "Blank",
								StatementDeliveryKey = 0,
								DefaultCharge = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
