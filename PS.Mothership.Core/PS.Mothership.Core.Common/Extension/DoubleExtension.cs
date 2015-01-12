using PS.Mothership.Core.Common.Constructs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PS.Mothership.Core.Common.Extension
{
    public static class DoubleExtension
    {
        public static bool IsInRange(this double source, double minValue, double maxValue)
        {
            return source >= minValue && source <= maxValue;
        }

        public static double RoundTo(this double source, int decimals = 2)
        {
            return Math.Round(source, 2, MidpointRounding.AwayFromZero);
        }
    }
}
