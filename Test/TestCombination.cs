using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestCombination
    {
        private SimpleStorePure _store;
        private Combination _comb;

        [SetUp]
        public void SetUp()
        {
            _store = new SimpleStorePure();
            _store.AddItemToInventory("ea001");
            _store.AddItemToInventory("ea001");
            _store.AddItemToInventory("ea002");

            _comb = new Combination(_store,
                requirements: new List<string> { "ea001", "ea001", "ea002" },
                result: "ea009");
        }

        [Test]
        public void ReadOnlyRequirementsAreCorrect()
        {
            Assert.AreEqual(3, _comb.Requirements.Count);
            Assert.AreEqual("ea002", _comb.Requirements[2]);
        }

        [Test]
        public void CanCombineIfEnoughItems()
        {
            Assert.True(_comb.CanCombine());
        }

        [Test]
        public void CanNotCombineIfNotEnoughCountOfAnItem()
        {
            _store.RemoveItemFromInventory("ea001");

            Assert.False(_comb.CanCombine());
        }

        [Test]
        public void CombineThenRequirementsAreRemovedFromInventory()
        {
            _comb.Combine();

            Assert.True(!_store.Inventory.Contains("ea001"));
            Assert.True(!_store.Inventory.Contains("ea002"));
        }

        [Test]
        public void CombineThenResultIsAddedToInventory()
        {
            _comb.Combine();

            Assert.True(_store.Inventory.Contains("ea009"));
        }

        [Test]
        public void CombineThenCanNotCombine()
        {
            _comb.Combine();

            Assert.False(_comb.CanCombine());
        }
    }
}