using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PS.Mothership.Core.Common.Constants;
using PS.Mothership.Core.Common.IPManager;

namespace PS.Mothership.Core.UnitTest.IPManager
{
    [TestFixture]
    public class IPInspectorTest
    {
        [Test]
        public void IsValid_CheckingLocalHost_ReturnTrue()
        {
            // Arrange
            const string ipString = "::5";

            // Act
            var result = IPInspector.IsValid(ipString);

            // Assert
            Assert.AreEqual(true, result, "Should be true, the given ip address in a valid one");            

        }

        [Test]
        public void IsValid_IsIPValid_ReturnTrue()
        {
            // Arrange
            const string ipString = "172.27.152.162";            
            // Act
            var result = IPInspector.IsValid(ipString);

            // Assert
            Assert.AreEqual(true,result, "Should be true, the given ip address in a valid one");
        }

        [Test]
        public void IsValid_IsIPValid_ReturnFalse()
        {
            // Arrange            
            const string ipString = "192.168.090.009.100";

            // Act/Assert            
            Assert.AreEqual(false, IPInspector.IsValid(ipString), "Should be false, the given ip address in a valid one");           
        }

        [Test]
        public void Equal_CompareIp_ReturFalse()
        {
            // Arrange
            const string ipStringA = "172.27.152.162";            
            const string ipStringB = "172.27.152.163";

            // Act/Assert            
            Assert.AreEqual(false, IPInspector.Equal(ipStringA, ipStringB), "Should be false, the given two ip address are not equal");           
        }

        [Test]
        public void Equal_CompareIp_ReturTrue()
        {
            // Arrange
            const string ipStringA = "172.27.152.1";
            const string ipStringB = "172.27.152.1";

            // Act/Assert            
            Assert.AreEqual(true, IPInspector.Equal(ipStringA, ipStringB), "Should be true, the given two ip address are equal");
        }

        [Test]
        public void RemoveLeadingZero_Noramlize_ReturnString()
        {
            // Arrange            
            const string ipString = "192.168.090.009";
            var resultIpString = IPInspector.RemoveLeadingZero(ipString);            

            // Act/Assert            
            Assert.AreEqual(true, IPInspector.IsValid(resultIpString), "Should remove leading zero");           
        }

        [Test]
        public void AppendOctal_Append_ReturnListString()
        {
            // Arrange            
            const string ipString = "172.27.152.1";
            var expected = new List<string>()
            {
                "172.*.*.*","172.27.*.*","172.27.152.*","172.27.152.1"
            };

            // Act
            var result = IPInspector.AppendOctal(ipString);
            //foreach (var s in result)
            //    Console.WriteLine(s);            

            // Assert
            CollectionAssert.AreEqual(expected, result, "Data should be same");            
        }

        [Test]
        public void CustomOctal_Append_ReturnListString()
        {
            // Arrange            
            const string ipString = "172.27.152.1";
            var expected = new List<string>()
            {
                "*",
                "*.*.*.*",
                "172.*",
                "172.27.*"
            };

            // Act
            var result = IPInspector.CustomOctal(ipString);                        
            //foreach (var s in result)            
            //    Console.WriteLine(s);            

            CollectionAssert.AreEqual(expected, result, "Data should be same");            
        }

        [Test]
        public void WildCardCompare_Compare_ReturnTrue()
        {
            // Arrange            
            const string ipString = "172.27.152.1";                        
            var ipStringList = new List<string>()
            {                
                "172.27.*"
            };

            // Act
            var result = IPInspector.WildCardCompare(ipString, ipStringList, GlobalConstants.Star);

            // Assert
            Assert.AreEqual(true, result, "Data should be true");
        }

        [Test]
        public void WildCardCompare_Compare_ReturnFalse()
        {
            // Arrange            
            const string ipString = "172.26.152.1";
            var ipStringList = new List<string>()
            {                
                "172.27.*"
            };

            // Act
            var result = IPInspector.WildCardCompare(ipString, ipStringList, GlobalConstants.Star);

            // Assert
            Assert.AreEqual(false, result, "Data should be false");
        }

        [Test]
        public void WildCardCompare_CompareLocal_ReturnTrue()
        {
            // Arrange            
            const string ipString = "::1";
            var ipStringList = new List<string>()
            {                
                "172.27.*",
                "::1"
            };

            // Act
            var result = IPInspector.WildCardCompare(ipString, ipStringList, GlobalConstants.Star);

            // Assert
            Assert.AreEqual(true, result, "Data should be true");
        }


        [Test]
        [Ignore("Just to write to console")]
        public void WriteTo()
        {                        
            Console.WriteLine(IPInspector.RemoveLeadingZero("192.168.090.009"));
            Console.WriteLine(IPInspector.RemoveLeadingZero("172.27.152.1"));
            Console.WriteLine(IPInspector.RemoveLeadingZero("127.0.0.1"));            
        }
    }
}
