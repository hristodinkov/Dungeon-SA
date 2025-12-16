using IneventorySystem;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public class IconViewInventoryPresenter : InventoryPresenter
{
    [SerializeField]
    private ItemPresenter itemPresenterPrefab;
    // Parent transform under which item UI elements will be instantiated.
    public Transform listParent;

    // UI text element that displays the name of the current sorting strategy.
    [SerializeField]
    private TextMeshProUGUI sortingStrategyNameText;
    [SerializeField]
    private bool belongsToPlayer = true;

    private void OnEnable()
    {
        PresentInventory();
    }
    public override void PresentInventory()
    {
        ClearList();
        Item[] items = inventory.Items;
        //print("da");
        Dictionary<Item, int> dict = new Dictionary<Item, int>();

        foreach (var item in items)
        {
            if (item.isStackable)
            {
                List<Item> tempItems = new List<Item>();
                tempItems = dict.Keys.ToList();
                bool doesItExist = false;
                foreach (var tempItem in tempItems)
                {
                    if (tempItem.ItemName == item.ItemName)
                    {
                        dict[tempItem]++;
                        doesItExist = true;
                        break;
                    }
                }
                if (!doesItExist)
                {
                    dict.Add(item, 1);
                }

            }
            else
            {
                dict.Add(item, 1);
            }
        }

        List<Item> listWithItemsStacked = new List<Item>();
        listWithItemsStacked = dict.Keys.ToList();

        List<int> listWithQuantityForItems = new List<int>();
        listWithQuantityForItems = dict.Values.ToList();

        for (int i = 0; i < listWithItemsStacked.Count; i++)
        {
            ItemPresenter itemPresenter = Instantiate<ItemPresenter>(itemPresenterPrefab);
            TextMeshProUGUI textQuantity = itemPresenter.GetComponentInChildren<TextMeshProUGUI>();

            itemPresenter.PresentItem(listWithItemsStacked[i]);

            // Set the parent and scale for proper UI layout.
            itemPresenter.transform.SetParent(listParent);
            itemPresenter.transform.localScale = Vector3.one;
        }
        // Update the sorting strategy text if the UI element is assigned.
        if (sortingStrategyNameText != null)
            sortingStrategyNameText.text = inventory.GetCurrentStrategyName();
    }

    private void ClearList()
    {
        foreach (Transform transform in listParent.GetComponentsInChildren<Transform>())
        {
            if (transform != listParent)
                Destroy(transform.gameObject);
        }
    }
}
