using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ItemData
{
    [Header("Equipment")]
    public EquipmentType equipmentType;

    private void Awake()
    {
        itemType = ItemType.Equipment;
    }

    public override void UseUI()
    {
        base.UseUI();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.Remove(this);
    }
    public virtual void UseOne(PlayerAttack playerAttack)
    {
        //Code
    }
}
