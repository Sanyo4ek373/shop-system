using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShopSystem
{
    public class ItemsDatabase : IInitializable
    {
        public event Action OnItemsLoadEnd;

        public Dictionary<int, BaseItem> Items => _items;

        private readonly Dictionary<int, BaseItem> _items = new();

        public T GetItemById<T>(int itemId) where T : BaseItem
        {
            _items.TryGetValue(itemId, out var result); ;
            return result as T;
        }

        public void Initialize()
        {
            var allItems = Resources.LoadAll<BaseItem>("Items");
            foreach (var item in allItems)
            {
                if (!_items.ContainsKey(item.Id))
                    _items[item.Id] = item;
            }
            OnItemsLoadEnd?.Invoke();
        }
    }
}