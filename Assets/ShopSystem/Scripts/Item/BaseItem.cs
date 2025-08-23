using System;
using UnityEngine;

namespace ShopSystem
{
    public abstract class BaseItem : ScriptableObject
    {
        [field: SerializeField] public string Key { get; protected set; }
        [field: SerializeField] public int Id { get; protected set; }
        [field: SerializeField] public Sprite Sprite { get; protected set; }
        [field: SerializeField] public string Name { get; protected set; }
        [field: SerializeField] public string Description { get; protected set; }
        [field: SerializeField] public int Cost { get; protected set; }
        [field: SerializeField] public ItemType Type { get; protected set; }
        [field: SerializeField] public TypeDescription TypeDescription { get; protected set; }

        protected virtual void OnValidate()
        {
            if (Key != null) Id = Key.GetHashCode();
        }
    }

    [Serializable]
    public class TypeDescription
    {
        public string Type;
        public int Value;
    }
}