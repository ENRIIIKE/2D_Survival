using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ItemData
{
    public EquipmentType equipmentType;

    private void Awake()
    {
        itemType = ItemType.Equipment;
    }

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }

}
