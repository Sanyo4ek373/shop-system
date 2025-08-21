using UnityEngine;
namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ArmorSO", menuName = "Items/Armor")]
    public class ArmorItem : BaseItem
    {
        public new ItemType Type { get; private set; } = ItemType.Armor;
        [field: SerializeField] public int Defense { get; private set; }
    }
}