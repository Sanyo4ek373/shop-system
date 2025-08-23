using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class NavigationPanel : MonoBehaviour
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _inventoryButton;

        [SerializeField] private InventoryViewModel _inventory;
        [SerializeField] private ShopViewModel _shop;
        [SerializeField] private DescriptionViewModel _description;

        private void Start()
        {
            _inventoryButton.onClick.AddListener(OnInventoryButtonClickHandle);
            _shopButton.onClick.AddListener(OnShopButtonClickHandle);
        }

        private void OnInventoryButtonClickHandle()
        {
            _inventory.gameObject.SetActive(true);
            _description.gameObject.SetActive(false);
            _shop.gameObject.SetActive(false);
        }

        private void OnShopButtonClickHandle()
        {
            _shop.gameObject.SetActive(true);
            _description.gameObject.SetActive(false);
            _inventory.gameObject.SetActive(false);
        }
    }
}