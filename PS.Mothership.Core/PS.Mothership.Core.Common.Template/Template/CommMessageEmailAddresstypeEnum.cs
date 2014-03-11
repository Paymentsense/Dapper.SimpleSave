using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum CommMessageEmailAddresstypeEnum : long
    {
       [Description("None")][EnumMember]None = 0,
       [Description("From")][EnumMember]From = 1,
       [Description("To")][EnumMember]To = 2,
       [Description("CC")][EnumMember]CC = 3,
       [Description("BCC")][EnumMember]BCC = 4,
        
    }    
    
    public class CommMessageEmailAddresstype
    {
        public long EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public long MessageEmailAddressTypeKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CommMessageEmailAddresstypeCollection
    {
        private static List<CommMessageEmailAddresstype> _list; 
        public static List<CommMessageEmailAddresstype> CommMessageEmailAddresstypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CommMessageEmailAddresstype>
                        {
                            new CommMessageEmailAddresstype
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageEmailAddressTypeKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CommMessageEmailAddresstype
							{
								EnumValue = 1,
								EnumName = "From",
								EnumDescription = "From",
								MessageEmailAddressTypeKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageEmailAddresstype
							{
								EnumValue = 2,
								EnumName = "To",
								EnumDescription = "To",
								MessageEmailAddressTypeKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageEmailAddresstype
							{
								EnumValue = 3,
								EnumName = "CC",
								EnumDescription = "CC",
								MessageEmailAddressTypeKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageEmailAddresstype
							{
								EnumValue = 4,
								EnumName = "BCC",
								EnumDescription = "BCC",
								MessageEmailAddressTypeKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
