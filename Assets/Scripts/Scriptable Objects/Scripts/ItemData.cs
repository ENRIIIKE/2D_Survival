using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData : ScriptableObject
{
    [Header("General")]
    //Name of the item
    public string itemName = "Enter name of the item";
    //Item ID
    public int id = 0;
    //Item sprite
    //public Sprite sprite = null;

    private void OnValidate()
    {
        itemName = name;
    }
}
