using R3;

namespace ShopSystem
{
    public interface IReadOnlyInventorySlot
    {
        public ReadOnlyReactiveProperty<int> ItemId { get; }
        public ReadOnlyReactiveProperty<int> Amount { get; }

        public void SetInventorySlot(InventorySlotData data);
        public void SetItem(BaseItem item);
    }
}