using TMPro;
using UnityEngine;

public class ItemInfoDisplayer : MonoBehaviour
{
    public static string itemInfo;
    public static string itemName;

    [SerializeField]
    private TextMeshProUGUI itemInfoText;

    [SerializeField]
    private TextMeshProUGUI itemNameText;

    private void Update()
    {
        itemInfoText.text = itemInfo;
        itemNameText.text = itemName;
    }
}
