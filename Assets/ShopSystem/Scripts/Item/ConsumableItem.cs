using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ConsumableSO", menuName = "Items/Consumable")]
    public class ConsumableItem : BaseItem
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Type = ItemType.Consumable;
            TypeDescription.Type = "Heal";
        }
    }
}