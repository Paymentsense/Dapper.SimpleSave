using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Mrkt
{
    
    [DataContract]
    public enum MrktCampaignSourceEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("Marketting department campaigns")][EnumMember]Marketting = 1,
       [Description("Provisioning Campaigns")][EnumMember]Provisioning = 2,
        
    }    
    
    public class MrktCampaignSource
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CampaignSourceKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MrktCampaignSourceCollection
    {
        private static List<MrktCampaignSource> _list; 
        public static List<MrktCampaignSource> MrktCampaignSourceList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MrktCampaignSource>
                        {
                            new MrktCampaignSource
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CampaignSourceKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignSource
							{
								EnumValue = 1,
								EnumName = "Marketting",
								EnumDescription = "Marketting department campaigns",
								CampaignSourceKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new MrktCampaignSource
							{
								EnumValue = 2,
								EnumName = "Provisioning",
								EnumDescription = "Provisioning Campaigns",
								CampaignSourceKey = 2,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
