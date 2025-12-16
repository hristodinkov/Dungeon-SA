using InventorySystem;
using UnityEngine;

public abstract class InventoryPresenter : MonoBehaviour
{
    [SerializeField]
    protected Inventory inventory;

    public abstract void PresentInventory();
    public void RefreshInventoryWithPrevSorting()
    {
        inventory.PreviousSortingStrategy();
        PresentInventory();
    }
    public void RefreshInventoryWithNextSorting()
    {
        inventory.NextSortingStrategy();
        PresentInventory();
    }
}
