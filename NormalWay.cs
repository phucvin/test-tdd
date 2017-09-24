using System;

namespace TestTdd
{
    internal class NormalData
    {
        private int _energyCostPerAdd;

        public int EnergyCostPerAdd { get { return _energyCostPerAdd; } }

        public NormalData(string filePath)
        {
            // Fake read and fill data
            _energyCostPerAdd = 2;
        }
    }

    internal class NormalStore
    {
        private int _energy = 0;

        public int Energy
        {
            get { return _energy; }
            set
            {
                _energy = Math.Max(0, value);
                Console.WriteLine(string.Format("Energy log: {0}", _energy));
            }
        }
    }

    internal class NormalService
    {
        public void Add(int a, int b, Action<bool, int> handler)
        {
            handler(true, a + b);
        }

        public void WhatTimeIsIt(Action<bool, long> handler)
        {
            handler(true, 123);
        }
    }

    internal class NormalUi
    {
        private readonly NormalData _data;
        private readonly NormalStore _store;
        private readonly NormalService _service;

        private bool _available = false;

        public NormalUi(NormalData data, NormalStore store, NormalService service)
        {
            _data = data;
            _store = store;
            _service = service;

            if (_data == null || _store == null || _service == null)
            {
                throw new ArgumentNullException("Something");
            }

            init();
        }

        public void Add(int a, int b)
        {
            if (_available)
            {
                if (_store.Energy >= _data.EnergyCostPerAdd)
                {
                    Console.WriteLine("Please wait...");
                    _service.Add(a, b, (ok, added) =>
                    {
                        if (ok)
                        {
                            _store.Energy -= _data.EnergyCostPerAdd;
                            Console.WriteLine(string.Format("Sum is {0}", added));
                        }
                        else
                        {
                            Console.WriteLine("Error receive result from service");
                        }
                    });
                }
                else
                {
                    Console.WriteLine("Not enough energy");
                }
            }
            else
            {
                Console.WriteLine("Can not connect to service");
            }
        }

        private void init()
        {
            Console.WriteLine("Please wait...");
            _service.WhatTimeIsIt((ok, time) =>
            {
                if (ok)
                {
                    _available = true;
                    Console.WriteLine("Please do something");
                }
                else
                {
                    _available = false;
                    Console.WriteLine("Can not connect to service");
                }
            });
        }
    }

    internal class NormalWay
    {
    }
}