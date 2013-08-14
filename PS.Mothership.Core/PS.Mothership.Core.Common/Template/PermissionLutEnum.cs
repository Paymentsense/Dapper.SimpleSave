
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Template
{
    [Flags]
    [DataContract]
	public enum PermissionLutEnum : long 
	{

	[EnumMember]
	Add = 1,
	[EnumMember]
	Read = 2,
	[EnumMember]
	Delete = 4,
	}
}
