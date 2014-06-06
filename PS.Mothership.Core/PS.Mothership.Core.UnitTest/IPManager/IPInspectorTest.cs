using System;
using System.Collections.Generic;
using System.Net;
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
        public void IsValid_IsIPV6Valid_ReturnTrue()
        {
            // Arrange
            const string ipString = "fe80::9915:c83c:70dd:7a0d%11";            

            // Act
            IPAddress ipAddress;
            var result = IPInspector.IsValid(ipString, out ipAddress);

            if (result)
            {
                Console.WriteLine("is ipv6 ? " + ipAddress.IsIPv6LinkLocal);
                Console.WriteLine("map ipv6 to ipv4 " + ipAddress.MapToIPv4());
            }

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
        public void RemoveLeadingZero_UsingRegex_ReturnString()
        {
            // Arrange            
            const string ipString = "192.168.090.009";
            var resultIpString = IPInspector.RemoveLeadingZero(ipString,true);

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
            //var ipStringList = new List<string>()
            //{                
            //    "172.27.*"
            //};

            // Act
            var result = IPInspector.WildCardCompare(ipString, IPData());
            

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
        public void WildCardCompare_CompareEmpty_ReturnFalse()
        {
            // Arrange            
            const string ipString = "";
            var ipStringList = new List<string>()
            {                
                "172.27.*"
            };

            // Act
            var result = IPInspector.WildCardCompare(ipString, ipStringList, GlobalConstants.Star);

            // Assert
            Assert.AreEqual(false, result, "Data should be false, as input is empty");
        }

        [Test]
        public void WildCardCompare_CompareNull_ReturnFalse()
        {
            // Arrange            
            const string ipString = null;
            var ipStringList = new List<string>()
            {                
                "172.27.*"
            };

            // Act
            var result = IPInspector.WildCardCompare(ipString, ipStringList);

            // Assert
            Assert.AreEqual(false, result, "Data should be false, as input is empty");
        }

        [Test]
        public void PadIpString_ShuoldPadValue_ReturnPaddedString()
        {
            // Arrange
            const string ipString = "72.26.152.1";
            const string expectedIpString = "*72.*26.152.**1";

            // Act
            var result = IPInspector.PadIpString(ipString);

            // Assert
            Assert.AreEqual(expectedIpString,result,"The ip value should be same");
        }

        [Test]
        public void Find_CompareInputAndSourceIp_ReturnsIsMatch()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "172.27.152.162";
            bool isMatch;            

            // Act
            IPInspector.Find(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");         
        }

        [Test]
        public void Find_CompareInputAndSourceIp_ReturnsNoMatch()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "190.71.154.162";
            bool isMatch;
         
            // Act
            IPInspector.Find(ipString, ipStringList, out isMatch);
          

            // Assert
            Assert.AreEqual(false, isMatch, "The ip address should not be a match");
        }


        [Test]
        public void Find_CompareInputAndSourceIp_ReturnsDictionary()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "172.27.152.162";
            bool isMatch;

            // Act
            var result = IPInspector.Find(ipString, ipStringList, out isMatch, false);

            // Assert
            Assert.Greater(result.Count, 0, "The ip address match dictionary should be more than zero");

            foreach (var i in result)
            {
                Console.WriteLine("Ip:{0} Score:{1}", i.Key, i.Value);
            }

        }

        [Test]
        public void Find_CheckingLocalHost_ReturnTrue()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "::1";
            bool isMatch;                    

            // Act
            IPInspector.Find(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");   

        }

        [Test]
        public void Find_127_0_0_1_ReturnTrue()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "127.0.0.1";
            bool isMatch;

            // Act
            IPInspector.Find(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");

        }

        [Test]
        public void FindFaster_CompareInputAndSourceIp_ReturnsIsMatch()
        {
            // Arrange
            //var ipStringList = IPData();
            const string ipString = "172.27.152.162";
            bool isMatch;

            // Arrange  
            var ipStringList = new List<string>()
            {
                 "*.27.152.162"             
            };


            // Act
            IPInspector.FindFaster(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");
        }

        [Test]
        public void FindFaster_CompareInputAndSourceIp_ReturnsNoMatch()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "190.71.154.162";
            bool isMatch;

            // Act
            IPInspector.FindFaster(ipString, ipStringList, out isMatch);


            // Assert
            Assert.AreEqual(false, isMatch, "The ip address should not be a match");
        }

        [Test]
        public void FindFaster_CompareInputAndSourceIp_ReturnsDictionary()
        {
            // Arrange
            var ipStringList = IPData();
            
            const string ipString = "172.27.152.162";
            bool isMatch;

            // Act
            var result = IPInspector.FindFaster(ipString, ipStringList, out isMatch, false);

            // Assert
            Assert.Greater(result.Count, 0, "The ip address match dictionary should be more than zero");

            foreach (var i in result)
            {
                Console.WriteLine("Ip:{0} Score:{1}", i.Key, i.Value);
            }

        }

        [Test]
        public void FindFaster_CheckingLocalHost_ReturnTrue()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "::1";
            bool isMatch;

            // Act
            IPInspector.FindFaster(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");

        }

        [Test]
        public void FindFaster_127_0_0_1_ReturnTrue()
        {
            // Arrange
            var ipStringList = IPData();
            const string ipString = "127.0.0.1";
            bool isMatch;

            // Act
            IPInspector.FindFaster(ipString, ipStringList, out isMatch);

            // Assert
            Assert.AreEqual(true, isMatch, "The ip address should be a match");

        }

        #region Data

        public static List<string> IPData()
        {
            var ipStringList = new List<string>
            {
                //"*", not going to be used
                //"*.*.*.*", not going to be used
                "172.*",
                "172.27.*",
                "172.*.*.*",
                "172.*.27.*",
                "172.27.*.*",
                "172.*.152.*",
                "172.27.153.*",
                "172.27.152.162",
                "*.27.152.162",
                "61.95.130.*",
                "61.95.131.*",
                "80.87.25.2",
                "220.227.102.249",
                "74.92.38.137",
                "89.167.239.131",
                "192.168.43.*",
                "192.168.42.*",
                "89.167.239.142",
                "59.163.114.193",
                "127.0.0.1",
                "98.217.137.97",
                "122.169.194.10",
                "76.119.163.*",
                "120.63.178.75",
                "90.208.40.169",
                "115.113.202.14",
                "217.171.129.71",
                "217.171.129.73",
                "212.183.140.39",
                "90.218.72.44",
                "115.113.30.214",
                "66.220.27.181 ",
                "64.38.2.254 ",
                "209.235.246.137 ",
                "78.136.46.136 ",
                "66.160.205.77 ",
                "64.62.157.219 ",
                "64.62.157.218 ",
                "209.235.254.2 ",
                "209.235.253.17 ",
                "74.200.197.154 ",
                "208.78.245.195 ",
                "208.78.245.194 ",
                "83.138.130.159 ",
                "64.38.45.6 ",
                "120.136.44.53 ",
                "208.166.55.50",
                "86.188.146.114",
                "59.144.73.99",
                "61.68.165.*",
                "59.101.163.*",
                "59.101.166.*",
                "59.101.197.*",
                "61.95.130.98",
                "59.163.114.*",
                "202.89.104.*",
                "59.114.73.*",
                "61.95.130.*",
                "61.95.131.*",
                "192.168.45.*",
                "192.168.46.*",
                "127.0.0.1",
                "202.89.105.45",
                "::1",
            };

            return ipStringList;
        }

        #endregion
    }
}
