using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTdd
{
    internal class WeirdButtonPure
    {
        private float ticked = 0f;

        public WeirdButtonPure()
        {
            setEnable(false);
        }

        internal void tick(float dt)
        {
            if (canStillBeDisabled())
            {
                ticked += dt;
                if (!canStillBeDisabled())
                {
                    setEnable(true);
                }
            }
        }

        internal bool canStillBeDisabled()
        {
            return ticked < 10;
        }

        protected virtual void setEnable(bool enable)
        {}
    }

    internal class WeirdButton : WeirdButtonPure
    {
        // This class will be used to interact with UI framework
        // Code in here is just an example

        //private Button _btn;

        //public WeirdButton(UiFramework uiFramework)
        //{
        //    _btn = uiFramework.GetButton("weird");

        //    // Register for time passing with UI framework
        //    uiFramework.registerUpdate(dt => tick(dt));
        //}

        //protected override void setEnable(bool enable)
        //{
        //    _btn.SetEnable(enable);
        //}
    }
}
