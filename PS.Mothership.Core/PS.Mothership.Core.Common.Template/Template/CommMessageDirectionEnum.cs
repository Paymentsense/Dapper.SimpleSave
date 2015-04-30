using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Comm
{
    
    [DataContract]
    public enum CommMessageDirectionEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Sent")][EnumMember]Sent = 1,
       [Description("Received")][EnumMember]Received = 2,
       [Description("Read")][EnumMember]Read = 3,
        
    }    
    
    public class CommMessageDirection
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int MessageDirectionKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class CommMessageDirectionCollection
    {
        private static List<CommMessageDirection> _list; 
        public static List<CommMessageDirection> CommMessageDirectionList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<CommMessageDirection>
                        {
                            new CommMessageDirection
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								MessageDirectionKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new CommMessageDirection
							{
								EnumValue = 1,
								EnumName = "Sent",
								EnumDescription = "Sent",
								MessageDirectionKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageDirection
							{
								EnumValue = 2,
								EnumName = "Received",
								EnumDescription = "Received",
								MessageDirectionKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new CommMessageDirection
							{
								EnumValue = 3,
								EnumName = "Read",
								EnumDescription = "Read",
								MessageDirectionKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
