using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestSimpleStorePure
    {
        private SimpleStorePure _store;

        [SetUp]
        public void SetUp()
        {
            _store = new SimpleStorePure();
        }

        [Test]
        public void EnergyNeverNegative()
        {
            _store.Energy -= 10;

            Assert.True(_store.Energy >= 0);
        }
    }
}