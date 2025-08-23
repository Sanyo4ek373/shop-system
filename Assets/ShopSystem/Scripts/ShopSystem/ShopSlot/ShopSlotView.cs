using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ShopSystem
{
    public class ShopSlotView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<bool> OnMouseClick;

        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _cost;

        public void Construct(BaseItem item)
        {
            _image.sprite = item.Sprite;
            _name.text = item.Name;
            _cost.text = item.Cost.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                OnMouseClick?.Invoke(true);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnMouseClick?.Invoke(false);
            }
        }
    }
}