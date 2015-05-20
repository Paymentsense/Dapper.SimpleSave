using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public static class TypeExtensions
    {
        public static bool IsEnumerable(this Type type)
        {
            return typeof (IEnumerable).IsAssignableFrom(type) || type.IsArray;
        }

        public static bool IsGenericDictionary(this Type type)
        {
            return typeof (IDictionary<,>).IsAssignableFrom(type);
        }
    }
}
