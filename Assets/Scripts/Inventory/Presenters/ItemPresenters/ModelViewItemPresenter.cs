using IneventorySystem;
using InventorySystem;
using UnityEngine;

public class ModelViewItemPresenter : ItemPresenter
{
    public override void PresentItem(Item item)
    {
        GameObject itemModel = Instantiate(item.itemModel);
        itemModel.transform.position = transform.position;
        itemModel.transform.SetParent(transform);
    }

}
