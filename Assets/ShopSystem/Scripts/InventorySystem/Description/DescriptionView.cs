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
            if (item == null)
            {
                gameObject.SetActive(false);
                return;
            }

            SetGeneralDescription(item);
            SetTypeDescription(item);

            gameObject.SetActive(true);
        }

        private void SetGeneralDescription(BaseItem item)
        {
            _image.sprite = item.Sprite;
            _itemName.text = item.Name;
            _description.text = item.Description;
            _cost.text = item.Cost.ToString();
            _itemType.text = item.Type.ToString();
        }

        private void SetTypeDescription(BaseItem item)
        {
            _typeDescription.text = item.TypeDescription.Type;
            _typeValue.text = item.TypeDescription.Value.ToString();
        }
    }
}