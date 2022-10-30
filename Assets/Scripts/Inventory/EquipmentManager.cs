using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public enum EquipmentType { Helmet, Chest, Legs, Boots, Weapon }
public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private Inventory inventory;
    public Transform equipmentTransform;

    public Equipment[] currentEquipment;
    [SerializeField]
    private EquipmentSlots[] equipmentSlots;

    //This delegate will be also used to update character stats..
    public delegate void EquipmentCallback();
    public EquipmentCallback equipmentCallback;

    private void Start()
    {
        inventory = Inventory.instance;
        equipmentSlots = equipmentTransform.GetComponentsInChildren<EquipmentSlots>();

        int numSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[numSlots];
    }
    
    public void Equip(Equipment newItem)
    {
        int slotIndex =  (int)newItem.equipmentType;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];

            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        //Update Sprites, etc..
        equipmentSlots[slotIndex].AddItem(newItem);

        //Update Stats
        equipmentCallback.Invoke();
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
        }

        //Update Sprites, etc..
        equipmentSlots[slotIndex].RemoveItem();

        //Update Stats
        equipmentCallback.Invoke();
    }
}
