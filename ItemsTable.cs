using System;
using System.Collections.Generic;

namespace TestTdd
{
    internal class ItemsTablePure
    {
        internal List<ItemSlotPure> _slots = new List<ItemSlotPure>();

        public int Count { get { return _slots.Count; } }

        public virtual bool OnChildSlotClick(ItemSlotPure child)
        {
            int childIndex = _slots.IndexOf(child);
            if (childIndex >= 0)
            {
                action1(child, childIndex);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool OnChildSlotDoubleClick(ItemSlotPure child)
        {
            int childIndex = _slots.IndexOf(child);
            if (childIndex >= 0)
            {
                action2(child, childIndex);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Show(IEnumerable<string> list)
        {
            _slots.Clear();
            foreach (string itemId in list)
            {
                if (!string.IsNullOrEmpty(itemId))
                {
                    var slot = new ItemSlotPure();
                    slot.ParentTable = this;
                    slot.Show(itemId);
                    _slots.Add(slot);
                }
            }
        }

        protected virtual void action1(ItemSlotPure child, int childIndex)
        {
        }

        protected virtual void action2(ItemSlotPure child, int childIndex)
        {
        }
    }

    internal class ItemsTable : ItemsTablePure
    {
        protected override void action1(ItemSlotPure child, int childIndex)
        {
            Console.WriteLine("Show details of item and its siblings: {0} at index {1}",
                child.CurrentItemId, childIndex);
        }
    }
}