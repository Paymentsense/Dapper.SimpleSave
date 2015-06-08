using System;
using System.Collections.Generic;

namespace Dapper.SimpleSave.Impl
{
    public class DtoMetadataCache
    {
        private readonly IDictionary<Type, DtoMetadata> _metadata = new Dictionary<Type, DtoMetadata>();
        private readonly object _lock = new object();

        public DtoMetadata GetMetadataFor(Type type)
        {
            if (type == typeof (string))
            {
                throw new ArgumentException(
                    "DtoMetadata retrieval is not supported for strings.",
                    "type");
            }

            lock (_lock)
            {
                DtoMetadata data;
                _metadata.TryGetValue(type, out data);
                if (null == data)
                {
                    data = new DtoMetadata(type);
                    _metadata.Add(type, data);
                }
                return data;
            }
        }

        public DtoMetadata GetMetaDataFor<T>()
        {
            return GetMetadataFor(typeof(T));
        }

        public bool HasMetaDataFor(Type type)
        {
            lock (_lock)
            {
                return _metadata.ContainsKey(type);
            }
        }
    }
}
