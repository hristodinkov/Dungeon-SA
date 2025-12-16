using CMGTSA.Inventory;
using InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObtainedNewToOld : ItemSortingStrategy
{
    public override Item[] GetSortedItems(List<Item> items)
    {
        List<Item> list = new List<Item>();
        for (int i = items.Count-1; i >= 0; i--)
        {
            //print(i);
            list.Add(items[i]);
        }
        return list.ToArray();
    }

    
}
