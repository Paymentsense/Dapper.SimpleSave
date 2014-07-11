using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.UnitTest.Helper
{
    /// <summary>
    /// Test for CTime
    /// </summary>
    [TestFixture]
    public class CTimeTest
    {
        [Test]
        public void Start_IsRunning_ReturnBool()
        {

            // Arrange
            var stopwatch = new CTime();            

            // Act
            stopwatch.Start();
            var result = stopwatch.IsRunning;            
            stopwatch.Stop();

            // Assert
            Assert.AreEqual(true, result);
            

        }


        [Test]
        public void Start_IsStopped_ReturnBool()
        {

            // Arrange
            var stopwatch = new CTime();

            // Act
            stopwatch.Start();
            stopwatch.Stop();

            // Assert
            Assert.AreEqual(false, stopwatch.IsRunning);
        }
    }
}
