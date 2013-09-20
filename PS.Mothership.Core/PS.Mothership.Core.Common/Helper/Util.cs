using System;
using System.Globalization;
using Newtonsoft.Json;

namespace PS.Mothership.Core.Common.Helper
{
    /// <summary>
    ///     Helper class
    /// </summary>
    public sealed class Util
    {
        /// <summary>
        /// Method to convert dynamic object to json string
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        public static string ConvertToJson(dynamic objData)
        {
            try
            {                
                string json = JsonConvert.SerializeObject(objData, Formatting.None);
                return json;
            }
            catch (Exception ex)
            {
                // error logging later
            }

            return null;
        }

        /// <summary>
        /// Convert to dymanic
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static dynamic ConvertToObject(string jsonString)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<dynamic>(jsonString);
                return obj;

            }
            catch (Exception ex)
            {
                // error logging later
            }

            return null;
        }

        /// <summary>
        /// Convert json string to strong typed object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(string jsonString, T obj) where T : class
        {
            try
            {
                var outObject = JsonConvert.DeserializeObject<T>(jsonString);
                return (T)Convert.ChangeType(outObject, typeof(T), CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                // error logging later
            }

            // return default
            return default(T);
        }
    }
}
