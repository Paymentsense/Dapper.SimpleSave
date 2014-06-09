using System;
using System.Collections.Generic;
using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.UnitTest.Helper
{
    [TestFixture]
    public class ObfuscatorTest
    {

        [Test]
        public void Email_Obfuscate_NotNull()
        {
            // Arrange
            const string email = "raj.manikand@paymentsense.com";

            // Act
            var result = Obfuscator.Email(email);

            // Assert            
            Assert.NotNull(result);
        }

        [Test]
        public void Email_Obfuscate_ReturnString()
        {
            // Arrange
            //const string email = "raj.manikand@paymentsense.com";
            const string email = "d@paymentsense.com";

            // Act
            var result = Obfuscator.Email(email);

            // Assert            
            Console.WriteLine(result);

            Assert.AreEqual(email.Length,result.Length,"Both result and actual email length should be same");
        }

        [TestCase("raj.manikand@paymentsense.com")]
        [TestCase("sam.bullock@paymentsense.com")]
        [TestCase("r@gmail.com")]
        [TestCase("dd@gmail.com")]
        [TestCase("ssss.ddd@hotmail.com")]
        [TestCase("sai.krish@paymentsense.com")]
        [TestCase("dummy@paymentsense.com")]
        public void Email_ObfuscateList_ReturnEmail(string email)
        {
            // Act & Assert
            var result = Obfuscator.Email(email);
            Console.WriteLine(result);
            Assert.AreEqual(email.Length, result.Length, "Both result and actual email length should be same");                        
        }

        [Test]
        public void Email_NoAtSignPresent_ReturnNull()
        {
            // Arrange
            const string email = "raj.manikand~paymentsense.com";

            // Act
            var result = Obfuscator.Email(email);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Phone_Obfuscate_NotNull()
        {
            // Arrange
            const string phone = "0712345678";

            // Act
            var result = Obfuscator.Phone(phone);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void Phone_Obfuscate_ReturnString()
        {
            // Arrange
            const string phone = "0712345678";
            const string expected = "******5678";

            // Act
            var result = Obfuscator.Phone(phone);

            // Assert
            Console.WriteLine(result);
            Assert.AreEqual(expected,result,"The number should have 6 '*' and with four suffix last digist shown");
        }

        [Test]
        public void Phone_DigitsToShow_ReturnString()
        {
            // Arrange
            const string phone = "0712345678";
            const string expected = "******5678";

            // Act
            var result = Obfuscator.Phone(phone,-1);

            // Assert            
            Assert.AreEqual(expected, result, "The number should have 6 '*' and with four suffix last digist shown");

        }


        
    }
}
