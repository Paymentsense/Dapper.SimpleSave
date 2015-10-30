using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [DataContract]
    [Table("[usr].RESOURCE_ENUM"), ReferenceData]
    public enum UsrResourceEnum : int
    {
        [Description("None")]
        [EnumMember]
        None = 0,
        [Description("Admin")]
        [EnumMember]
        Admin = 2,
        [Description("User Management")]
        [EnumMember]
        UserManagement = 4,
        [Description("Role Management")]
        [EnumMember]
        RoleManagement = 5,
        [Description("Group Management")]
        [EnumMember]
        GroupManagement = 6,
        [Description("Dialler Client")]
        [EnumMember]
        Dialler = 7,
        [Description("Merchant")]
        [EnumMember]
        Merchant = 8,
        [Description("Schedule Management")]
        [EnumMember]
        ScheduleManagement = 9,
        [Description("Search")]
        [EnumMember]
        MerchantSearch = 10,
        [Description("Application")]
        [EnumMember]
        Application = 11,

    }
}
