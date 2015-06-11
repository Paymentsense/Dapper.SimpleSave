using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dapper.SimpleSave.Impl
{
    public class Differ
    {
        private readonly DtoMetadataCache _dtoMetadataCache;

        public Differ(DtoMetadataCache dtoMetadataCache)
        {
            _dtoMetadataCache = dtoMetadataCache;
        }

        /// <summary>
        /// Deep diffs the two supplied objects. Either or both can be null. For <code>INSERT</code>s
        /// it's expected that <code>oldObject</code> would be <code>null</code>. Vice versa
        /// for <code>DELETE</code>s. For <code>UPDATE</code> obviously neither should be null but
        /// expect to be yelled at with an <see cref="ArgumentException"/> if the two objects in
        /// question don't represent the same row (i.e., their primary key columns have different
        /// values).
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="oldObject">Old version of object, which is expected to be <code>null</code> for
        /// <code>INSERT</code>s.</param>
        /// <param name="newObject">New version of object, which is expected to be <code>null</code> for
        /// <code>DELETE</code>s.</param>
        /// <returns>List of differences between supplied objects, if any.</returns>
        public IList<Difference> Diff<T>(T oldObject, T newObject)
        {
            return Diff(oldObject, newObject, typeof (T));
        }

        private IList<Difference> Diff(object oldObject, object newObject, Type handleAsType)
        {
            var differences = new List<Difference>();
            Diff(null, null, null, null, oldObject, newObject, handleAsType, differences);
            return differences;
        }

        private void Diff(
            object oldOwner,
            object newOwner,
            DtoMetadata ownerMetadata,
            PropertyMetadata property,
            object oldObject,
            object newObject,
            Type handleAsType,
            IList<Difference> target)
        {
            var metadata = _dtoMetadataCache.GetMetadataFor(handleAsType);
            var doReferenceShortcut = false;
            if (null == oldObject)
            {
                if (null == newObject)
                {
                    return;
                }

                doReferenceShortcut = true;
            }
            else if (null == newObject)
            {
                doReferenceShortcut = true;
            }

            if (doReferenceShortcut)
            {
                DiffReferenceType(oldObject, newObject, null, target, metadata);
            }
            else
            {
                var objKey = metadata.GetPrimaryKeyValue(oldObject);

                if (objKey != metadata.GetPrimaryKeyValue(newObject))
                {
                    if (null == property)
                    {
                        throw new ArgumentException(string.Format(
                            "Cannot diff two objects that do not represent the same row. "
                            + "{0}: primary key does not match - for {1} does not match {2}",
                            handleAsType,
                            objKey,
                            metadata.GetPrimaryKeyValue(newObject)));
                    }

                    target.Add(new Difference
                    {
                        OldOwner = oldOwner,
                        NewOwner = newOwner,
                        DifferenceType = DifferenceType.Update,
                        OldValue = oldObject,
                        NewValue = newObject,
                        ValueMetadata = metadata,
                        OwnerPropertyMetadata = property,
                        OwnerMetadata = ownerMetadata,
                    });
                }
                else
                {
                    DiffProperties(metadata, oldObject, newObject, target);                    
                }
            }
        }

        private void DiffProperties(
            DtoMetadata metadata,
            object oldObject,
            object newObject,
            IList<Difference> target)
        {
            foreach (var prop in metadata.Properties)
            {
                if (prop.IsString || prop.IsNumericType || prop.IsEnum)
                {
                    DiffSimpleValue(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsGenericDictionary)
                {
                    DiffDictionary(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsEnumerable)
                {
                    DiffEnumerable(oldObject, newObject, prop, target, metadata);
                }
                else if (prop.IsReferenceType)
                {
                    DiffReferenceType(oldObject, newObject, prop, target, metadata);
                }
                else
                {
                    DiffSimpleValue(oldObject, newObject, prop, target, metadata);
                }
            }
        }

        private void DiffDictionary(
            object oldObject,
            object newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            var dictType = prop.Prop.PropertyType;
            var args = dictType.GetGenericArguments();
            if (args.Length != 2)
            {
                return;
            }

            var itemType = args [1];

            var values = dictType.GetProperty("Values");
            if (null == values)
            {
                return;
            }

            var getter = values.GetGetMethod();
            if (null == getter)
            {
                return;
            }

            DiffEnumerable(
                oldObject,
                newObject,
                null == oldObject ? new ArrayList() : getter.Invoke(oldObject, new object[0]),
                null == newObject ? new ArrayList() : getter.Invoke(newObject, new object[0]),
                prop,
                differences,
                metadata,
                itemType);
        }

        private void DiffEnumerable<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            var itemType = GetEnumerableItemType(prop);
            if (itemType == null)
            {
                return;
            }

            var getter = prop.Prop.GetGetMethod();
            if (getter == null)
            {
                return;
            }

            DiffEnumerable(
                oldObject,
                newObject,
                null == oldObject ? new ArrayList() : getter.Invoke(oldObject, new object [0]),
                null == newObject ? new ArrayList() : getter.Invoke(newObject, new object [0]),
                prop,
                differences,
                metadata,
                itemType);
        }

        private Type GetEnumerableItemType(PropertyMetadata prop)
        {
            if (prop.Prop.PropertyType.IsConstructedGenericType)
            {
                var args = prop.Prop.PropertyType.GetGenericArguments();
                if (args.Length == 1)
                {
                    return args [0];
                }
            }
            else if (prop.Prop.PropertyType.IsArray)
            {
                return prop.Prop.PropertyType.GetElementType();
            }

            return null;
        }

        private void DiffEnumerable(
            object oldOwner,
            object newOwner,
            object oldEnumerable,
            object newEnumerable,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata,
            Type itemType)
        {
            var itemTypeMeta = _dtoMetadataCache.GetMetadataFor(itemType);
            var pk = itemTypeMeta.PrimaryKey;
            if (null == pk)
            {
                return;
            }

            var oldItems = GetItemDictionary(oldEnumerable as IEnumerable, pk);
            var newItems = GetItemDictionary(newEnumerable as IEnumerable, pk);

            AddDifferencesForItemsInOnlyOneCollection(
                oldOwner, newOwner, metadata, prop, oldItems,
                newItems, itemTypeMeta, DifferenceType.Deletion, differences);
            
            AddDifferencesForItemsInOnlyOneCollection(
                oldOwner, newOwner, metadata, prop, newItems,
                oldItems, itemTypeMeta, DifferenceType.Insertion, differences);

            AddDifferencesForChangedItems(oldItems, newItems, itemType, differences);
        }

        private void AddDifferencesForItemsInOnlyOneCollection(
            object oldOwner,
            object newOwner,
            DtoMetadata metadata,
            PropertyMetadata prop,
            IDictionary<int, object> items1,
            IDictionary<int, object> items2,
            DtoMetadata itemTypeMeta,
            DifferenceType differenceType,
            IList<Difference> differences)
        {
            var removed = FindRemovedItems(items1, items2);

            foreach (var item in removed.Values)
            {
                differences.Add(new Difference
                {
                    OldOwner = oldOwner,
                    NewOwner = newOwner,
                    DifferenceType = differenceType,
                    OwnerPropertyMetadata = prop,
                    OwnerMetadata = metadata,
                    ValueMetadata = itemTypeMeta,
                    NewValue = DifferenceType.Insertion == differenceType ? item : null,
                    OldValue = DifferenceType.Deletion == differenceType ? item : null
                });
            }
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
            Type handleAsType,
            IList<Difference> differences)
        {
            foreach (var key in oldItems.Keys)
            {
                if (newItems.ContainsKey(key))
                {
                    foreach (var diff in Diff(oldItems[key], newItems[key], handleAsType))
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
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            MethodInfo getter = null;

            if (null != prop)
            {
                getter = prop.Prop.GetGetMethod();
                if (null == getter) {
                    return;
                }
            }
            
            var oldPropValue = GetPropertyValueFrom(oldObject, getter);
            var newPropValue = GetPropertyValueFrom(newObject, getter);

            if (null == oldPropValue)
            {
                if (null == newPropValue)
                {
                    return;
                }

                differences.Add(new Difference
                {
                    OldOwner = oldObject,
                    NewOwner = ReferenceEquals(newObject, newPropValue)
                        ? (object) null
                        : newObject,
                    DifferenceType = DifferenceType.Insertion,
                    OwnerPropertyMetadata = prop,
                    OwnerMetadata = null == prop? null : metadata,
                    ValueMetadata = null == prop
                        ? metadata
                        : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                    OldValue = null,
                    NewValue = newPropValue
                });

                DiffProperties(
                    ReferenceEquals(newObject, newPropValue)
                        ? metadata
                        : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                    oldObject,
                    ReferenceEquals(newObject, newPropValue)
                        ? newObject
                        : newPropValue,
                    differences);
            }
            else if (null == newPropValue)
            {
                DiffProperties(
                    ReferenceEquals(oldObject, oldPropValue)
                        ? metadata :
                        _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                    ReferenceEquals(oldObject, oldPropValue)
                        ? oldObject
                        : oldPropValue,
                    newObject,
                    differences);

                differences.Add(new Difference
                {
                    OldOwner = ReferenceEquals(oldObject, oldPropValue)
                        ? (object) null
                        : oldObject,
                    NewOwner = newObject,
                    DifferenceType = DifferenceType.Deletion,
                    OwnerPropertyMetadata = prop,
                    OwnerMetadata = null == prop ? null : metadata,
                    ValueMetadata = null == prop
                        ? metadata
                        : _dtoMetadataCache.GetMetadataFor(prop.Prop.PropertyType),
                    OldValue = oldPropValue,
                    NewValue = null
                });
            }
            else
            {
                Diff(
                    ReferenceEquals(oldObject, oldPropValue) ? (object) null : oldObject,
                    ReferenceEquals(newObject, newPropValue) ? (object) null : newObject,
                    metadata,
                    prop,
                    oldPropValue,
                    newPropValue,
                    prop.Prop.PropertyType,
                    differences);
            }
        }

        private static object GetPropertyValueFrom<T>(T oldObject, MethodInfo getter)
        {
            return null == oldObject
                ? null
                : null == getter ? oldObject : getter.Invoke(oldObject, new object [0]);
        }

        private void DiffSimpleValue<T>(
            T oldObject,
            T newObject,
            PropertyMetadata prop,
            IList<Difference> differences,
            DtoMetadata metadata)
        {
            if (null == oldObject || null == newObject)
            {
                //  Don't need to diff simple values where an object has been created or deleted.
                return;
            }

            var oldValue = prop.GetValue(oldObject);
            var newValue = prop.GetValue(newObject);

            if (AreEqual(oldValue, newValue))
            {
                return;
            }

            differences.Add(new Difference
            {
                OldOwner = oldObject,
                NewOwner = newObject,
                OwnerPropertyMetadata = prop,
                DifferenceType = DifferenceType.Update,
                OwnerMetadata = metadata,
                NewValue = newValue,
                OldValue = oldValue
            });
        }

        private static bool AreEqual(object value1, object value2)
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