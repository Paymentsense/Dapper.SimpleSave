using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    internal static class ScriptsAssertions
    {
        public static int AssertFragment(this IList<IScript> scripts, int scriptIndex, string expectedFragment)
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

        public static int AssertNoFragment(this IList<IScript> scripts, int scriptIndex, string unexpectedFragment)
        {
            var sql = scripts[scriptIndex].Buffer.ToString();
            var index = sql.IndexOf(unexpectedFragment);
            Assert.IsTrue(
                index < 0,
                string.Format("Unexpected fragment '{0}' found in script index {1} at character index {2}: {3}",
                unexpectedFragment,
                scriptIndex,
                index,
                sql));

            return index;
        }
    }
}
