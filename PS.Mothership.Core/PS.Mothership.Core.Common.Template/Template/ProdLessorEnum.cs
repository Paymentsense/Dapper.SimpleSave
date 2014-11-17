using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Prod
{
    
    [DataContract]
    public enum ProdLessorEnum : int
    {
       [Description("")][EnumMember]None = 0,
       [Description("")][EnumMember]FDGL = 1,
        
    }    
    
    public class ProdLessor
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int LessorKey {get;set;}
		public string ShortName {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class ProdLessorCollection
    {
        private static List<ProdLessor> _list; 
        public static List<ProdLessor> ProdLessorList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<ProdLessor>
                        {
                            new ProdLessor
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "",
								LessorKey = 0,
								ShortName = "None",
								RecStatusKey = (GenRecStatusEnum)1
							},
							new ProdLessor
							{
								EnumValue = 1,
								EnumName = "FDGL",
								EnumDescription = "",
								LessorKey = 1,
								ShortName = "FDGL",
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
