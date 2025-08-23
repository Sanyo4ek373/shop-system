using System.Collections.Generic;
using R3;

namespace ShopSystem
{
    public class ShopModel
    {
        public ReadOnlyReactiveProperty<int> Money => _money;
        public ReadOnlyReactiveProperty<List<ShopSlotModel>> Slots => _slots;

        private ReactiveProperty<int> _money = new();
        private ReactiveProperty<List<ShopSlotModel>> _slots = new(new List<ShopSlotModel>());

        public ShopModel(int money, ItemsDatabase itemDatabase)
        {
            _money.Value = money;

            foreach (var item in itemDatabase.Items)
                _slots.Value.Add(new ShopSlotModel(itemDatabase.Items[item.Key]));
        }

        public bool SpendMoney(int money)
        {
            if (_money.Value < money) return false;

            _money.Value -= money;
            return true;
        }

        public void AddMoney(int money)
        {
            _money.Value += money;
        }
    }
}