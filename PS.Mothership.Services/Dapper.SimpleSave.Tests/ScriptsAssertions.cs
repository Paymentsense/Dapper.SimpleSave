using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    internal static class ScriptsAssertions
    {
        public static void AssertFragment(this IList<Script> scripts, int scriptIndex, string expectedFragment)
        {
            var sql = scripts[scriptIndex].Buffer.ToString();
            Assert.IsTrue(
                sql.Contains(expectedFragment),
                string.Format("Expected fragment '{0}' not found in script at index {1}: {2}",
                expectedFragment,
                scriptIndex,
                sql));
        }
    }
}
