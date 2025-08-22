using System;
using Inventory;
using R3;
using UnityEngine;

namespace ShopSystem
{
    public class InventorySlotViewModel : MonoBehaviour
    {
        public event Action<IReadOnlyInventorySlot> OnItemRemoved;
        private InventorySlot _slot;
        private InventorySlotView _view;
        private DescriptionViewModel _description;

        public void SetModel(InventorySlot slot, DescriptionViewModel description)
        {
            _slot = slot;
            _description = description;
            _view = GetComponent<InventorySlotView>();
            _view.OnMouseClick += OnMouseClickHandle;

            _slot.ItemId.Subscribe(_ => _view.SetImage(_slot.Item != null ? _slot.Item.Sprite : null));
        }

        private void OnMouseClickHandle(bool isLeft)
        {
            if (!isLeft) OnItemRemoved?.Invoke(_slot);
            else _description.ShowDescription(_slot.Item);
        }
    }
}