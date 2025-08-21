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

        private const string k_saveKey = "Grid";

        [Inject]
        public void Construct(DiContainer container, SaveManager saveManager)
        {
            _inventorySlots = new List<InventorySlotViewModel>(GetComponentsInChildren<InventorySlotViewModel>());
            _view = GetComponent<InventoryView>();

            _inventory = container.Instantiate<Inventory>(new object[] { _view.Columns, _view.Rows, saveManager.Load<InventoryData>(k_saveKey), _inventorySlots });
            _inventory.InventorySlots.Subscribe(
            onNext: slots =>
            {
                saveManager.Save(k_saveKey, _inventory.GetInventoryData());
            });

        }

        public override void InstallBindings()
        {
            Container.Bind<InventoryViewModel>().FromInstance(this).AsSingle();
        }

    }
}
