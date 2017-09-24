using System;
using System.Collections.Generic;

namespace TestTdd
{
    internal class SimpleStorePure
    {
        private int _energy = 0;
        private List<string> _inventory = new List<string>();

        private IReadOnlyList<string> _roInventory;

        public SimpleStorePure()
        {
            _roInventory = _inventory.AsReadOnly();
        }

        public virtual int Energy
        {
            get
            {
                return _energy;
            }
            set
            {
                _energy = Math.Max(0, value);
            }
        }

        public IReadOnlyList<string> Inventory { get { return _roInventory; } }

        public void AddItemToInventory(string itemId)
        {
            _inventory.Add(itemId);
        }

        public bool RemoveItemFromInventory(string itemId)
        {
            return _inventory.Remove(itemId);
        }
    }

    internal class SimpleStore : SimpleStorePure
    {
        public override int Energy
        {
            get
            {
                return base.Energy;
            }
            set
            {
                base.Energy = value;
                Console.WriteLine("Send energy change log: {0}", base.Energy);
            }
        }
    }
}