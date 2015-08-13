using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Impl;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class ContextualReferenceDataTests : BaseTests
    {
        [Test]
        public void insert_with_fk_on_existing_child_no_reference_data_inserts_parent_and_not_child()
        {
            var logger = CreateMockLogger();

            var newDto = new ContextualReferenceDataParentDto()
            {
                OneToOneChildDtoWithFk = new ContextualOneToOneChildDtoWithFk
                {
                    ChildKey = 100,
                    Name = "You, sir, are drunk!"
                }
            };

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(newDto);
                }
            }
            catch (InvalidOperationException)
            {
                // Do nothing because we deliberately didn't open the connection
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(2, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();
            Assert.IsTrue(sql.Contains("INSERT INTO dbo.[ContextualReferenceDataParent]"), "No INSERT on parent.");

            sql = scripts[1].Buffer.ToString();
            Assert.IsTrue(sql.Contains("UPDATE dbo.ContextualOneToOneChildWithFk"), "Should be an UPDATE on child.");
        }

        [Test]
        public void insert_with_fk_on_existing_special_child_inserts_parent_and_not_child()
        {
            var logger = CreateMockLogger();

            var newDto = new ParentDto()
            {
                OneToOneSpecialChildDtoWithFk = new OneToOneSpecialChildDtoWithFk
                {
                    ChildKey = 100,
                    Name = "You, sir, are drunk!"
                }
            };

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(newDto);
                }
            }
            catch (InvalidOperationException)
            {
                // Do nothing because we deliberately didn't open the connection
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(2, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();
            Assert.IsTrue(sql.Contains("INSERT INTO dbo.[Parent]"), "No INSERT on parent.");

            sql = scripts[1].Buffer.ToString();
            Assert.IsTrue(sql.Contains("UPDATE dbo.OneToOneSpecialChildWithFk"), "Should be an UPDATE on child.");
        }

        [Test]
        public void insert_existing_child_with_fk_on_parent_no_reference_data_inserts_parent_and_not_child()
        {
            var logger = CreateMockLogger();

            var newDto = new ContextualReferenceDataParentDto()
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk
                {
                    ChildKey = 100,
                    Name = "You, sir, are drunk!"
                }
            };

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(newDto);
                }
            }
            catch (InvalidOperationException)
            {
                // Do nothing because we deliberately didn't open the connection
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();
            Assert.IsTrue(sql.Contains("INSERT INTO dbo.[ContextualReferenceDataParent]"), "No INSERT on parent.");
            Assert.IsTrue(!sql.Contains("INSERT INTO dbo.OneToOneChildNoFk"), "Should be no INSERT on child.");
        }

        [Test]
        public void insert_existing_reference_data_child_with_fk_on_parent_inserts_parent_and_not_child()
        {
            var logger = CreateMockLogger();

            var newDto = new ParentDto
            {
                OneToOneReferenceChildDtoNoFk = new OneToOneReferenceChildDtoNoFk
                {
                    ChildKey = 100,
                    Name = "You, sir, are drunk!"
                }
            };

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(newDto);
                }
            }
            catch (InvalidOperationException)
            {
                // Do nothing because we deliberately didn't open the connection
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var sql = scripts[0].Buffer.ToString();
            Assert.IsTrue(sql.Contains("INSERT INTO dbo.[Parent]"), "No INSERT on parent.");
            Assert.IsTrue(!sql.Contains("INSERT INTO dbo.OneToOneReferenceChildNoFk"), "Should be no INSERT on child.");
        }

        private MockSimpleSaveLogger CreateMockLogger()
        {
            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;
            return logger;
        }
    }
}
