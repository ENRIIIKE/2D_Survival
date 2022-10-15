using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    [Header("General")]
    //Name of the item
    public new string name = "Enter name of the item";
    //Item ID
    public int id = 0;               
    //Item sprite
    //public Sprite sprite = null;
}
