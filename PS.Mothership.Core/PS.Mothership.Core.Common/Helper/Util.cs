using System;
using System.Globalization;

namespace PS.Mothership.Core.Common.Helper
{
    public sealed class Util
    {
        /// <summary>
        /// Change to the right
        /// type
        /// </summary>        
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TO"></typeparam>        
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        /// <returns></returns>
        public static TO ChangeToType<TFrom, TO>(TFrom fromObj, TO toObj)
        {
            try
            {
                return (TO) Convert.ChangeType(fromObj, typeof (TO), CultureInfo.CurrentCulture);
            }
            catch
            {
                // swallo exception
            }

            // return default
            return default(TO);
        }
    }
}
