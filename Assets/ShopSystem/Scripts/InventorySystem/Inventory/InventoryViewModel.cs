using System.Collections.Generic;
using R3;
using Zenject;

namespace ShopSystem
{
    public class InventoryViewModel : MonoInstaller
    {
        private Inventory _inventory;
        private InventoryView _view;
        private List<InventorySlotViewModel> _inventorySlots;
        private DiContainer _container;
        private SaveManager _saveManager;
        private DescriptionViewModel _description;

        private const string k_saveKey = "Grid";

        [Inject]
        public void Construct(DiContainer container, SaveManager saveManager, ItemDatabase itemDatabase, DescriptionViewModel description)
        {
            _container = container;
            _saveManager = saveManager;
            _description = description;

            _inventorySlots = new List<InventorySlotViewModel>(GetComponentsInChildren<InventorySlotViewModel>());
            foreach (var slot in _inventorySlots) slot.OnItemRemoved += OnItemRemovedHandle;

            _view = GetComponent<InventoryView>();

            itemDatabase.OnItemsLoadEnd += OnItemsLoadEndHandle;
        }

        public override void InstallBindings()
        {
            Container.Bind<InventoryViewModel>().FromInstance(this).AsSingle();
        }

        private void OnItemsLoadEndHandle()
        {
            _inventory = _container.Instantiate<Inventory>(new object[] { _view.Columns, _view.Rows, _saveManager.Load<InventoryData>(k_saveKey), _inventorySlots, _description });
            _inventory.ItemsCount.Subscribe(
            onNext: slots =>
            {
                _saveManager.Save(k_saveKey, _inventory.GetInventoryData());
            });
        }

        private void OnItemRemovedHandle(IReadOnlyInventorySlot slot)
        {
            _inventory.RemoveItem(slot);
        }
    }
}
