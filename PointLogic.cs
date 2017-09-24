using System;

namespace TestTdd
{
    internal abstract class PointLogic<T>
    {
        public T Presenter { get; protected set; }

        public abstract bool IsNearby(PointLogic<T> other);
    }

    internal class PointPresenter: PointLogic<PointPresenter>
    {
        private int _x;

        public PointPresenter()
        {
            Presenter = this;
        }

        public override bool IsNearby(PointLogic<PointPresenter> other)
        {

            return Math.Abs(other.Presenter._x - _x) <= 10;
        }
    }
}
