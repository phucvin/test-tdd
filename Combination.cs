using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace TestTdd
{
    internal class Combination
    {
        private readonly SimpleStorePure _store;
        private readonly List<string> _requirements;
        private readonly string _result;

        private readonly IReadOnlyList<string> _roRequirements;

        public Combination(SimpleStorePure store, List<string> requirements, string result)
        {
            Contract.Requires(store != null);
            Contract.Requires(requirements != null && requirements.Count > 1);
            Contract.Requires(!string.IsNullOrEmpty(result));

            _store = store;
            _requirements = new List<string>(requirements);
            _result = result;
            _roRequirements = _requirements.AsReadOnly();
        }

        public IReadOnlyList<string> Requirements { get { return _roRequirements; } }

        public string Result { get { return _result; } }

        public bool CanCombine()
        {
            foreach (string item in _requirements.Distinct())
            {
                int countInStore = _store.Inventory.Select(i => string.Equals(i, item)).Count();
                int countInRequirements = _requirements.Select(i => string.Equals(i, item)).Count();
                if (countInStore < countInRequirements)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Combine()
        {
            if (CanCombine())
            {
                foreach (string item in _requirements)
                {
                    _store.RemoveItemFromInventory(item);
                }
                _store.AddItemToInventory(_result);
                return true;
            }
            else
            {
                return false;
            }
        }

        [ContractInvariantMethod]
        private void objectInvariant()
        {
            Contract.Invariant(1 > 0);
        }
    }
}