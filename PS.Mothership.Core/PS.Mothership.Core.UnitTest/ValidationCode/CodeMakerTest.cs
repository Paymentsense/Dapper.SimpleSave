using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PS.Mothership.Core.Common.ValidationCode;

namespace PS.Mothership.Core.UnitTest.ValidationCode
{
    [TestFixture]
    public class CodeMakerTest
    {
        [Test]
        public void GenerateCode_UniqueNumber_ReturnsNumber_UsingRandom()
        {
            // Arrange           
            // Act
            var result = CodeMaker.GenerateCode();

            // console it
            //Console.WriteLine(result);

            // Assert
            Assert.Greater(result,0, "The returned number should be greater than zero");
        }

        [Test]
        public void GenerateCode_UniqueNumber_PassingZero_UsingRandom()
        {
            // Arrange           
            // Act
            var result = CodeMaker.GenerateCode(-1,-1);

            // console it
            //Console.WriteLine(result);

            // Assert
            Assert.Greater(result, 0, "The returned number should be greater than zero");
        }

        [Test]
        public void GenerateCode_UniqueNumber_ReturnsNumber_UsingCryptoRandom()
        {
            // Arrange           
            // Act
            var result = CodeMaker.GenerateCodeUsingCrypto();

            // console it
            //Console.WriteLine(result);

            // Assert
            Assert.Greater(result, 0, "The returned number should be greater than zero");
        }

        [Test]
        public void GenerateCode_UniqueNumber_PassingZero_UsingCryptoRandom()
        {
            // Arrange           
            // Act
            var result = CodeMaker.GenerateCodeUsingCrypto(-1,-1);

            // console it
            //Console.WriteLine(result);

            // Assert
            Assert.Greater(result, 0, "The returned number should be greater than zero");
        }  
    }
}
