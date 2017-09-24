using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestWeirdButtonPure
    {
        private MyWeirdButtonPure _btn;

        [SetUp]
        public void SetUp()
        {
            _btn = new MyWeirdButtonPure();
        }

        [Test]
        public void DisableAtFirst()
        {
            Assert.False(_btn._enable);
        }

        [Test]
        public void EnableAfterTick10Seconds()
        {
            _btn.tick(10);

            Assert.True(_btn._enable);
        }

        [Test]
        public void StillDisabledAfterTick2Seconds()
        {
            _btn.tick(2);

            Assert.False(_btn._enable);
        }

        [Test]
        public void BeEnabledOnce()
        {
            _btn.tick(10);
            _btn.tick(1);

            Assert.AreEqual(1, _btn._enableCalls);
        }

        [Test]
        public void BeEnabledOnceEvenLastTickWithZero()
        {
            _btn.tick(10);
            _btn.tick(0);

            Assert.AreEqual(1, _btn._enableCalls);
        }

        [Test]
        public void CanStillBeDisableAfterTick5()
        {
            _btn.tick(5);

            Assert.True(_btn.canStillBeDisabled());
        }

        private class MyWeirdButtonPure : WeirdButtonPure
        {
            internal bool _enable = true;
            internal int _enableCalls = 0;

            protected override void setEnable(bool enable)
            {
                if (enable)
                {
                    ++_enableCalls;
                }
                _enable = enable;
            }
        }
    }
}
