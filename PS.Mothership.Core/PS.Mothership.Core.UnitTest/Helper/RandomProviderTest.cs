using NUnit.Framework;
using PS.Mothership.Core.Common.Helper;

namespace PS.Mothership.Core.UnitTest.Helper
{
    [TestFixture]
    public class RandomProviderTest
    {
        [Test]
        public void GetThreadRandom_ObjectPerThread_ReturnRandomInstance()
        {
            // Arrange / Act
            var r = RandomProvider.GetThreadRandom();

            // Assert
            Assert.NotNull(r,"The random objec should not be null");
        }


        [Test]
        public void GetThreadCryptoRandom_ObjectPerThread_ReturnCryptoRandomInstance()
        {
            // Arrange / Act
            var r = RandomProvider.GetThreadCryptoRandom();

            // Assert
            Assert.NotNull(r, "The random objec should not be null");
        }
    }
}
