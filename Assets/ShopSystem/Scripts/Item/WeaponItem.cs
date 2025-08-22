using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Items/Weapon")]
    public class WeaponItem : BaseItem
    {
        private void OnValidate()
        {
            Type = ItemType.Weapon;
            TypeDescription.Type = "Damage";
        }
    }
}