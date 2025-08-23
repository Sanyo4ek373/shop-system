using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ArmorSO", menuName = "Items/Armor")]
    public class ArmorItem : BaseItem
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Type = ItemType.Armor;
            TypeDescription.Type = "Armor";
        }
    }
}