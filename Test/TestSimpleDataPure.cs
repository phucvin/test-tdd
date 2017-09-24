using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestSimpleDataPure
    {
        private SimpleDataPure _data;

        [SetUp]
        public void SetUp()
        {
            _data = new SimpleDataPure();
        }

        [Test]
        public void NothingToTest()
        {
            Assert.Pass();
        }
    }
}