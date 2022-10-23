using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Equipment, Food}
[System.Serializable]
public class ItemData : ScriptableObject
{

    [Header("General")]
    //Name of the item
    public string itemName = "Enter name of the item";
    //Item ID
    public int id = 0;
    //Item sprite
    public Sprite sprite;
    //ItemType
    public ItemType itemType;

    private void OnValidate()
    {
        itemName = name;
    }
    public virtual void Use()
    {

    }
}
