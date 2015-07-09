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
    public class ScriptGenerationOutlineTests : BaseTests
    {

        public static readonly UserDto JohnSmith = new UserDto {
            UserKey = 1,
            FirstName = "John",
            LastName = "Smith",
            CountryCode = "44",
            PersonalMobileNumber = "0777 1234567",
            EmailAddress = "john.smith@paymentsense.com",
            Username = "john.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto
            {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "Field-Sales"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    } 
                })
        };

        public static readonly UserDto JohnSmithPositionChange = new UserDto {
            UserKey = 1,
            FirstName = "John",
            LastName = "Smith",
            CountryCode = "44",
            PersonalMobileNumber = "0777 1234567",
            EmailAddress = "john.smith@paymentsense.com",
            Username = "john.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto {
                PositionKey = 4,
                Name = "Team Leader"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "Field-Sales"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    } 
                })
        };

        public static readonly UserDto ZargonRemovedDepartment = new UserDto {
            UserKey = 1,
            FirstName = "Zargon",
            LastName = "Smith",
            CountryCode = "44",
            PersonalMobileNumber = "0777 666 6666",
            EmailAddress = "john.smith@paymentsense.com",
            Username = "zargon.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    } 
                })
        };

        public static readonly UserDto ZargonAddedDepartment = new UserDto {
            UserKey = 1,
            FirstName = "Zargon",
            LastName = "Smith",
            CountryCode = "44",
            PersonalMobileNumber = "0777 666 6666",
            EmailAddress = "john.smith@paymentsense.com",
            Username = "zargon.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
                {
                    new DepartmentDto
                    {
                        DepartmentKey = 1,
                        Name = "Field-Sales"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 2,
                        Name = "Pro-Support"
                    },
                    new DepartmentDto
                    {
                        DepartmentKey = 3,
                        Name = "Customer Service"
                    }
                })
        };

        public static readonly UserDto ZargonComplexUpdates = new UserDto {
            UserKey = 1,
            FirstName = "Zargon",
            LastName = "Smith",
            CountryCode = "44",
            PersonalMobileNumber = "0777 666 6666",
            EmailAddress = "john.smith@paymentsense.com",
            Username = "zargon.smith",
            Password = "TODO",
            PasswordSalt = "TODO",
            Status = UserStatusEnum.Active,
            Position = new PositionDto {
                PositionKey = 5,
                Name = "Employee"
            },
            Department = new List<DepartmentDto>(new []
            {
                new DepartmentDto
                {
                    DepartmentKey = 2,
                    Name = "Pro-Support"
                },
                new DepartmentDto
                {
                    DepartmentKey = 3,
                    Name = "Customer Service"
                }
            }),
            Team = new List<TeamDto>(new []
            {
                new TeamDto
                {
                    TeamKey = 1,
                    Name = "Kraken"
                }
            }),
            AdditionalRoles = new List<RoleDto>(new []
            {
                new RoleDto
                {
                    RoleKey = 1,
                    Name = "TeleSales"
                }
            })
        };

        public static readonly UserDto UserWithPosition = new UserDto
        {
            Username = "hfdgfdsgdfq.gsdfgfds",
            EmailAddress = "hfdgfdsgdfq.gsdfgfds@paymentsense.com",
            FirstName = "hfdgfdsgdfq",
            LastName = "gsdfgfds",
            Position = new PositionDto
            {
                PositionKey = 2,
                Name = "Head"
            },
            Department = new List<DepartmentDto>(new[]
            {
                new DepartmentDto
                {
                    DepartmentKey = 1,
                    Name = "Field-Sales"
                }
            }),
            AdditionalRoles = new List<RoleDto>(new[]
            {
                new RoleDto
                {
                    RoleKey = 1,
                    Name = "TeleSales"
                }
            }),
            Team = new List<TeamDto>(new[]
            {
                new TeamDto
                {
                    TeamKey = 0,
                    Name = "Phoenix"
                }
            }),
            PersonalMobileNumber = "543254",
            Status = UserStatusEnum.Active,
            OfficeNumber = new OfficeNumberDto
            {
                OfficeNumberKey = 4,
                Number = "02075555555"
            }
        };

        public static UserDto GetDto(string name)
        {
            if (name == null)
            {
                return null;
            }
            var field = typeof (ScriptGenerationOutlineTests).GetField(name, BindingFlags.Public | BindingFlags.Static);
            return (UserDto) field.GetValue(null);
        }

        [TestCase(null, "JohnSmith", 4, 3, 3, 0, 0, 3, 3, 0, 0)]
        [TestCase(null, "ZargonComplexUpdates", 6, 5, 5, 0, 0, 5, 5, 0, 0)]
        [TestCase("JohnSmith", "ZargonRemovedDepartment", 4, 4, 0, 3, 1, 2, 0, 1, 1)]
        [TestCase("JohnSmith", "ZargonAddedDepartment", 4, 4, 1, 3, 0, 2, 1, 1, 0)]
        [TestCase("JohnSmith", "ZargonComplexUpdates", 7, 7, 3, 3, 1, 5, 3, 1, 1)]
        [TestCase("JohnSmith", null, 4, 3, 0, 0, 3, 3, 0, 0, 3)]
        [TestCase("JohnSmith", "JohnSmithPositionChange", 1, 1, 0, 1, 0, 1, 0, 1, 0)]
        [TestCase("ZargonComplexUpdates", null, 6, 5, 0, 0, 5, 5, 0, 0, 5)]
        [TestCase(null, "UserWithPosition", 6, 4, 4, 0, 0, 4, 4, 0, 0)]
        public void creates_updates_and_deletes_generate_correct_script_shape(
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

            var commandBuilder = new CommandBuilder();
            var commands = commandBuilder.Coalesce(operations);

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
            var transactionScript = scriptBuilder.Build(commands);

            Assert.IsNotNull(transactionScript, "#badtimes - null transaction script");
            Assert.IsTrue(transactionScript.Count > 0, "Should be at least one script.");
            foreach (var script in transactionScript)
            {
                Assert.IsTrue(script.Buffer.Length > 0, "#badtimes - empty transaction script");                
            }

            CheckNoReferenceTypesInParameters(transactionScript);
        }
    }
}
