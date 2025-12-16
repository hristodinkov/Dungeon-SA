using UnityEngine;

public class EquipItem : UseItem
{
    public override bool CanUse(Item item, ItemUseContext context)
    {
        //return item.IsEquippable;
        return false;
    }

    public override void Execute(Item item, ItemUseContext context)
    {
        //add later
    }
}
