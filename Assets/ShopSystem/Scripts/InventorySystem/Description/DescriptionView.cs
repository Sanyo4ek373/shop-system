using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class DescriptionView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemType;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _cost;
        [SerializeField] private TextMeshProUGUI _typeDescription;
        [SerializeField] private TextMeshProUGUI _typeValue;

        public void ShowDescription(BaseItem item)
        {
            _image.sprite = item.Sprite;
            _itemName.text = item.Name;
            _description.text = item.Description;
            _cost.text = item.Cost.ToString();
            _itemType.text = item.Type.ToString();

            ShowTypeDescription(item);
        }

        private void ShowTypeDescription(BaseItem item)
        {
            switch (item)
            {
                case WeaponItem weapon:
                    _typeDescription.text = "Damage";
                    _typeValue.text = weapon.Damage.ToString();
                    break;
                case ConsumableItem consumable:
                    _typeDescription.text = "Heal";
                    _typeValue.text = consumable.Heal.ToString();
                    break;
                case ArmorItem consumable:
                    _typeDescription.text = "Armor";
                    _typeValue.text = consumable.Defense.ToString();
                    break;
                default:
                    _typeDescription.text = "";
                    _typeValue.text = "";
                    break;
            }
        }
    }
}