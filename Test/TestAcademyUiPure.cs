using System.Collections.Generic;
using NUnit.Framework;

namespace TestTdd.Test
{
    using MyCombinationUiPure = TestCombinationUiPure.MyCombinationUiPure;

    [TestFixture]
    internal class TestAcademyUiPure
    {
        private SimpleStorePure _store;
        private MyAcademyUiPure _ui;

        [SetUp]
        public void SetUp()
        {
            _store = new SimpleStorePure();
            _store.AddItemToInventory("ea001");
            _store.AddItemToInventory("ea002");

            var comb1 = new Combination(_store,
                requirements: new List<string> { "ea001", "ea002" },
                result: "ea009");
            var comb2 = new Combination(_store,
                requirements: new List<string> { "ea002", "ea003" },
                result: "ea012");

            _ui = new MyAcademyUiPure(new List<Combination> { comb1, comb2 });
        }

        [Test]
        public void AfterCombineOneCanNotCombineOther()
        {
            _ui._uiList[0].onCombineClick();

            Assert.False((_ui._uiList[1] as MyCombinationUiPure)._buttonCombineEnable);
        }

        private class MyAcademyUiPure : AcademyUiPure
        {
            public MyAcademyUiPure(List<Combination> list) :
                base(list)
            { }

            protected override CombinationUiPure createCombinationUi(Combination combination)
            {
                return new MyCombinationUiPure(combination);
            }
        }
    }
}