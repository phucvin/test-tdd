using System;
using NUnit.Framework;

namespace TestTdd.Test
{
    [TestFixture]
    internal class TestPointLogic
    {
        [Test]
        public void NearbyIfUnder10Unit()
        {
            MyLogicPresenter p1 = new MyLogicPresenter(1);
            MyLogicPresenter p2 = new MyLogicPresenter(6);

            Assert.True(p1.IsNearby(p2));
        }

        [Test]
        public void NotNearbyIfMoreThan10UnitAway()
        {
            MyLogicPresenter p1 = new MyLogicPresenter(6);
            MyLogicPresenter p2 = new MyLogicPresenter(21);

            Assert.False(p1.IsNearby(p2));
        }

        private class MyLogicPresenter : PointLogic<MyLogicPresenter>
        {
            private int _x;

            public MyLogicPresenter(int x)
            {
                Presenter = this;

                _x = x;
            }

            public override bool IsNearby(PointLogic<MyLogicPresenter> other)
            {
                return Math.Abs(_x - other.Presenter._x) <= 10;
            }
        }
    }
}
