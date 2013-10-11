using Newtonsoft.Json;
using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;
using PS.Mothership.Core.Common.Template.PsMsContext;
using System;
using System.Runtime.Serialization;


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

        [Test]
        public void ConvertToBson_AnObjectGiven_GiveBackABson()
        {
            // Arrange 
            var p = new Person { Id = 1, Name = "Name", FirstName = "FirstName" };
            var c = new Customer { Id = 100, Name = "Customer Name" };
            p.Customer = c;

            // coverted byte for equality testing
            const string expected = "ZAAAABBJZAABAAAAAk5hbWUABQAAAE5hbWUAAkZpcnN0TmFtZQAKAAAARmlyc3ROYW1lAANDdXN0b21lcgAlAAAAEElkAGQAAAACTmFtZQAOAAAAQ3VzdG9tZXIgTmFtZQAAAA==";

            // Act            
            var bsonBytes = Util.ConvertToBson(p);
            var actual = Convert.ToBase64String(bsonBytes);

            //// Act
            //var ps = Util.ConvertFromBson<Person>(bsonBytes);

            //Console.WriteLine(string.Format("Id:{0}\n Name:{1}\n CustomerId:{2}\n CustomerName:{3}",
            //  ps.Id, ps.Name, ps.Customer.Id, ps.Customer.Name));            
          
            // Asssert
            Assert.AreEqual(expected, actual, "data not the same");
        }

        [Test]
        public void ConvertFromBson_ByteArray_GiveBackAStronglyTypeOBject()
        {
            // Arrange 
            // coverted byte for equality testing
            const string base64PersonData = "ZAAAABBJZAABAAAAAk5hbWUABQAAAE5hbWUAAkZpcnN0TmFtZQAKAAAARmlyc3ROYW1lAANDdXN0b21lcgAlAAAAEElkAGQAAAACTmFtZQAOAAAAQ3VzdG9tZXIgTmFtZQAAAA==";

            var p = new Person { Id = 1, Name = "Name", FirstName = "FirstName" };
            var c = new Customer { Id = 100, Name = "Customer Name" };
            p.Customer = c;            

            // Act
            var ps = Util.ConvertFromBson<Person>(Convert.FromBase64String(base64PersonData));

            //Console.WriteLine(string.Format("Id:{0}\n Name:{1}\n CustomerId:{2}\n CustomerName:{3}",
            //  ps.Id, ps.Name, ps.Customer.Id, ps.Customer.Name));

            // Asssert
            Assert.AreEqual(ps.Id, p.Id, "Id not the same");
        }

        [Test]
        public void ConvertToJson_AnObjectGiven_JasonString_IgnoringAproperty()
        {
            // Arrange 
            var p = new Person { Id = 1, Name = "Name" };
            var c = new Customer { Id = 100, Name = "Customer Name" };
            p.Customer = c;
            const string actual = @"""SessionId"":";

            // convert to json
            var jsonString = Util.ConvertToJson(p);

            //Console.WriteLine(jsonString);

            // Assert
            Assert.AreEqual(false, jsonString.Contains(actual),  "should not contain property decorated with JsonIgnore");
        }

        [Test]
        public void GetDescription_Enumeration_ReturnDescription()
        {
            // Arrange
            const MyEnum enumDec = MyEnum.Dog;
            const string expected = "I'm a dog";

            // Act
            var desc = enumDec.GetDescription();

            // Assert
            Assert.AreEqual(expected, desc, "Message should be same");
        }


        [Test]
        public void GetDescription_Enumeration_ReturnEmpty()
        {            
            // Arrange
            const MyEnum enumDec = MyEnum.Lion;
            const string expected = "";

            // Act
            var desc = enumDec.GetDescription();

            // Assert
            Assert.AreEqual(expected, desc, "An empty string should come back");
        }

        [Test]
        public void GetDescription_Enum_Without_Description_ReturnEmpty()
        {
            // Arrange
            const MyEnum enumDec = MyEnum.Tiger;
            const string expected = "";

            // Act
            var desc = enumDec.GetDescription();

            // Assert
            Assert.AreEqual(expected, desc, "An empty string should come back");

        }
    }


    /// <summary>
    /// Test Stubs
    /// </summary>
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
        private Guid _sessionId = Guid.NewGuid();
        [JsonIgnore]
        [DataMember]
        public Guid SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }
    }

    /// <summary>
    /// Test Stubs
    /// </summary>
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    enum MyEnum
    {
        [System.ComponentModel.Description("I'm a dog")][EnumMember]Dog, 
        [System.ComponentModel.Description("I'm a cat")][EnumMember]Cat, 
        [System.ComponentModel.Description("")][EnumMember]Lion, 
        [EnumMember]Tiger, 
    }
}
