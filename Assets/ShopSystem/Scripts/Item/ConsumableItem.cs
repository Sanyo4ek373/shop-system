using UnityEngine;
namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ConsumableSO", menuName = "Items/Consumable")]
    public class ConsumableItem : BaseItem
    {
        public new ItemType Type { get; protected set; } = ItemType.Consumable;
        [field: SerializeField] public int Heal { get; private set; }
    }
}