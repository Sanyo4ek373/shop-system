using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Items/Weapon")]
    public class WeaponItem : BaseItem
    {
        protected override void OnValidate()
        {
            base.OnValidate();
            Type = ItemType.Weapon;
            TypeDescription.Type = "Damage";
        }
    }
}