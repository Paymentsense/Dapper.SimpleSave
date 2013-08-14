
using System;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Template
{
    [Flags]
    [DataContract]
	public enum LoginUserResultStatusLutEnum : int 
	{

	[EnumMember]
	ValidLogin = 1,
	[EnumMember]
	InValidLogin = 2,
	}
}
