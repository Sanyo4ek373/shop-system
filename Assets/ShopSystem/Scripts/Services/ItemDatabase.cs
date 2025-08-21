using System.Collections.Generic;
using ShopSystem;
using UnityEngine;
using Zenject;

public class ItemDatabase : IInitializable
{
    private readonly Dictionary<string, BaseItem> _cache = new();

    public T GetItemById<T>(string itemId) where T : BaseItem
    {
        if (_cache.TryGetValue(itemId, out BaseItem cachedItem))
        {
            return cachedItem as T;
        }

        T item = Resources.Load<T>($"Items/{itemId}");
        if (item != null)
        {
            _cache[itemId] = item;
        }
        else
        {
            Debug.LogWarning($"Item with ID '{itemId}' not found at Resources/Items/{itemId}");
        }

        return item;
    }

    public void Initialize()
    {
        var allItems = Resources.LoadAll<BaseItem>("Items");
        foreach (var item in allItems)
        {
            if (!_cache.ContainsKey(item.Id.ToString()))
                _cache[item.Id.ToString()] = item;
        }
    }
}