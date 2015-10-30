using System.ComponentModel;
using System.Runtime.Serialization;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
	[Table("[gen].ADDRESS_TYPES_ENUM"), ReferenceData]
    public enum GenAddressTypesEnum : int
    {
       [Description("None")][EnumMember]None = 0,
    }
}
