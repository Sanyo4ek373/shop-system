using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ArmorSO", menuName = "Items/Armor")]
    public class ArmorItem : BaseItem
    {
        private void OnValidate()
        {
            Type = ItemType.Armor;
            TypeDescription.Type = "Armor";
        }
    }
}