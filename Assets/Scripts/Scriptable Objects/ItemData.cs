using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/New Item")]
public class ItemData : ScriptableObject
{
    //Name of the item
    public new string name = "Enter name of the item";
    //Item ID
    public int id = 0;               
    //Item sprite
    public Sprite sprite = null;
}
