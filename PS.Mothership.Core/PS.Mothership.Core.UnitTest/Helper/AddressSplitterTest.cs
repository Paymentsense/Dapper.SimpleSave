using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.UnitTest.Helper
{
    [TestFixture]
    public class AddressSplitterTest
    {

        [Test]
        public void SplitHouseNumber_EmptyFullAddress_ReturnEmpty()
        {
            // Arrange
            string fullAddress = null;

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumber(fullAddress);

            // Assert
            Assert.IsEmpty(result, "Result should be empty");
        }

        [Test]
        public void SplitHouseNumber_FullAddress_ReturnHouseNumber()
        {
            // Arrange
            const string fullAddress = "120-90 cross street";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumber(fullAddress);
            
            // Assert
            Assert.AreEqual(result, "120-90", "Should be a match");
        }

        [Test]
        public void SplitHouseNumber_FullAddress_ReturnEmtpy()
        {
            // Arrange
            const string fullAddress = "cross street 120-90";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumber(fullAddress);
            

            // Assert
            Assert.IsEmpty(result, "Result should not be empty");
        }

        [Test]
        public void SplitHouseNumber_FirstCharacter_Not_A_Number_ReturnEmtpy()
        {
            // Arrange
            const string fullAddress = "-cross street 120-90";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumber(fullAddress);            

            // Assert
            Assert.IsEmpty(result, "Result should be empty");
        }


        [Test]
        public void SplitHouseNumberAndAddress_FullAddress_ReturnEmtpy()
        {
            // Arrange
            const string fullAddress = "cross street 120-90";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumberAndAddress(fullAddress);

            // Assert
            Assert.IsEmpty(result.Item1, "Result should not be empty");
        }


        [Test]
        public void SplitHouseNumberAndAddress_FirstCharacter_Not_A_Number_ReturnEmtpy()
        {
            // Arrange
            const string fullAddress = "-cross street 120-90";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumberAndAddress(fullAddress);

            // Assert
            Assert.IsEmpty(result.Item1, "Result should be empty");
        }

        [Test]
        public void SplitHouseNumberAndAddress_FullAddress_ReturnHouseNumberAddress()
        {
            // Arrange
            const string fullAddress = "120-90 cross street";

            // Arrange/Act
            var result = AddressSplitter.SplitHouseNumberAndAddress(fullAddress);

            // Assert
            Assert.AreEqual("120-90",result.Item1, "Should be a match");
            Assert.AreEqual("cross street",result.Item2, "should be a match");
        }
    }
}
