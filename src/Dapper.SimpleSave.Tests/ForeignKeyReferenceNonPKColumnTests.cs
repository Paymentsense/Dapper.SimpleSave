using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Tests.RealisticDtos;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{
    [TestFixture]
    public class ForeignKeyReferenceNonPKColumnTests : BaseScriptGenerationTests
    {
        [Test]
        public void insert_contact_referencing_phone_numbers_sets_guid_values_not_ints_on_fk_columns()
        {
            var logger = new MockSimpleSaveLogger();
            SimpleSaveExtensions.Logger = logger;

            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.Create(SamplePopulatedDtos.Contact);
                }
            }
            catch (InvalidOperationException)
            {
                //  Not a real DB connection.
            }

            var scripts = logger.Scripts;
            Assert.AreEqual(1, scripts.Count, "Unexpected number of scripts.");

            var script = scripts[0];

            var guid = ExtractGuid(script, "p7");
            Assert.AreEqual(
                SamplePopulatedDtos.Contact.MainPhone.PhoneGuid,
                guid,
                string.Format("Invalid main phone GUID: {0}", guid));

            guid = ExtractGuid(script, "p8");
            Assert.AreEqual(
                SamplePopulatedDtos.Contact.MobilePhone.PhoneGuid,
                guid,
                string.Format("Invalid main phone GUID: {0}", guid));
        }

        private Guid ExtractGuid(IScript script, string paramName)
        {
            var value = script.Parameters[paramName];
            if (value is Func<object>)
            {
                value = ((Func<object>) value)();
            }

            if (value is Guid?)
            {
                return ((Guid?) value).GetValueOrDefault();
            }
            else if (value is Guid)
            {
                return (Guid) value;
            }
            
            Assert.Fail(string.Format(
                "Invalid parameter type - should be a Guid or Guid? but is: {0}",
                value == null ? "(null)" : value.GetType().ToString()));

            return Guid.Empty;
        }
    }
}
