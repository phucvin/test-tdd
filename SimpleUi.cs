using System;

namespace TestTdd
{
    internal class SimpleUiPure
    {
        private bool _available = false;
        private string _message = "Please wait...";

        public SimpleDataPure Data { private get; set; }
        public SimpleStorePure Store { private get; set; }

        public bool Available { get { return _available; } }
        public string Message { get { return _message; } }

        public virtual void Init()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("Data");
            }
            if (Store == null)
            {
                throw new ArgumentNullException("Store");
            }
        }

        public bool Add(int a, int b)
        {
            if (checkBeforeDoAdd())
            {
                doAdd(a, b);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool checkBeforeDoAdd()
        {
            if (_available)
            {
                if (Store.Energy >= Data.EnergyCostPerAdd)
                {
                    _message = "Please wait...";
                    return true;
                }
                else
                {
                    _message = "Not enough energy";
                }
            }
            else
            {
                _message = "Can not connect to service";
            }

            return false;
        }

        internal void receiveWhatTimeIsIt(long time)
        {
            _available = time > 0;
            _message = "Please do something";
        }

        internal void failWhatTimeIsIt()
        {
            _available = false;
            _message = "Can not connect to service";
        }

        internal void receiveAdded(int added)
        {
            Store.Energy -= Data.EnergyCostPerAdd;
            _message = string.Format("Sum is {0}", added);
        }

        internal void failAdd()
        {
            _message = "Error receive result from service";
        }

        protected virtual void doAdd(int a, int b)
        {
            receiveAdded(0);
        }
    }

    internal class SimpleUi : SimpleUiPure
    {
        public SimpleService Service { private get; set; }

        public override void Init()
        {
            Console.WriteLine(Message);
            base.Init();

            if (Service == null)
            {
                throw new ArgumentNullException("Service");
            }

            initService();
        }

        protected override void doAdd(int a, int b)
        {
            Service.Add(a, b, (ok, added) =>
            {
                Console.WriteLine(Message);

                if (ok)
                {
                    receiveAdded(added);
                }
                else
                {
                    failAdd();
                }
            });
        }

        private void initService()
        {
            Service.WhatTimeIsIt((ok, time) =>
            {
                if (ok)
                {
                    receiveWhatTimeIsIt(time);
                }
                else
                {
                    failWhatTimeIsIt();
                }

                Console.WriteLine(Message);
            });
        }
    }
}