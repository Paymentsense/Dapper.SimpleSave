using System;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests.Metadata
{
    [TestFixture]
    public class MultiplePropertiesSameColumnTests : BaseTests
    {
        [Table("[myschema].[TableA]")]
        public class TableA
        {
            [PrimaryKey]
            public int? TableAId { get; set;}

            public string Name { get; set; }
        }

        public class TableB : TableA
        {
#pragma warning disable 108
            public string Name { get; set; }
#pragma warning restore 108
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), MatchType = MessageMatch.Contains, UserMessage = "both contain properties mapped to column")]
        public void throws_on_insert_with_duplicate_property_mappings_by_default()
        {
            var newObject = new TableB() { Name = "Captain Jack Sparrow" };
            using (IDbConnection connection = new SqlConnection())
            {
                connection.Create(newObject);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), MatchType = MessageMatch.Contains, UserMessage = "both contain properties mapped to column")]
        public void throws_on_update_with_duplicate_property_mappings_by_default()
        {
            var oldObject = new TableB() { Name = "Captain Barbosa" };
            var newObject = new TableB() { Name = "Captain Jack Sparrow" };
            using (IDbConnection connection = new SqlConnection())
            {
                connection.Update(oldObject, newObject);
            }
        }

        [Test]
        public void does_not_throw_with_duplicate_property_mappings_when_warning_disabled_does_not_emit_script_with_duplicate_insert_columns()
        {
            var newObject = new TableB() { Name = "Captain Jack Sparrow" };
            RunInsertOrUpdateWithDuplicatePropertyMappings(null, newObject);
        }

        [Test]
        public void does_not_throw_with_duplicate_property_mappings_when_warning_disabled_does_not_emit_script_with_duplicate_update_columns()
        {
            var oldObject = new TableB() { Name = "Captain Barbosa" };
            var newObject = new TableB() { Name = "Captain Jack Sparrow" };
            RunInsertOrUpdateWithDuplicatePropertyMappings(oldObject, newObject);
        }

        private void RunInsertOrUpdateWithDuplicatePropertyMappings(TableB oldObject, TableB newObject)
        {
            try
            {
                SimpleSaveExtensions.ThrowOnMultipleWriteablePropertiesAgainstSameColumn = false;
                var logger = CreateMockLogger();

                try
                {
                    using (IDbConnection connection = new SqlConnection())
                    {
                        connection.Update(oldObject, newObject);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    if (ioe.Message.Contains("both contain properties mapped to column"))
                    {
                        throw;
                    }
                }

                var scripts = logger.Scripts;
                Assert.AreEqual(1, scripts.Count);

                var script = scripts[0];
                var sql = script.Buffer.ToString();
                Assert.AreEqual(sql.IndexOf("Name"), sql.LastIndexOf("Name"), "Column appears more than once.");
            }
            finally
            {
                SimpleSaveExtensions.ThrowOnMultipleWriteablePropertiesAgainstSameColumn = true;
            }
        }
    }
}
