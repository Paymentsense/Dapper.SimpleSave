using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using PS.Mothership.Core.Common.Constants;
using PS.Mothership.Core.Common.Helper;
using PS.Mothership.Core.Common.IPManager;

namespace PS.Mothership.Core.UnitTest.IPManager
{
    [TestFixture]
    [Ignore("This to test performance, dont run in CI [contineous integration] mode")]
    public class IPInspectorPerformanceTest
    {

        [Test]
        public void RemoveLeadingZero_On_Regex()
        {
            // Arrange  
            var ipString = new List<string>()
            {
                "192.168.090.009",
                "172.168.090.001",
                "062.008.090.002",
                "072.008.090.003",
                "172.009.001.004",
                "127.0.0.1"
            };

            foreach (var ip in ipString)
            {
                Debug.WriteLine("Ip Address : " + ip);
                IPInspector.RemoveLeadingZero(ip, true);
                Debug.WriteLine("................ ");
            }                        
        }

        [Test]
        public void RemoveLeadingZero_On_Cusom()
        {
            
            var ipString = new List<string>()
            {
                "192.168.090.009",
                "172.168.090.001",
                "062.008.090.002",
                "072.008.090.003",
                "172.009.001.004",
                "127.0.0.1"
            };

            foreach (var ip in ipString)
            {
                Debug.WriteLine("Ip Address : " + ip);
                IPInspector.RemoveLeadingZero(ip);
                Debug.WriteLine("................ ");
            }
        }

        [Test]
        public void WildCardCompare_Compare()
        {
            // Arrange  
            var ipString = new List<string>()
            {
                "80.87.25.2",
                "127.0.0.1",
                "::1",
                "220.227.102.249",
                "74.92.38.137",
                "89.167.239.131",
                "192.168.43.12",
                "192.168.80.14",                
            };

            foreach (var ip in ipString)
            {                
                var result = IPInspector.WildCardCompare(ip, IPInspectorTest.IPData());
                Debug.WriteLine("Ip Address : " + ip + " Found : " + result);
                Debug.WriteLine("................ ");
            }            
        }

        [Test]
        public void Find_Compare_IsMatch()
        {
            // Arrange  
            var ipString = new List<string>()
            {
                "80.87.25.2",
                "127.0.0.1",
                "::1",
                "220.227.102.249",
                "74.92.38.137",
                "89.167.239.131",
                "192.168.43.12",
                "192.168.80.14",
            };           

            foreach (var ip in ipString)
            {                
                bool isMatch;
                IPInspector.Find(ip, IPInspectorTest.IPData(),out isMatch);
                Debug.WriteLine("Ip Address : " + ip + " Found : " + isMatch);                
                Debug.WriteLine("................ ");
            }
        }


        [Test]
        public void PadIpString_ShuoldPadValue_ReturnPaddedString()
        {
            var ipString = IPInspectorTest.IPData();

            Stopwatch stopwatch = null;
            DebugStopwatch.Start(ref stopwatch);

            foreach (var ip in ipString)            
            {
                var result = IPInspector.PadIpString(ip);                
            }

            DebugStopwatch.Stop(ref stopwatch);
            DebugStopwatch.DurationInMilliseconds("Total PadIpString: ", ref stopwatch);
            
        }

        [Test]        
        public void WriteTo()
        {
            Debug.WriteLine(IPInspector.RemoveLeadingZero("192.168.090.009"));
            Debug.WriteLine(IPInspector.RemoveLeadingZero("172.27.152.1"));
            Debug.WriteLine(IPInspector.RemoveLeadingZero("127.0.0.1"));
            Debug.WriteLine(IPInspector.RemoveLeadingZero("127.0.0.1",true));
        }
    }
}
