using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using NUnit.Framework;
using PS.Mothership.Core.Common.Dto.UserV2;

namespace Dapper.SimpleSave.Tests
{

    [TestFixture]
    public class ThrowawayTests
    {

        private UserDto _old;
        private UserDto _new;

        [SetUp]
        public void Setup()
        {
            _old = new UserDto()
            {
                UserKey = 1,
                FirstName = "John",
                LastName = "Smith",
                PhoneNumber = "0207 1234567",
                EmailAddress = "john.smith@paymentsense.com",
                Username = "john.smith"
            };

            _new = new UserDto() {
                UserKey = 1,
                FirstName = "Zargon",
                LastName = "Smith",
                PhoneNumber = "0207 666 6666",
                EmailAddress = "john.smith@paymentsense.com",
                Username = "zargon.smith"
            };
        }

        [Test]
        public void single_level_updates_generate_correct_sql()
        {
            var cache = new DtoMetadataCache();
            var differ = new Differ(cache);
            var differences = differ.Diff(_old, _new);

            Assert.AreEqual(3, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

            Assert.AreEqual(3, operations.Count(), "Unexpected number of oeprations.");
            Assert.AreEqual(1, commands.Count(), "Unexpected number of commands.");

            var scriptBuilder = new ScriptBuilder();
            var transactionScript = scriptBuilder.BuildTransaction(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
        }
    }
}
