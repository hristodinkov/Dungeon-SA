using CMGTSA.Inventory;
using InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SortingDefendHightToLow : ItemSortingStrategy
{
    public override Item[] GetSortedItems(List<Item> items)
    {
        return items.OrderByDescending(item=>item.Defense).ToArray();
    }

   
    
}
