using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Difference> Diff<T>(T oldObject, T newObject)
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
                if (prop.IsEnumerable)
                {
                    DiffEnumerable(oldObject, newObject, prop, differences, objKey, metadata);
                }
                else if (prop.IsReferenceType)
                {
                    DiffReferenceType(oldObject, newObject, prop, differences, objKey, metadata);
                }
                else
                {
                    DiffSimpleValue(oldObject, newObject, prop, differences, objKey, metadata);
                }
            }

            return differences;
        }

        private void DiffEnumerable<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            List<Difference> differences,
            int objKey,
            DtoMetadata metadata)
        {
            Type itemType = null;
            if (prop.Prop.PropertyType.IsConstructedGenericType)
            {
                var args = itemType.GetGenericArguments();
                if (args.Length != 1)
                {
                    return;
                }
                itemType = args[0];
            }
            else if (prop.Prop.PropertyType.IsArray)
            {
                itemType = prop.Prop.PropertyType.GetElementType();
            }

            if (itemType == null)
            {
                return;
            }

            var itemTypeMeta = _dtoMetadataCache.GetMetadataFor(itemType);
            var pk = itemTypeMeta.PrimaryKey;
            if (null == pk)
            {
                return;
            }

            var oldItems = GetItemDictionary(oldObject as IEnumerable, pk);
            var newItems = GetItemDictionary(newObject as IEnumerable, pk);

            var removed = FindRemovedItems(oldItems, newItems);
            foreach (var item in removed.Values)
            {
                differences.Add(new Difference
                {
                    DifferenceType = DifferenceType.Removed,
                    Id = objKey,
                    Property = prop,
                    TypeMetadata = metadata,
                    NewValue = null,
                    OldValue = item
                });
            }

            var added = FindRemovedItems(newItems, oldItems);
            foreach (var item in added.Values) {
                differences.Add(new Difference {
                    DifferenceType = DifferenceType.Added,
                    Id = objKey,
                    Property = prop,
                    TypeMetadata = metadata,
                    NewValue = item,
                    OldValue = null
                });
            }

            AddDifferencesForChangedItems(oldItems, newItems, differences);
        }

        private IDictionary<int, object> GetItemDictionary(IEnumerable enumerable, PropertyMetadata pkProp)
        {
            var results = new Dictionary<int, object>();
            if (enumerable != null)
            {
                var getter = pkProp.Prop.GetGetMethod();
                foreach (var item in enumerable)
                {
                    results [(int)getter.Invoke(item, new object [0])] = item;
                }
            }
            return results;
        }

        private IDictionary<int, object> FindRemovedItems(
            IDictionary<int, object> dict1,
            IDictionary<int, object> dict2)
        {
            if (null == dict1)
            {
                return new Dictionary<int, object>();
            }
            
            if (null == dict2)
            {
                return dict1;
            }

            var results = new Dictionary<int, object>();
            foreach (var key in dict1.Keys.Where(key => !dict2.ContainsKey(key)))
            {
                results[key] = dict1[key];
            }
            return results;
        }

        private void AddDifferencesForChangedItems(
            IDictionary<int, object> oldItems,
            IDictionary<int, object> newItems,
            IList<Difference> differences)
        {
            foreach (var key in oldItems.Keys)
            {
                if (newItems.ContainsKey(key))
                {
                    foreach (var diff in Diff(oldItems[key], newItems[key]))
                    {
                        differences.Add(diff);
                    }
                }
            }
        }

        private void DiffReferenceType<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            List<Difference> differences,
            int objKey,
            DtoMetadata metadata)
        {
            if (null == oldObject)
            {
                if (null == newObject)
                {
                    return;
                }

                differences.Add(new Difference
                {
                    DifferenceType = DifferenceType.Added,
                    Id = objKey,
                    Property = prop,
                    TypeMetadata = metadata,
                    NewValue = newObject,
                    OldValue = null
                });
            }
            else if (null == newObject)
            {
                differences.Add(new Difference
                {
                    DifferenceType = DifferenceType.Removed,
                    Id = objKey,
                    Property = prop,
                    TypeMetadata = metadata,
                    NewValue = null,
                    OldValue = oldObject
                });
            }
            else
            {
                foreach (var diff in Diff(oldObject, newObject))
                {
                    differences.Add(diff);
                }
            }
        }

        private void DiffSimpleValue<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            List<Difference> differences,
            int objKey,
            DtoMetadata metadata)
        {
            var oldValue = prop.GetValue(oldObject);
            var newValue = prop.GetValue(newObject);

            if (AreEqual(oldValue, newValue))
            {
                return;
            }

            differences.Add(new Difference
            {
                Property = prop,
                Id = objKey,
                DifferenceType = DifferenceType.Changed,
                NewValue = newValue,
                TypeMetadata = metadata,
                OldValue = oldValue
            });
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