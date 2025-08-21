using R3;

namespace ShopSystem
{
    public interface IReadOnlyInventory
    {
        public ReadOnlyReactiveProperty<int> ItemsCount { get; }
        public ReadOnlyReactiveProperty<IReadOnlyInventorySlot[,]> InventorySlots { get; }

        public int GetAmount(int ItemId);
    }
}