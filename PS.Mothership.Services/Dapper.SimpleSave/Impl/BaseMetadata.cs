using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Impl {
    public abstract class BaseMetadata {
        private IDictionary<Type, Attribute> _attributes = new Dictionary<Type, Attribute>();

        public BaseMetadata(MemberInfo member)
        {
            _attributes = member.GetAttributesDict();
        }

        public bool HasAttribute<T>() where T : Attribute {
            return _attributes.ContainsKey(typeof(T));
        }

        public T GetAttribute<T>() where T : Attribute {
            Attribute attr;
            _attributes.TryGetValue(typeof(T), out attr);
            return (T) attr;
        }
    }
}
