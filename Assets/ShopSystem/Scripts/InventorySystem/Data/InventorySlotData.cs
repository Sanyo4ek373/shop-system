using System;

namespace ShopSystem
{
    [Serializable]
    public class InventorySlotData
    {
        public int ItemId;
        public int Amount;

        public InventorySlotData(int itemId, int amount)
        {
            ItemId = itemId;
            Amount = amount;
        }
    }
}