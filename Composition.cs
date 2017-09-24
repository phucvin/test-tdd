using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTdd
{
    internal class SomethingPure
    { }

    internal class Something : SomethingPure
    { }

    internal class CompositionPure
    {
        protected SomethingPure _something;

        public CompositionPure()
        {
            createSomething();
        }

        protected virtual void createSomething()
        {
            _something = new SomethingPure();
        }
    }

    internal class Composition : CompositionPure
    {
        protected override void createSomething()
        {
            _something = new Something();
        }
    }
}
