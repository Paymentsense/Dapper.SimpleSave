using PS.Mothership.Core.Common.Constructs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PS.Mothership.Core.Common.Extension
{
    public static class IntExtension
    {
        public static bool IsInRange(this int source, int minValue, int maxValue)
        {
            return source >= minValue && source <= maxValue;
        }
    }
}
