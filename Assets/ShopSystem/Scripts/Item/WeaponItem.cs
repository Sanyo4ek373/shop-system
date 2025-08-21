using UnityEngine;
namespace ShopSystem
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "Items/Weapon")]
    public class WeaponItem : BaseItem
    {
        public new ItemType Type { get; private set; } = ItemType.Weapon;
        [field: SerializeField] public int Damage { get; private set; }
    }
}