using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;

namespace ShopSystem
{
    public class Inventory : IReadOnlyInventory
    {
        public ReadOnlyReactiveProperty<int> ItemsCount => _itemsCount;
        public ReadOnlyReactiveProperty<IReadOnlyInventorySlot[,]> InventorySlots => _inventorySlots;

        private readonly ReactiveProperty<int> _itemsCount = new();
        private readonly ReactiveProperty<IReadOnlyInventorySlot[,]> _inventorySlots = new();

        private ItemDatabase _itemDatabase;

        private readonly int _rows;
        private readonly int _columns;

        public Inventory(int rows, int columns, InventoryData data, List<InventorySlotViewModel> inventorySlots, ItemDatabase itemDatabase)
        {
            var slots = new InventorySlot[rows, columns];
            int index = 0;
            _itemDatabase = itemDatabase;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var slot = new InventorySlot();

                    if (index < data.Slots.Count) slot.SetInventorySlot(data.Slots[index]);
                    else slot.SetInventorySlot(new InventorySlotData(1, 1));
                    slots[r, c] = slot;
                    inventorySlots[index].SetModel(slot);
                    index++;
                }
            }

            _inventorySlots = new(slots);
            _itemsCount.Value = data.Slots.Sum(s => s.Amount);
        }

        public int GetAmount(int itemId)
        {
            return _inventorySlots.Value.Cast<InventorySlot>()
                .Where(slot => slot.ItemId.CurrentValue == itemId)
                .Sum(slot => slot.Amount.CurrentValue);
        }

        public bool AddItem(InventorySlotData data)
        {
            for (int x = 0; x < _inventorySlots.Value.GetLength(0); x++)
            {
                for (int y = 0; y < _inventorySlots.Value.GetLength(1); y++)
                {
                    var slot = _inventorySlots.Value[x, y];
                    if (slot.ItemId.CurrentValue == 0)
                    {
                        slot.SetInventorySlot(data);
                        slot.SetItem(_itemDatabase.GetItemById<BaseItem>(slot.ItemId.CurrentValue.ToString()));

                        _itemsCount.Value++;
                        _inventorySlots.Value = _inventorySlots.Value;

                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveItem(int x, int y)
        {
            _inventorySlots.Value[x, y].SetInventorySlot(new InventorySlotData(0, 0));
        }

        public InventoryData GetInventoryData()
        {
            var data = new InventoryData();
            data.Slots = new List<InventorySlotData>();

            for (int x = 0; x < _columns; x++)
                for (int y = 0; y < _rows; y++)
                {
                    var slot = InventorySlots.CurrentValue[x, y];
                    data.Slots.Add(new InventorySlotData(slot.ItemId.CurrentValue, slot.Amount.CurrentValue));

                }
            return data;
        }
    }
}