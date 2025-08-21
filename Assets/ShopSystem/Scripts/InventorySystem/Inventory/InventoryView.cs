using UnityEngine;

namespace ShopSystem
{
    public class InventoryView : MonoBehaviour
    {
        [field: SerializeField] public int Rows { get; private set; }
        [field: SerializeField] public int Columns { get; private set; }
    }
}