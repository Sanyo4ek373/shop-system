using System;
using UnityEngine;
using R3;

namespace ShopSystem
{
    [RequireComponent(typeof(ShopSlotView))]
    public class ShopSlotViewModel : MonoBehaviour
    {
        public event Action<BaseItem> OnItemTryPurchased;

        private ShopSlotModel _model;
        private ShopSlotView _view;
        private DescriptionViewModel _description;

        public void Construct(ShopSlotModel model, DescriptionViewModel description)
        {
            _model = model;
            _description = description;

            _view = GetComponent<ShopSlotView>();
            _view.OnMouseClick += OnMouseClickHandle;

            _model.ItemId.Subscribe(_ => _view.Construct(_model.Item));
        }

        private void OnMouseClickHandle(bool isLeft)
        {
            if (!isLeft) OnItemTryPurchased?.Invoke(_model.Item);
            else _description.ShowDescription(_model.Item);
        }
    }
}