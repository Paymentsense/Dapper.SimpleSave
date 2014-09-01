using System;
using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PS.Mothership.Core.Common.Log4NetJsonFormatter.Entities;

namespace PS.Mothership.Core.Common.Log4NetJsonFormatter
{
    public sealed class JsonPatternLayoutConverter : PatternLayoutConverter
    {
        /// <summary>
        /// This will always returns false which ignores the Exceptionobject to be written into log file.
        /// </summary>
        public override bool IgnoresException
        {
            get
            {
                return false;
            }
            set
            {
                base.IgnoresException = value;
            }
        }

        public static string AssemblyName { get; set; }
        public static string ApplicationName { get; set; }
        // the aim of overriding the convert within the log4net layout is so that stack-traces and multi-line messages
        // don't break our json format.
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            dynamic loggingEntity = null;

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            //for Error type create ErrorLoggingEntity and fetch uniquekey, exception object if it exists
            if (loggingEvent.Level == Level.Error)
            {
                if (IsUniqueKey(loggingEvent.RenderedMessage))
                {
                    //if unique key is present then add into the ErrorLoggingEntity
                    loggingEntity = new ErrorLoggingEntity
                    {
                        UniqueKey = loggingEvent.RenderedMessage,
                        Message =
                            loggingEvent.ExceptionObject != null
                                ? loggingEvent.ExceptionObject.ToString()
                                : string.Empty
                    };
                }
                else
                {
                    loggingEntity = new LoggingEntity
                    {
                        Message =
                            loggingEvent.ExceptionObject != null
                                ? string.Format("{0} - {1}", loggingEvent.RenderedMessage, loggingEvent.ExceptionObject.ToString())
                                : loggingEvent.RenderedMessage
                    };
                }
            }
            else
            {
                //for all other types use base type loggingEntity
                loggingEntity = new LoggingEntity
                {
                    Message = loggingEvent.RenderedMessage
                };
            }

            loggingEntity.Date = loggingEvent.TimeStamp.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss");
            loggingEntity.ApplicationName = ApplicationName;
            loggingEntity.AssemblyName = AssemblyName;
            loggingEntity.ErrorLevel = loggingEvent.Level.ToString();
            loggingEntity.Thread = loggingEvent.ThreadName;

            var errorJson = Newtonsoft.Json.JsonConvert.SerializeObject(loggingEntity, settings);
            writer.Write(errorJson);
        }

        private static bool IsUniqueKey(string value)
        {
            if (value.Length == 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i < 4)
                    {
                        if (!Char.IsDigit(value[i]))
                        {
                            return false;
                        }
                    }
                    else if (!Char.IsLetterOrDigit(value[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
