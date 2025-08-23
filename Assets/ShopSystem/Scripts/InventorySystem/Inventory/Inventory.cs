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

        private ItemsDatabase _itemDatabase;

        private readonly int _rows;
        private readonly int _columns;

        public Inventory(int rows, int columns, InventoryData data, List<InventorySlotViewModel> inventorySlots, ItemsDatabase itemDatabase, DescriptionViewModel description)
        {
            var slots = new InventorySlot[rows, columns];
            _rows = rows;
            _columns = columns;
            int index = 0;
            _itemDatabase = itemDatabase;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var slot = new InventorySlot();

                    if (index < data.Slots.Count) slot.SetInventorySlot(data.Slots[index]);
                    else slot.SetInventorySlot(new InventorySlotData(0, 0));

                    slot.SetItem(_itemDatabase.GetItemById<BaseItem>(slot.ItemId.CurrentValue));
                    inventorySlots[index].SetModel(slot, description);

                    slots[r, c] = slot;
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
            for (int x = 0; x < _rows; x++)
            {
                for (int y = 0; y < _columns; y++)
                {
                    var slot = _inventorySlots.Value[x, y];
                    if (slot.ItemId.CurrentValue == 0)
                    {
                        slot.SetInventorySlot(data);
                        slot.SetItem(_itemDatabase.GetItemById<BaseItem>(slot.ItemId.CurrentValue));

                        _itemsCount.Value++;
                        _inventorySlots.Value[x, y] = slot;

                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveItem(IReadOnlyInventorySlot slot)
        {
            var slots = _inventorySlots.Value;
            for (int x = 0; x < _rows; x++)
            {
                for (int y = 0; y < _columns; y++)
                {
                    if (slots[x, y] == slot)
                    {
                        slots[x, y].SetItem(null);
                        slots[x, y].SetInventorySlot(new InventorySlotData(0, 0));

                        _itemsCount.Value--;
                        return;
                    }
                }
            }
        }

        public InventoryData GetInventoryData()
        {
            var data = new InventoryData
            {
                Slots = new List<InventorySlotData>()
            };

            for (int x = 0; x < _rows; x++)
                for (int y = 0; y < _columns; y++)
                {
                    var slot = InventorySlots.CurrentValue[x, y];
                    data.Slots.Add(new InventorySlotData(slot.ItemId.CurrentValue, slot.Amount.CurrentValue));

                }
            return data;
        }
    }
}