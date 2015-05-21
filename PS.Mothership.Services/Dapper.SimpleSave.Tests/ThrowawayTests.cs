using System;
using System.Collections;
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

        private static readonly UserDto ZargonComplexUpdates = new UserDto() {
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
                },
                new DepartmentDto
                {
                    DepartmentKey = 3,
                    Name = "Zombie Hunters"
                }
            }),
            Team = new List<TeamDto>(new []
            {
                new TeamDto
                {
                    TeamKey = 1,
                    Name = "The A-Team"
                }
            }),
            AdditionalRoles = new List<RoleDto>(new []
            {
                new RoleDto
                {
                    RoleKey = 1,
                    Name = "Howling Mad Murdoch Replacement"
                }
            })
        };

        private static UserDto GetDto(string name)
        {
            var field = typeof (ThrowawayTests).GetField(name, BindingFlags.NonPublic | BindingFlags.Static);
            return (UserDto) field.GetValue(null);
        }

        [TestCase("JohnSmith", "ZargonRemovedDepartment", 4, 4, 0, 3, 1, 2, 0, 1, 1)]
        [TestCase("JohnSmith", "ZargonAddedDepartment", 4, 4, 1, 3, 0, 2, 1, 1, 0)]
        [TestCase("JohnSmith", "ZargonComplexUpdates", 7, 7, 3, 3, 1, 5, 3, 1, 1)]
        public void multi_level_updates_generates_correct_sql(
            string oldUserFieldName,
            string newUserFieldName,
            int expectedDifferenceCount,
            int expectedOperationCount,
            int expectedInsertOperations,
            int expectedUpdateOperations,
            int expectedDeleteOperations,
            int expectedCommandCount,
            int expectedInsertCommands,
            int expectedUpdateCommands,
            int expectedDeleteCommands)
        {
            var cache = new DtoMetadataCache();
            var differ = new Differ(cache);
            var differences = differ.Diff(GetDto(oldUserFieldName), GetDto(newUserFieldName));

            Assert.AreEqual(expectedDifferenceCount, differences.Count(), "Unexpected number of differences.");

            var operationBuilder = new OperationBuilder();
            var operations = operationBuilder.Build(differences);
            var commands = operationBuilder.Coalesce(operations);

            Assert.AreEqual(expectedOperationCount, operations.Count(), "Unexpected number of operations.");
            var counts = CountItemsByType(operations);
            CheckCount(counts, typeof(InsertOperation), expectedInsertOperations);
            CheckCount(counts, typeof(UpdateOperation), expectedUpdateOperations);
            CheckCount(counts, typeof(DeleteOperation), expectedDeleteOperations);

            Assert.AreEqual(expectedCommandCount, commands.Count(), "Unexpected number of commands.");
            counts = CountItemsByType(commands);
            CheckCount(counts, typeof(InsertCommand), expectedInsertCommands);
            CheckCount(counts, typeof(UpdateCommand), expectedUpdateCommands);
            CheckCount(counts, typeof(DeleteCommand), expectedDeleteCommands);

            var scriptBuilder = new ScriptBuilder(cache);
            var transactionScript = scriptBuilder.BuildTransaction(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
            Assert.IsTrue(transactionScript.Length > 0, "#badtimes - empty transaction script");
        }

        private void CheckCount(IDictionary<Type, int> counts, Type type, int expectedCount)
        {
            Assert.AreEqual(
                expectedCount,
                counts.ContainsKey(type) ? counts[type] : 0,
                string.Format("Unexpected count for {0}", type));
        }

        private IDictionary<Type, int> CountItemsByType(IEnumerable items)
        {
            var results = new Dictionary<Type, int>();
            foreach (var item in items)
            {
                Type type = item.GetType();
                results[type] = results.ContainsKey(type) ? results[type] + 1 : 1;
            }
            return results;
        }
    }
}
