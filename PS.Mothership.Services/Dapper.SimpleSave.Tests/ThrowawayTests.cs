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
                Username = "john.smith",
                Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "The Flying Squad"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "The Pancake Landing Squad"
                    } 
                })
            };
        }

        [Test]
        public void multi_level_updates_with_department_removal_generates_correct_sql()
        {
            var newUser = new UserDto() {
                UserKey = 1,
                FirstName = "Zargon",
                LastName = "Smith",
                PhoneNumber = "0207 666 6666",
                EmailAddress = "john.smith@paymentsense.com",
                Username = "zargon.smith",
                Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "The Pancake Landing Squad"
                    } 
                })
            };
            
            var cache = new DtoMetadataCache();
            var differ = new Differ(cache);
            var differences = differ.Diff(_old, newUser);

            Assert.AreEqual(4, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

            Assert.AreEqual(4, operations.Count(), "Unexpected number of operations.");
            Assert.AreEqual(2, commands.Count(), "Unexpected number of commands.");

            var scriptBuilder = new ScriptBuilder(cache);
            var transactionScript = scriptBuilder.BuildTransaction(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
        }

        [Test]
        public void multi_level_updates_with_department_added_generates_correct_sql() {
            var newUser = new UserDto() {
                UserKey = 1,
                FirstName = "Zargon",
                LastName = "Smith",
                PhoneNumber = "0207 666 6666",
                EmailAddress = "john.smith@paymentsense.com",
                Username = "zargon.smith",
                Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "The Flying Squad"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "The Pancake Landing Squad"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 3,
                        Name = "Zombie Hunters"
                    }
                })
            };

            var cache = new DtoMetadataCache();
            var differ = new Differ(cache);
            var differences = differ.Diff(_old, newUser);

            Assert.AreEqual(4, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

            Assert.AreEqual(4, operations.Count(), "Unexpected number of operations.");
            Assert.AreEqual(2, commands.Count(), "Unexpected number of commands.");

            var scriptBuilder = new ScriptBuilder(cache);
            var transactionScript = scriptBuilder.BuildTransaction(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
        }
    }
}
