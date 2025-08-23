using System;
using Inventory;
using R3;
using UnityEngine;

namespace ShopSystem
{
    [RequireComponent(typeof(InventorySlotView))]
    public class InventorySlotViewModel : MonoBehaviour
    {
        public event Action<IReadOnlyInventorySlot> OnItemRemoved;

        private InventorySlotModel _slot;
        private InventorySlotView _view;
        private DescriptionViewModel _description;

        public void SetModel(InventorySlotModel slot, DescriptionViewModel description)
        {
            _slot = slot;
            _description = description;

            _view = GetComponent<InventorySlotView>();
            _view.OnMouseClick += OnMouseClickHandle;

            _slot.Item.Subscribe(_ => _view.SetImage(_slot.Item.CurrentValue != null ? _slot.Item.CurrentValue.Sprite : null));
        }

        private void OnMouseClickHandle(bool isLeft)
        {
            if (!isLeft) OnItemRemoved?.Invoke(_slot);
            else _description.ShowDescription(_slot.Item.CurrentValue);
        }
    }
}