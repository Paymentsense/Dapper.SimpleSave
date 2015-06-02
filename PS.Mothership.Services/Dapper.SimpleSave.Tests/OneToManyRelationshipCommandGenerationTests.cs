using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests {

    [TestFixture]
    public class OneToManyRelationshipCommandGenerationTests : BaseTests {

        [Test]
        public void insert_with_no_reference_data_inserts_in_parent_and_child()
        {
            var newDto = new ParentDto {
                OneToManyChildDto = new OneToManyChildDto()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var command = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for parent.");

            command = list[1] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManyChildDto)).TableName,
                command.Operation.ValueMetadata.TableName,
                "Unexpected table name for child.");
        }

        [Test]
        public void update_with_no_reference_data_updates_in_parent_and_child() {
            var oldDto = new ParentDto {
                ParentKey = 1,
                OneToManyChildDto = new OneToManyChildDto
                {
                    ChildKey = 2
                }
            };

            var newDto = new ParentDto
            {
                ParentKey = 1,
                ParentName = "ParentNameUpdated",
                OneToManyChildDto = new OneToManyChildDto
                {
                    ChildKey = 2,
                    Name = "Maximum Whoopee! Enabled"
                }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, oldDto, newDto, 2, 2, 0, 2, 0, 2, 0, 2, 0);
            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");

            var command = list[0] as UpdateCommand;
            
            Assert.AreEqual(
                cache.GetMetadataFor(typeof(OneToManyChildDto)).TableName,
                command.TableName,
                "Unexpected child table name.");

            Assert.AreEqual(
                "ChildKey",
                command.PrimaryKeyColumn,
                "Unexpected child primary key column.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of update operations on child table.");

            Assert.AreEqual(
                "Name",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column for child table UPDATE.");

            Assert.AreEqual(
                newDto.OneToManyChildDto.Name,
                command.Operations.FirstOrDefault().Value,
                "Unexpected child column value.");

            command = list[1] as UpdateCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ParentDto)).TableName,
                command.TableName,
                "Unexpected parent table name.");

            Assert.AreEqual(
                "ParentKey",
                command.PrimaryKeyColumn,
                "Unexpected parent primary key column.");

            Assert.AreEqual(
                1,
                command.Operations.Count(),
                "Unexpected number of update operations on child table.");

            Assert.AreEqual(
                "ParentName",
                command.Operations.FirstOrDefault().OwnerPropertyMetadata.ColumnName,
                "Unexpected column for parent table UPDATE.");

            Assert.AreEqual(
                newDto.ParentName,
                command.Operations.FirstOrDefault().Value,
                "Unexpected parent column value.");
        }

        [Test]
        public void delete_with_no_reference_data_deletes_in_parent_and_child() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_child_is_invalid() {
            var newDto = new ParentDto {
                OneToManyReferenceChildDto = new OneToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        public void insert_with_special_data_in_child_inserts_in_parent_and_updates_child() {
            var newDto = new ParentDto {
                OneToManySpecialChildDto = new OneToManySpecialChildDto()
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);

            var list = new List<BaseCommand>(commands);

            Assert.AreEqual(
                2,
                list.Count,
                "Unexpected number of commands.");
        }

        [Test]
        public void update_with_special_data_in_child_updates_parent() {
            throw new NotImplementedException();
        }

        [Test]
        public void delete_with_special_data_in_child_updates_child_and_deletes_parent() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_is_invalid() {
            var newDto = new ParentReferenceDto {
                OneToManyChildDto = new OneToManyChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void insert_with_reference_data_in_parent_and_child_is_invalid() {
            var newDto = new ParentReferenceDto {
                OneToManyReferenceChildDto = new OneToManyReferenceChildDto()
            };

            var cache = new DtoMetadataCache();
            GetCommands(cache, null, newDto, 2, 2, 1, 1, 0, 2, 1, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_reference_data_in_parent_and_child_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void insert_with_special_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void update_with_special_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void delete_with_special_data_in_parent_is_not_supported() {
            throw new NotImplementedException();
        }
    }
}
