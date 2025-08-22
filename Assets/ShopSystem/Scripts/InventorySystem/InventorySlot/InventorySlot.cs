using R3;

namespace ShopSystem
{
    public class InventorySlot : IReadOnlyInventorySlot
    {
        public BaseItem Item { get; private set; }

        public ReadOnlyReactiveProperty<int> ItemId => _itemId;
        public ReadOnlyReactiveProperty<int> Amount => _amount;

        private readonly ReactiveProperty<int> _itemId = new(0);
        private readonly ReactiveProperty<int> _amount = new(0);

        public void SetInventorySlot(InventorySlotData data)
        {
            _itemId.Value = data.ItemId;
            _amount.Value = data.Amount;
        }

        public void SetItem(BaseItem item)
        {
            Item = item;
        }

    }
}