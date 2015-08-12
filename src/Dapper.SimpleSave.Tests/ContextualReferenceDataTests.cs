using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    public class ContextualReferenceDataTests : BaseTests
    {
        [Test]
        public void insert_with_fk_on_existing_child_no_reference_data_inserts_parent_and_not_child()
        {
            var newDto = new ContextualReferenceDataParentDto()
            {
                OneToOneChildDtoWithFk = new OneToOneChildDtoWithFk { ChildKey = 943982 }
            };

            var cache = new DtoMetadataCache();
            var commands = GetCommands(cache, null, newDto, 2, 2, 2, 0, 0, 2, 2, 0, 0);
            var list = new List<BaseCommand>(commands);

            var parentInsert = list[0] as InsertCommand;

            Assert.AreEqual(
                cache.GetMetadataFor(typeof(ContextualReferenceDataParentDto)).TableName,
                parentInsert.Operation.ValueMetadata.TableName,
                "Unexpected parent table name.");

            Assert.That(list.Count, Is.EqualTo(1));
        }


    }
}
