using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

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
        /// Method to convert dynamic object to Bson
        /// </summary>        
        /// <param name="objData"></param>
        /// <returns></returns>        
        public static byte[] ConvertToBson(dynamic objData)
        {
            try
            {
                var ms = new MemoryStream();
                var serializer = new JsonSerializer();

                // serialize product to BSON
                var writer = new BsonWriter(ms);                
                serializer.Serialize(writer, objData);
                return ms.ToArray();
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

        /// <summary>
        /// Convert json string to strong typed object
        /// </summary>
        /// <typeparam name="T"></typeparam>        
        /// <param name="bsonBytes"></param>        
        /// <returns></returns>
        public static T ConvertFromBson<T>(byte[] bsonBytes) where T : class
        {
            try
            {
                // deserialize product from BSON
                var msread = new MemoryStream(bsonBytes);
                var reader = new BsonReader(msread);
                var serializer = new JsonSerializer();
                var outObject = serializer.Deserialize<T>(reader);
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
