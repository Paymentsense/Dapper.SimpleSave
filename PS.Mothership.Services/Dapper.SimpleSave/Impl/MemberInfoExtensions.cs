using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public static class MemberInfoExtensions {

        public static IDictionary<Type, Attribute> GetAttributesDict(this MemberInfo member)
        {
            var target = new Dictionary<Type, Attribute>();
            foreach (var attr in member.GetCustomAttributes(true).OfType<Attribute>())
            {
                target[attr.GetType()] = attr;
            }
            return target;
        } 
    }
}
