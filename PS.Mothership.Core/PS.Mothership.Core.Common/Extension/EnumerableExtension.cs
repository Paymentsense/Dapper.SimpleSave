using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PS.Mothership.Core.Common.Extension
{
    public static class EnumerableExtension
    {
        public static IList ToList(this IEnumerable enumerable, Type type)
        {
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            foreach (var item in enumerable)
            {
                list.Add(item);
            }
            return list;
        }

        public static object ToArray(this IEnumerable enumerable, Type type)
        {
            var list = Array.CreateInstance(type, enumerable.Cast<object>().Count());
            var index = 0;
            foreach (var item in enumerable)
            {
                list.SetValue(item, index++);
            }
            return list;
        }

        public static SortedList<T, int> GetClusters<T>(this IEnumerable<T> list) where T : IComparable
        {
            return new SortedList<T, int>(
                list.GroupBy(li => li)
                    .ToDictionary(grouping => grouping.Key, grouping => grouping.Count()));
        }

        public static List<PropertyInfo> ToPropertyInfoList(this IEnumerable<string> propertyNames, Type type, bool includeSubProperties = false)
        {
            List<string> notParsed;
            return ToPropertyInfoList(propertyNames, type, out notParsed);
        }

        public static List<PropertyInfo> ToPropertyInfoList(this IEnumerable<string> propertyNames, Type type, out List<string> notParsed, bool includeSubProperties = false)
        {
            var notParsedProperties = new List<string>();
            if (propertyNames == null || propertyNames.Count() == 0)
            {
                notParsed = notParsedProperties;
                return new List<PropertyInfo>();
            }
            var firstLevelPropertyNames = propertyNames
                 .Select(n =>
                 {
                     var index = n.IndexOf('.');
                     return new
                     {
                         PropertName = index >= 0 ? n.Substring(0, index) : n,
                         Rest = index >= 0 ? n.Substring(n.IndexOf('.') + 1) : ""
                     };
                 })
                 .GroupBy(t => t.PropertName)
                 .Select(g => new
                 {
                     PropertyName = g.Key,
                     SubProperties = g.Select(gr => gr.Rest).Where(s => !string.IsNullOrEmpty(s.Trim())).ToList()
                 });

            var firstLevelProp = type.GetProperties().Where(p => firstLevelPropertyNames.Count(f => f.PropertyName == p.Name) == 1).ToList();
            if (firstLevelProp.Count != firstLevelPropertyNames.Count())
            {
                var names = firstLevelProp.Select(p => p.Name).ToList();
                notParsedProperties.AddRange(firstLevelPropertyNames.Where(p => !names.Contains(p.PropertyName)).Select(p => p.PropertyName));
            }
            if (includeSubProperties)
                firstLevelProp.AddRange(
                     firstLevelPropertyNames.SelectMany(
                          f =>
                          {
                              var prop = firstLevelProp.Where(p => p.Name == f.PropertyName).FirstOrDefault();
                              List<PropertyInfo> result;
                              if (prop == null)
                                  result = new List<PropertyInfo>();
                              else
                              {
                                  List<string> notParsedSubProperty;
                                  result = f.SubProperties.ToPropertyInfoList(prop.PropertyType, out notParsedSubProperty);
                                  notParsedProperties.AddRange(notParsedSubProperty);
                              }
                              return result;
                          }));
            notParsed = notParsedProperties;
            return firstLevelProp;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || enumerable.Any() == false;
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsNullOrEmpty() == false;
        }

        public static bool IsNotEmptyOrSingle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Count() > 1;
        }

        /// <summary>
        /// Count items in list - if null, returns 0
        /// </summary>
        public static int CountNullable<T>(this IEnumerable<T> list)
        {
            return list == null ? 0 : list.Count();
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
