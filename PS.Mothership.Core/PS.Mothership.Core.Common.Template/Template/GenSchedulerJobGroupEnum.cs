using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Gen
{
    
    [DataContract]
    public enum GenSchedulerJobGroupEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Default")][EnumMember]Default = 1,
       [Description("Human Resources")][EnumMember]HR = 2,
       [Description("E-Commerce")][EnumMember]Ecom = 3,
       [Description("Finance")][EnumMember]Finance = 4,
       [Description("Dialler")][EnumMember]Dialler = 5,
       [Description("Customer Service")][EnumMember]CustomerService = 6,
       [Description("Marketing")][EnumMember]Marketing = 7,
       [Description("Provisioning & Sales Support")][EnumMember]ProSupport = 8,
       [Description("EchoSign")][EnumMember]EchoSign = 9,
       [Description("Iridium")][EnumMember]Iridium = 10,
        
    }    
    
    public class GenSchedulerJobGroup
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int SchedulerJobGroupKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class GenSchedulerJobGroupCollection
    {
        private static List<GenSchedulerJobGroup> _list; 
        public static List<GenSchedulerJobGroup> GenSchedulerJobGroupList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<GenSchedulerJobGroup>
                        {
                            new GenSchedulerJobGroup
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								SchedulerJobGroupKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 1,
								EnumName = "Default",
								EnumDescription = "Default",
								SchedulerJobGroupKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 2,
								EnumName = "HR",
								EnumDescription = "Human Resources",
								SchedulerJobGroupKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 3,
								EnumName = "Ecom",
								EnumDescription = "E-Commerce",
								SchedulerJobGroupKey = 3,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 4,
								EnumName = "Finance",
								EnumDescription = "Finance",
								SchedulerJobGroupKey = 4,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 5,
								EnumName = "Dialler",
								EnumDescription = "Dialler",
								SchedulerJobGroupKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 6,
								EnumName = "CustomerService",
								EnumDescription = "Customer Service",
								SchedulerJobGroupKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 7,
								EnumName = "Marketing",
								EnumDescription = "Marketing",
								SchedulerJobGroupKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 8,
								EnumName = "ProSupport",
								EnumDescription = "Provisioning & Sales Support",
								SchedulerJobGroupKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 9,
								EnumName = "EchoSign",
								EnumDescription = "EchoSign",
								SchedulerJobGroupKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new GenSchedulerJobGroup
							{
								EnumValue = 10,
								EnumName = "Iridium",
								EnumDescription = "Iridium",
								SchedulerJobGroupKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
