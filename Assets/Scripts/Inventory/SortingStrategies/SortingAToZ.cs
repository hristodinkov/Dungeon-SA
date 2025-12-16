using CMGTSA.Inventory;
using InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SortingAToZ :ItemSortingStrategy
{
    public override Item[] GetSortedItems(List<Item> items)
    {
        return items.OrderBy(item => item.ItemName).ToArray(); 
    }

}
