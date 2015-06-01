using System;
using System.Collections;
using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {
    public abstract class BaseTests {

        protected void CheckCount(IDictionary<Type, int> counts, Type type, int expectedCount) {
            Assert.AreEqual(
                expectedCount,
                counts.ContainsKey(type) ? counts [type] : 0,
                string.Format("Unexpected count for {0}", type));
        }

        protected IDictionary<Type, int> CountItemsByType(IEnumerable items) {
            var results = new Dictionary<Type, int>();
            foreach (var item in items) {
                Type type = item.GetType();
                results [type] = results.ContainsKey(type) ? results [type] + 1 : 1;
            }
            return results;
        }

        protected void CheckNoReferenceTypesInParameters(IList<Script> transactionScript) {
            foreach (var script in transactionScript) {
                foreach (var name in script.Parameters.Keys) {
                    var value = script.Parameters [name];
                    if (null == value || value is string) {
                        continue;
                    }

                    var type = value.GetType();
                    if (type.IsValueType
                        || (type.IsConstructedGenericType
                            && type.GetGenericTypeDefinition() == typeof(Func<>))) {
                        continue;
                    }

                    Assert.Fail("Unexpected reference type as value for parameter {0}: {1}", name, type.FullName);
                }
            }
        }
    }
}
