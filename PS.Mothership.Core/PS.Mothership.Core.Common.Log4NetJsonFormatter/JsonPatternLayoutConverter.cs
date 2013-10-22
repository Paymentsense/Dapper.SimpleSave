using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PS.Mothership.Core.Common.Log4NetJsonFormatter
{
    public sealed class JsonPatternLayoutConverter : PatternLayoutConverter
    {
        public static string AssemblyName { get; set; }
        // the aim of overriding the convert within the log4net layout is so that stack-traces and multi-line messages
        // don't break our json format.
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var error = new ErrorEntity 
                { 
                    Date = loggingEvent.TimeStamp.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss"),
                    ApplicationName = loggingEvent.Domain,
                    AssemblyName = AssemblyName,
                    ErrorLevel = loggingEvent.Level.ToString(),
                    ErrorMessage = loggingEvent.RenderedMessage,
                    Thread = loggingEvent.ThreadName
                };

            var errorJson = Newtonsoft.Json.JsonConvert.SerializeObject(error, settings);
            writer.Write(errorJson);
        }
    }
}
