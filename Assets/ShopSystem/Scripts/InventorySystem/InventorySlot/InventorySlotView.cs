using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlotView : MonoBehaviour, IPointerClickHandler
    {
        public Action<bool> OnMouseClick;
        [SerializeField] private Image _image;

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

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
            _image.gameObject.SetActive(_image.sprite != null);
        }
    }
}
