using TMPro;
using UnityEngine;

namespace ShopSystem
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyAmountText;
        [field: SerializeField] public GameObject SlotsContainer { get; private set; }

        public void ShowMoneyAmount(int amount)
        {
            _moneyAmountText.text = amount.ToString();
        }
    }
}
