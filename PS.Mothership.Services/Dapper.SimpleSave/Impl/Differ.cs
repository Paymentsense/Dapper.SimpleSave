using System;
using System.Collections.Generic;
using System.Threading;

namespace Dapper.SimpleSave.Impl
{
    public class Differ
    {
        private readonly DtoMetadataCache _dtoMetadataCache;

        public Differ(DtoMetadataCache dtoMetadataCache)
        {
            _dtoMetadataCache = dtoMetadataCache;
        }

        public IEnumerable<Difference> Diff<T>(T oldObject, T newObject)
        {
            var differences = new List<Difference>();
            var metadata = _dtoMetadataCache.GetMetaDataFor<T>();

            var objKey = metadata.GetPrimaryKeyValue(oldObject);

            if (objKey != metadata.GetPrimaryKeyValue(newObject))
            {
                throw new ArgumentException(string.Format(
                    "{0}: primary key does not match - for {1} does not match {2}",
                    typeof (T),
                    objKey,
                    metadata.GetPrimaryKeyValue(newObject)));
            }

            foreach (var prop in metadata.Properties)
            {
                var oldValue = prop.GetValue(oldObject);
                var newValue = prop.GetValue(newObject);

                if (AreEqual(oldValue, newValue))
                {
                    continue;
                }
            
               differences.Add(new Difference
               {
                 Property  = prop,
                 ID = objKey,
                 NewValue = newValue,
                 ObjectType = typeof(T),
                 OldValue = oldValue
               });
            }

            return differences;
        }

        private bool AreEqual(object value1, object value2)
        {
            if (value1 == value2)
            {
                return true;
            }
            
            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.Equals(value2);
        }
    }
}