using R3;

namespace ShopSystem
{
    public class ShopSlotModel
    {
        public BaseItem Item { get; private set; }
        public ReadOnlyReactiveProperty<int> ItemId => _itemId;

        private ReactiveProperty<int> _itemId = new();

        public ShopSlotModel(BaseItem item)
        {
            Item = item;
            _itemId.Value = item.Id;
        }
    }
}