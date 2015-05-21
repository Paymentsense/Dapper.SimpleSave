using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private static readonly UserDto JohnSmith = new UserDto {
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

        private static readonly UserDto ZargonRemovedDepartment = new UserDto() {
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

        private static readonly UserDto ZargonAddedDepartment = new UserDto() {
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

        private static UserDto GetDto(string name)
        {
            var field = typeof (ThrowawayTests).GetField(name, BindingFlags.NonPublic | BindingFlags.Static);
            return (UserDto) field.GetValue(null);
        }

        [TestCase("JohnSmith", "ZargonRemovedDepartment", 4, 4, 2)]
        [TestCase("JohnSmith", "ZargonAddedDepartment", 4, 4, 2)]
        public void multi_level_updates_generates_correct_sql(
            string oldUserFieldName,
            string newUserFieldName,
            int expectedDifferenceCount,
            int expectedOperationCount,
            int expectedCommandCount)
        {
            var cache = new DtoMetadataCache();
            var differ = new Differ(cache);
            var differences = differ.Diff(GetDto(oldUserFieldName), GetDto(newUserFieldName));

            Assert.AreEqual(expectedDifferenceCount, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

            Assert.AreEqual(expectedOperationCount, operations.Count(), "Unexpected number of operations.");
            Assert.AreEqual(expectedCommandCount, commands.Count(), "Unexpected number of commands.");

            var scriptBuilder = new ScriptBuilder(cache);
            var transactionScript = scriptBuilder.BuildTransaction(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
        }
    }
}
