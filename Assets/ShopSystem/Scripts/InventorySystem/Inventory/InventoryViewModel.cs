using System.Collections.Generic;
using R3;
using Zenject;

namespace ShopSystem
{
    [UnityEngine.RequireComponent(typeof(InventoryView))]
    public class InventoryViewModel : MonoInstaller
    {
        private InventoryModel _model;
        private InventoryView _view;
        private List<InventorySlotViewModel> _inventorySlots;
        private DiContainer _container;
        private SaveManager _saveManager;
        private DescriptionViewModel _description;

        private const string k_saveKey = "Grid";

        [Inject]
        public void Construct(DiContainer container, SaveManager saveManager, ItemsDatabase itemDatabase, DescriptionViewModel description)
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

        public bool AddItem(BaseItem item)
        {
            return _model.AddItem(new InventorySlotData(item.Id, 1));
        }

        public bool IsFull()
        {
            return _model.ItemsCount.CurrentValue == _view.Rows * _view.Columns;
        }

        private void OnItemsLoadEndHandle()
        {
            _model = _container.Instantiate<InventoryModel>(new object[] { _view.Columns, _view.Rows, _saveManager.Load<InventoryData>(k_saveKey), _inventorySlots, _description });
            _model.ItemsCount.Subscribe(
            onNext: slots =>
            {
                _saveManager.Save(k_saveKey, _model.GetInventoryData());
            });
        }

        private void OnItemRemovedHandle(IReadOnlyInventorySlot slot)
        {
            _model.RemoveItem(slot);
        }
    }
}