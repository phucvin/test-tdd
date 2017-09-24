using NUnit.Framework;
using System.Collections.Generic;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestItemsTablePure
    {
        private MyItemsTablePure _table;

        [SetUp]
        public void SetUp()
        {
            _table = new MyItemsTablePure();
        }

        [Test]
        public void ShowListAndCountCorrectly([Values(0, 1, 6)] int count)
        {
            var ids = createIds(count);
            _table.Show(ids);

            Assert.AreEqual(count, _table.Count);
        }

        [Test]
        public void ShowListWithAnEmptyIdAndCountCorrectly()
        {
            var ids = createIds(6);
            ids[2] = null;
            _table.Show(ids);

            Assert.AreEqual(5, _table.Count);
        }

        [Test]
        public void ClickAnItemAndTableIsCalled()
        {
            var ids = createIds(2);
            _table.Show(ids);
            _table._slots[1].onClick();

            Assert.AreEqual(1, _table._onChildItemClickCalls);
        }

        [Test]
        public void DoubleClickAnItemAndTableIsCalled()
        {
            var ids = createIds(3);
            _table.Show(ids);
            _table._slots[2].onDoubleClick();

            Assert.AreEqual(1, _table._onChildItemDoubleClickCalls);
        }

        private static List<string> createIds(int count)
        {
            var ids = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                ids.Add(string.Format("ea00{0}", i));
            }

            return ids;
        }

        private class MyItemsTablePure : ItemsTablePure
        {
            internal int _onChildItemClickCalls = 0;
            internal int _onChildItemDoubleClickCalls = 0;

            public override bool OnChildSlotClick(ItemSlotPure child)
            {
                bool result = base.OnChildSlotClick(child);
                ++_onChildItemClickCalls;
                return result;
            }

            public override bool OnChildSlotDoubleClick(ItemSlotPure child)
            {
                bool result = base.OnChildSlotDoubleClick(child);
                ++_onChildItemDoubleClickCalls;
                return result;
            }
        }
    }
}