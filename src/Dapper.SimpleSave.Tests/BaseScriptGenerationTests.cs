using System.Collections.Generic;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    public abstract class BaseScriptGenerationTests
    {
        protected IList<IScript> Generate<T>(T oldDto, T newDto, int expectedScriptCount)
        {
            var cache = new DtoMetadataCache();
            var builder = new TransactionBuilder(cache);
            var scripts = builder.BuildUpdateScripts(oldDto, newDto);
            
            Assert.AreEqual(
                expectedScriptCount,
                scripts.Count,
                "Unexpected number of scripts.");

            return scripts;
        }
    }
}
