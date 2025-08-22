using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShopSystem
{
    public class ItemDatabase : IInitializable
    {
        public event Action OnItemsLoadEnd;
        private readonly Dictionary<int, BaseItem> _cache = new();

        public T GetItemById<T>(int itemId) where T : BaseItem
        {
            _cache.TryGetValue(itemId, out var result); ;
            return result as T;
        }

        public void Initialize()
        {
            var allItems = Resources.LoadAll<BaseItem>("Items");
            foreach (var item in allItems)
            {
                if (!_cache.ContainsKey(item.Id))
                    _cache[item.Id] = item;
            }
            OnItemsLoadEnd?.Invoke();
        }
    }
}