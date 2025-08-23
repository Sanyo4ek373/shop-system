using UnityEngine;
using Zenject;
using R3;

namespace ShopSystem
{
    [RequireComponent(typeof(ShopView))]
    public class ShopViewModel : MonoInstaller
    {
        [SerializeField] private ShopSlotViewModel _shopSlot;
        [SerializeField] private int _moneyAmount;

        private ShopView _view;
        private ShopModel _model;
        private DescriptionViewModel _description;
        private ItemsDatabase _itemDatabase;
        private InventoryViewModel _inventory;


        [Inject]
        public void Construct(ItemsDatabase itemDatabase, DescriptionViewModel description, InventoryViewModel inventory)
        {
            _view = GetComponent<ShopView>();

            _description = description;
            _inventory = inventory;

            _itemDatabase = itemDatabase;
            itemDatabase.OnItemsLoadEnd += OnItemsLoadEndHandle;
        }

        public override void InstallBindings()
        {
            Container.Bind<ShopViewModel>().FromInstance(this).AsSingle();
        }

        private void OnSlotsSetUpEndHandle()
        {
            foreach (var slot in _model.Slots.CurrentValue)
            {
                var shopSlot = Instantiate(_shopSlot, _view.SlotsContainer.transform);
                shopSlot.Construct(slot, _description);
                shopSlot.OnItemTryPurchased += OnItemTryPurchasedHandle;
            }
        }

        private void OnItemTryPurchasedHandle(BaseItem item)
        {
            if (_inventory.IsFull()) return;

            if (_model.SpendMoney(item.Cost))
            {
                _inventory.AddItem(item);
                _view.ShowMoneyAmount(_model.Money.CurrentValue);
            }
        }

        private void OnItemsLoadEndHandle()
        {
            _model = new ShopModel(_moneyAmount, _itemDatabase);
            _model.Slots.Subscribe(_ => OnSlotsSetUpEndHandle());
        }
    }
}
