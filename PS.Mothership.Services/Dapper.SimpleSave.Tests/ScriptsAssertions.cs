using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    internal static class ScriptsAssertions
    {
        public static int AssertFragment(this IList<Script> scripts, int scriptIndex, string expectedFragment)
        {
            var sql = scripts[scriptIndex].Buffer.ToString();
            var index = sql.IndexOf(expectedFragment);
            Assert.IsTrue(
                index >= 0,
                string.Format("Expected fragment '{0}' not found in script at index {1}: {2}",
                expectedFragment,
                scriptIndex,
                sql));

            return index;
        }
    }
}
