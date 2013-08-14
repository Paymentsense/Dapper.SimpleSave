
using System;

namespace PS.Mothership.Core.Common.Template
{
    [Flags]
	public enum PermissionLutEnum : long 
	{

		Add = 1,
		Read = 2,
		Delete = 4,
	}
}
