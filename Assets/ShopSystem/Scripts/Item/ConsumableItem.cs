using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ConsumableSO", menuName = "Items/Consumable")]
    public class ConsumableItem : BaseItem
    {
        private void OnValidate()
        {
            Type = ItemType.Consumable;
            TypeDescription.Type = "Heal";
        }
    }
}