using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Prod
{
    
    [DataContract]
    public enum ProdAcquirerEnum : int
    {
       [Description("")][EnumMember]Undefined = 0,
       [Description("")][EnumMember]FDMS = 1,
       [Description("")][EnumMember]Valitor = 2,
        
    }    
    
    public class ProdAcquirer
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int AcquirerKey {get;set;}
		public string ShortName {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class ProdAcquirerCollection
    {
        private static List<ProdAcquirer> _list; 
        public static List<ProdAcquirer> ProdAcquirerList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<ProdAcquirer>
                        {
                            new ProdAcquirer
							{
								EnumValue = 0,
								EnumName = "Undefined",
								EnumDescription = "",
								AcquirerKey = 0,
								ShortName = "Undefined",
								RecStatusKey = (GenRecStatusEnum)3
							},
							new ProdAcquirer
							{
								EnumValue = 1,
								EnumName = "FDMS",
								EnumDescription = "",
								AcquirerKey = 1,
								ShortName = "FDMS",
								RecStatusKey = (GenRecStatusEnum)1
							},
							new ProdAcquirer
							{
								EnumValue = 2,
								EnumName = "Valitor",
								EnumDescription = "",
								AcquirerKey = 2,
								ShortName = "Valitor",
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
