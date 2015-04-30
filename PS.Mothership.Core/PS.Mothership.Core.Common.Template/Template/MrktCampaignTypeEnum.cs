using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Mrkt
{
    
    [DataContract]
    public enum MrktCampaignTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
        
    }    
    
    public class MrktCampaignType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int CampaignTypeKey {get;set;}
		public int CampaignSourceKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class MrktCampaignTypeCollection
    {
        private static List<MrktCampaignType> _list; 
        public static List<MrktCampaignType> MrktCampaignTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<MrktCampaignType>
                        {
                            new MrktCampaignType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								CampaignTypeKey = 0,
								CampaignSourceKey = 0,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
