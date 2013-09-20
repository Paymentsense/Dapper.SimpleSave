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
        /// <remarks>
        ///     If the JsonSerializerSetting gets bigger, then expose them in the signature
        ///     "public static string ConvertToJson(dynamic objData,JsonSerializerSettings jsonSerializerSettings=null)"
        ///     if we do this, any prjects using this utilility need to reference Newtonsoft.Json;
        /// </remarks>
        /// <param name="objData"></param>        
        /// <param name="typeNameHandling"></param>
        /// <returns></returns>        
        public static string ConvertToJson(dynamic objData, bool typeNameHandling=false)
        {
            try
            {
                return typeNameHandling ? 
                    JsonConvert.SerializeObject(objData, Formatting.None,new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All}) :
                    JsonConvert.SerializeObject(objData, Formatting.None);                
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
        /// <remarks>
        ///     If the JsonSerializerSetting gets bigger, then expose them in the signature
        ///     "public static string ConvertToObject(string jsonString,JsonSerializerSettings jsonSerializerSettings=null)"
        ///     if we do this, any prjects using this utilility need to reference Newtonsoft.Json;
        /// </remarks>
        /// <param name="jsonString"></param>
        /// <param name="typeNameHandling"></param>
        /// <returns></returns>
        public static dynamic ConvertToObject(string jsonString, bool typeNameHandling = false)
        {
            try
            {
                // for security TypeNameHandling is required when deserializing, if the jsonString used TypeNameHandling during serilization
                // link : http://james.newtonking.com/projects/json/help/index.html?topic=html/SerializeTypeNameHandling.htm
                return typeNameHandling ? 
                    JsonConvert.DeserializeObject<dynamic>(jsonString, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }) : 
                    JsonConvert.DeserializeObject<dynamic>(jsonString);                

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
