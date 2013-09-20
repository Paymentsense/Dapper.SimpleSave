using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.UnitTest.Helper
{
    [TestFixture]
    public class UtilTest
    {
        [Test]
        public void ConvertToJson_AnObjectGiven_GiveBackAJasonString()
        {
            // Arrange 
            var p = new Person { Id = 1, Name = "Name" };
            const string actual = @"""Id"":1";

            // Act
            string jsonString = Util.ConvertToJson(p,true);


            //Console.WriteLine(jsonString);
            //Console.WriteLine(actual);

            // Assert
            Assert.AreEqual(true, jsonString.Contains(actual));
        }

        [Test]
        public void ConvertToObject_StronglyTped_GiveBackAStronglyTypeOBject()
        {
            // Arrange 
            var p = new Person { Id = 1, Name = "Name", FirstName = "FirstName" };
            var c = new Customer { Id = 100, Name = "Customer Name" };
            p.Customer = c;

            // convert to json
            var jsonString = Util.ConvertToJson(p);

            // Act
            var ps = Util.ConvertToObject(jsonString, new Person());

            //Console.WriteLine(string.Format("Id:{0}\n Name:{1}\n CustomerId:{2}\n CustomerName:{3}",
            //  ps.Id, ps.Name, ps.Customer.Id, ps.Customer.Name));

            // Asssert
            Assert.AreEqual(ps.Id, p.Id, "Id not the same");
        }
    }


    /// <summary>
    /// Test Stubs
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public Customer Customer { get; set; }
    }

    /// <summary>
    /// Test Stubs
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
