using System;
using System.Collections.Generic;

namespace ShopSystem
{
    [Serializable]
    public class InventoryData
    {
        public List<InventorySlotData> Slots = new();
    }
}