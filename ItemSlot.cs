using System;

namespace TestTdd
{
    internal class ItemSlotPure
    {
        protected string _itemId = null;

        public string CurrentItemId { get { return _itemId; } }

        public string CurrentImagePath
        {
            get
            {
                if (!string.IsNullOrEmpty(_itemId))
                {
                    return string.Format("icon/{0}.png", _itemId);
                }
                else
                {
                    return null;
                }
            }
        }

        public ItemsTablePure ParentTable { get; set; }

        public void Show(string itemId)
        {
            if (!string.Equals(_itemId, itemId))
            {
                _itemId = itemId;
                redraw();
            }
        }

        internal void onClick()
        {
            if (ParentTable != null)
            {
                ParentTable.OnChildSlotClick(this);
            }
            else if (!string.IsNullOrEmpty(_itemId))
            {
                action1();
            }
        }

        internal void onDoubleClick()
        {
            if (ParentTable != null)
            {
                ParentTable.OnChildSlotDoubleClick(this);
            }
            else if (!string.IsNullOrEmpty(_itemId))
            {
                action2();
            }
        }

        protected virtual void action1()
        { }

        protected virtual void action2()
        { }

        protected virtual void redraw()
        { }
    }

    internal class ItemSlot : ItemSlotPure
    {
        protected override void action1()
        {
            Console.WriteLine(string.Format("Show item details of {0}", _itemId));
        }
    }
}