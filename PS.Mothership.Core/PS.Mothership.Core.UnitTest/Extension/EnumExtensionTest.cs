using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;
using System.Runtime.Serialization;

namespace PS.Mothership.Core.UnitTest.Extension
{
    [TestFixture]
    public class EnumExtensionTest
    {
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

    [DataContract]
    enum MyEnum
    {
        [System.ComponentModel.Description("I'm a dog")]
        [EnumMember]
        Dog,
        [System.ComponentModel.Description("I'm a cat")]
        [EnumMember]
        Cat,
        [System.ComponentModel.Description("")]
        [EnumMember]
        Lion,
        [EnumMember]
        Tiger,
    }
}
