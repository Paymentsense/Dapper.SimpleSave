using System;
using Newtonsoft.Json;

namespace Dapper.SimpleSave.Impl
{
    public static class ScriptParameterHelper
    {
        public static void ValidateParameterValue(
            int index,
            string paramName,
            Tuple<Type, object> paramValue)
        {
            var value = paramValue.Item2;
            if (value == null || value is string || value is DBNull)
            {
                return;
            }

            if (IsSupportableParamType(paramValue.Item1)
                || IsSupportableParamType(value.GetType()))
            {
                return;
            }

            throw new ArgumentException(
                string.Format(
                    "Reference types other than string are not permitted as parameter values for generated SQL. "
                    + "Invalid value at index {0} for parameter @{1}: {2}",
                    index,
                    paramName,
                    JsonConvert.SerializeObject(paramValue)),
                "paramValue");
        }

        public static bool IsSupportableParamType(Type type)
        {
            return type.IsValueType
                || (type.IsConstructedGenericType
                    && type.GetGenericTypeDefinition() == typeof(Func<>));
        }
    }
}
