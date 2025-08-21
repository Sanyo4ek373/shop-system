using Inventory;
using R3;
using UnityEngine;

namespace ShopSystem
{
    public class InventorySlotViewModel : MonoBehaviour
    {
        private InventorySlot _slot;
        private InventorySlotView _view;
        private BaseItem _item;

        public void SetModel(InventorySlot slot)
        {
            _slot = slot;
            _view = GetComponent<InventorySlotView>();
            _view.OnMouseClick += OnMouseClickHandle;

            _slot.ItemId.Subscribe(_ => _view.SetImage(_slot.Item != null ? _slot.Item.Sprite : null));
        }

        private void OnMouseClickHandle(bool isLeft)
        {
            if (!isLeft) _view.SetImage(null);
        }
    }
}