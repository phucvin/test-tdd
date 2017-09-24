using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestItemSlotPure
    {
        private MyItemSlotPure _slot;

        [SetUp]
        public void SetUp()
        {
            _slot = new MyItemSlotPure();
        }

        [Test]
        public void ShowAndImagePathIsCorrect()
        {
            _slot.Show("ea001");

            Assert.AreEqual("icon/ea001.png", _slot.CurrentImagePath);
        }

        [Test]
        public void ClickDoAction1()
        {
            _slot.Show("a");
            _slot.onClick();

            Assert.AreEqual(1, _slot._action1Calls);
        }

        [Test]
        public void ClickEmptyDoNotCallAction1()
        {
            _slot.onClick();

            Assert.AreEqual(0, _slot._action1Calls);
        }

        [Test]
        public void ShowDifferentAndRedrawIsCalled([Values(1, 3)] int shows)
        {
            for (int i = 0; i < shows; ++i)
            {
                _slot.Show(string.Format("ea00{0}", i + 1));
            }

            Assert.AreEqual(shows, _slot._redrawCalls);
        }

        [Test]
        public void ShowNullAndRedrawIsCalled()
        {
            _slot.Show("ea001");
            _slot.Show(null);

            Assert.AreEqual(2, _slot._redrawCalls);
        }

        [Test]
        public void ShowSameAndRedrawIsCalledOnce([Values(2, 5)] int shows)
        {
            for (int i = 0; i < shows; ++i)
            {
                _slot.Show("ea001");
            }

            Assert.AreEqual(1, _slot._redrawCalls);
        }

        [Test]
        public void ShowNullAtFirstAndRedrawIsNotCalled()
        {
            _slot.Show(null);

            Assert.AreEqual(0, _slot._redrawCalls);
        }

        [Test]
        public void AfterShowGetCurrentItemIdCorrectly()
        {
            _slot.Show("ea001");

            Assert.AreEqual("ea001", _slot.CurrentItemId);
        }

        [Test]
        public void DoubleClickAndAction2IsCalled()
        {
            _slot.Show("ea001");
            _slot.onDoubleClick();

            Assert.AreEqual(1, _slot._action2Calls);
        }

        [Test]
        public void DoubleClickEmptySlotAndAction2IsNotCalled()
        {
            _slot.onDoubleClick();

            Assert.AreEqual(0, _slot._action2Calls);
        }

        private class MyItemSlotPure : ItemSlotPure
        {
            internal int _action1Calls = 0;
            internal int _action2Calls = 0;
            internal int _redrawCalls = 0;

            protected override void action1()
            {
                ++_action1Calls;
            }

            protected override void action2()
            {
                ++_action2Calls;
            }

            protected override void redraw()
            {
                ++_redrawCalls;
            }
        }
    }
}