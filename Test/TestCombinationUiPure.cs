using NUnit.Framework;
using System.Collections.Generic;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestCombinationUiPure
    {
        private SimpleStorePure _store;
        private MyCombinationUiPure _ui;

        [SetUp]
        public void SetUp()
        {
            _store = new SimpleStorePure();
            _store.AddItemToInventory("ea001");
            _store.AddItemToInventory("ea002");

            var combination = new Combination(_store,
                requirements: new List<string> { "ea001", "ea002" },
                result: "ea009");
            _ui = new MyCombinationUiPure(combination);
        }

        [Test]
        public void CombineButtonIsEnabledIfCanCombine()
        {
            Assert.True(_ui._buttonCombineEnable);
        }

        [Test]
        public void CombineButtonIsDisableIfCanNotCombine()
        {
            _store.RemoveItemFromInventory("ea002");
            _ui.Refresh();

            Assert.False(_ui._buttonCombineEnable);
        }

        [Test]
        public void RequirementShowCorrectly()
        {
            Assert.AreEqual("ea001", _ui._requirementsTable._slots[0].CurrentItemId);
        }

        [Test]
        public void ResultShowCorrectly()
        {
            Assert.AreEqual("ea009", _ui._resultSlot.CurrentItemId);
        }

        [Test]
        public void CombineThenCombineButtonIsDisabled()
        {
            _ui.onCombineClick();

            Assert.False(_ui._buttonCombineEnable);
        }

        [Test]
        public void CombineThenCombineButtonIsEnabledIfStillEnoughItem()
        {
            _store.AddItemToInventory("ea001");
            _store.AddItemToInventory("ea002");

            _ui.onCombineClick();

            Assert.True(_ui._buttonCombineEnable);
        }

        internal class MyCombinationUiPure : CombinationUiPure
        {
            internal bool _buttonCombineEnable = false;

            public MyCombinationUiPure(Combination combination)
                : base(combination)
            { }

            protected override void setCombineButtonEnable(bool enable)
            {
                _buttonCombineEnable = enable;
            }
        }
    }
}